using aulao.orm.domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace aulao.orm.infra.Persistence
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly AppDbContext db;

        public Repository(AppDbContext context)
        {
            this.db = context;
        }

        public virtual IQueryable<T> Queryable(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = db.Set<T>();

            if (includeProperties.Any())
                query = Include(db.Set<T>(), includeProperties);

            return query;
        }

        public virtual T Atualizar(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry(entity);
            return entity;
        }

        public virtual async Task<T> PorIdAsync(Guid id, params Expression<Func<T, object>>[] includeProperties)
        {
            if (includeProperties.Any())
                return await Queryable(includeProperties).FirstOrDefaultAsync(x => x.Id == id);

            return await db.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> PorAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            return await Queryable(includeProperties).FirstOrDefaultAsync(where);
        }

        public virtual async Task RegistrarAsync(T entity)
        {
            await db.Set<T>().AddAsync(entity);
        }

        public virtual async Task<IEnumerable<T>> ListarAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            return await Queryable(includeProperties).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> ListarPorAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            return await Queryable(includeProperties).Where(where).ToListAsync();
        }

        /// <summary>
        /// Realiza include populando o objeto passado por parametro
        /// </summary>
        /// <param name="query">Informe o objeto do tipo IQuerable</param>
        /// <param name="includeProperties">Ínforme o array de expressões que deseja incluir</param>
        /// <returns></returns>
        private IQueryable<T> Include(IQueryable<T> query, params Expression<Func<T, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
                query = query.Include(property);

            return query;
        }
    }
}
