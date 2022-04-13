using aulao.orm.domain;
using aulao.orm.domain.Interfaces;
using aulao.orm.infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aulao.orm.service
{
    public class LenteGrauService : ILenteGrauService
    {
        private readonly AppDbContext db;
        public LenteGrauService(AppDbContext db)
        {
            this.db = db;
        }
        public async Task CriarAsync(string esquerdo, string direito)
        {
            var entity = new LenteGrau(esquerdo, direito);
            await db.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task EditarAsync(Guid id, string esquerdo,string direito)
        {
            var entity = await PorIdAsync(id);
            entity.Direito = direito;
            entity.Esquerdo = esquerdo;
            db.Update(entity);
            await db.SaveChangesAsync();
        }

        public async Task ExcluirAsync(Guid id)
        {
            var entity = await PorIdAsync(id);
            db.Remove(entity);
            await db.SaveChangesAsync();

        }

        public async Task<List<LenteGrau>> ListarAsync()
        {
            return await db.LenteGrau.ToListAsync();
        }

        public async Task<LenteGrau> PorIdAsync(Guid id)
        {
            return await db.LenteGrau.FindAsync(id);
        }
    }
}
