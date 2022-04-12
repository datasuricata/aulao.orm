using aulao.orm.domain;
using aulao.orm.domain.Interfaces;
using aulao.orm.infra;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aulao.orm.service
{
    internal class ArmacaoService :IArmacaoService
    {
        private readonly AppDbContext db;

        public ArmacaoService(AppDbContext db)
        {
            this.db = db;
        }
        public async Task CriarAsync(string marca, TipoMaterial material, Cor cor)
        {
            var entity = new Armacao(marca,material,cor);
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

        public Task ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Armacao>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Armacao> PorIdAsync(Guid id)
        {
            return await db.Armacao.FindAsync(id);
        }
    }
}
