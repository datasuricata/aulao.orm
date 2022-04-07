using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aulao.orm.domain.Interfaces
{
    public interface IArmacaoService
    {
        Task CriarAsync(string nome);
        Task EditarAsync(Guid id, string nome);
        Task ExcluirAsync(Guid id);
        Task<Armacao> PorIdAsync(Guid id);
        Task<List<Armacao>> ListarAsync();
    }
}
