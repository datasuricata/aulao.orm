using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aulao.orm.domain.Interfaces
{
    public interface ILenteGrauService
    {
        Task CriarAsync(string esquerdo,string direito);
        Task EditarAsync(Guid id, string esquerdo,string direito);
        Task ExcluirAsync(Guid id);
        Task<LenteGrau> PorIdAsync(Guid id);
        Task<List<LenteGrau>> ListarAsync();
    }
}
