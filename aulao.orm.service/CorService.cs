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
    public class CorService : ICorService
    {
        private readonly AppDbContext db;

        public CorService(AppDbContext db)
        {
            this.db = db;
        }

        public async Task CriarAsync(string nome)
        {
            var entity = new Cor(nome);

            await db.AddAsync(entity);

            await db.SaveChangesAsync();
        }

        public async Task EditarAsync(Guid id, string nome)
        {
            var entity = await PorIdAsync(id);

            entity.Nome = nome;

            db.Update(entity);

            await db.SaveChangesAsync();
        }

        public async Task ExcluirAsync(Guid id)
        {
            var entity = await PorIdAsync(id);

            db.Remove(entity);

            await db.SaveChangesAsync();
        }

        public async Task<List<Cor>> ListarAsync()
        {
            //return await db.Cor.FromSqlRaw("SELECT * FROM dbo.Cor").ToListAsync();
            return await db.Cor.ToListAsync();
        }

        public async Task<Cor> PorIdAsync(Guid id)
        {
            return await db.Cor.FindAsync(id);
        }
    }
}
