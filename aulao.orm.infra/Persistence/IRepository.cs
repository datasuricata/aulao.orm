using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace aulao.orm.infra.Persistence
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Queryable(params Expression<Func<T, object>>[] includes);
        T Atualizar(T entity);

        Task<T> PorIdAsync(Guid id, params Expression<Func<T, object>>[] includes);
        Task<T> PorAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);

        Task RegistrarAsync(T entity);

        Task<IEnumerable<T>> ListarAsync(params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> ListarPorAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
    }
}
