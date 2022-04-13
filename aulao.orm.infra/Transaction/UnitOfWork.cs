using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aulao.orm.infra.Transaction
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private readonly AppDbContext db;
        private bool disposed = false;

        public UnitOfWork(AppDbContext db)
        {
            this.db = db;
        }

        public async Task Commit()
        {
            await db.SaveChangesAsync();
        }

        protected virtual void DisposeDb(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }

            disposed = true;
        }

        /// <summary>
        /// to clear GBC
        /// </summary>
        public void Dispose()
        {
            DisposeDb(true);

            GC.SuppressFinalize(this);
        }
    }
}
