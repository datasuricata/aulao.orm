using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aulao.orm.domain.Interfaces
{
    public interface ILenteService
    {
        Task CriarAsync(Lente lente);
        Task EditarAsync(Guid id, Lente lente);
        Task ExcluirAsync(Guid id);
        Task<Lente> PorIdAsync(Guid id);
        Task<List<Lente>> ListarAsync();
        
    }
}
