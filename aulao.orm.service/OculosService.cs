using aulao.orm.domain;
using aulao.orm.domain.Interfaces;
using aulao.orm.infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aulao.orm.service
{
    internal class OculosService /*: IOculosService*/
    {
        private readonly AppDbContext db;
        public OculosService(AppDbContext db)
        {
            this.db = db;
        }

        public async Task CriarAsync(string nome)
        {
            //var entity = new Oculos(nome);
            //await db.AddAsync(entity);
            //await db.SaveChangesAsync();
        }
    }
}
