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
    public class LenteService : ILenteService
    {
        private readonly AppDbContext db;
        public LenteService(AppDbContext db)
        {
            this.db = db;
        }

        public async Task CriarAsync(Lente lente)
        {
            var entity = new Lente();
            await db.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task EditarAsync(Guid id, Lente lente)
        {
            var entity = await PorIdAsync(id);
            entity.Nome = lente.Nome;
            entity.Grau = lente.Grau;
            entity.Caracteristicas = lente.Caracteristicas;
            db.Update(entity);
            await db.SaveChangesAsync();
        }

        public async Task ExcluirAsync(Guid id)
        {
            var entity = await PorIdAsync(id);
            db.Remove(entity);
            await db.SaveChangesAsync();
        }

        public async Task<List<Lente>> ListarAsync()
        {
            return await db.Lente.Include(x=>x.Grau).Include(x=>x.Grau).ToListAsync();
        }

        public async Task<Lente> PorIdAsync(Guid id)
        {
            return await db.Lente.FindAsync(id);
        }
    }
}
