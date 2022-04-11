using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aulao.orm.domain.Interfaces
{
   public interface ILenteCaracteristicaService
    {
        Task CriarAsync(string caracteristica);
        Task EditarAsync(Guid id, string caracteristica);
        Task ExcluirAsync(Guid id);
        Task<LenteCaracteristica> PorIdAsync(Guid id);
        Task<List<LenteCaracteristica>> ListarAsync();
    }
}
