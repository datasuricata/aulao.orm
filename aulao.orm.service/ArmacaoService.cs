using aulao.orm.domain;
using aulao.orm.domain.Interfaces;
using aulao.orm.infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aulao.orm.service
{
    internal class ArmacaoService : IArmacaoService
    {
        private readonly AppDbContext db;

        public ArmacaoService(AppDbContext db)
        {
            this.db = db;
        }
        public async Task CriarAsync(string marca, TipoMaterial material, Cor cor)
        {
            var entity = new Armacao(marca, material, cor);

            var validator = new ArmalcaoValidator();

            var result = validator.Validate(entity);
            
            await db.AddAsync(entity);
            await db.SaveChangesAsync();
        }
        public async Task EditarAsync(Guid id, string marca, TipoMaterial material, Cor cor)
        {
            var entity = await PorIdAsync(id);
            entity.Marca = marca;
            entity.Material = material;
            entity.Cor = cor;
        }

        public async Task ExcluirAsync(Guid id)
        {
            var entity = await PorIdAsync(id);
            db.Remove(entity);
            await db.SaveChangesAsync();
        }

        public async Task<List<Armacao>> ListarAsync()
        {
            return await db.Armacao.ToListAsync();
        }

        public async Task<Armacao> PorIdAsync(Guid id)
        {
            return await db.Armacao.FindAsync(id);
        }
    }
}
