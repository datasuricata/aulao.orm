using aulao.orm.domain;
using aulao.orm.domain.Interfaces;
using aulao.orm.infra;
using aulao.orm.service.Validacoes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aulao.orm.service
{
    public class LenteCaracteristicaService : ILenteCaracteristicaService
    {
        private readonly AppDbContext db;

        public LenteCaracteristicaService(AppDbContext db)
        {
            this.db = db;
        }

        public async Task CriarAsync(string caracteristica)
        {
            var entity = new LenteCaracteristica(caracteristica);

            var validator = new LenteCaracteristicaValidator();

            var result = validator.Validate(entity);

            await db.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task EditarAsync(Guid id, string caracteristica)
        {
            var entity = await PorIdAsync(id);
            entity.Caracteristica = caracteristica;
            db.Update(entity);
            await db.SaveChangesAsync();

        }

        public async Task ExcluirAsync(Guid id)
        {
            var entity = await PorIdAsync(id);
            db.Remove(entity);
            await db.SaveChangesAsync();
        }

        public async Task<List<LenteCaracteristica>> ListarAsync()
        {
            return await db.LenteCaracteristica.ToListAsync();
        }

        public async Task<LenteCaracteristica> PorIdAsync(Guid id)
        {
            return await db.LenteCaracteristica.FindAsync(id);
        }
    }
}
