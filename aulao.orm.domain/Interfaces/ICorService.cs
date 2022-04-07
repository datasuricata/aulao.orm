using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aulao.orm.domain.Interfaces
{
    public interface ICorService
    {
        Task CriarAsync(string nome);
        Task EditarAsync(Guid id, string nome);
        Task ExcluirAsync(Guid id);
        Task<Cor> PorIdAsync(Guid id);
        Task<List<Cor>> ListarAsync();
    }
}
