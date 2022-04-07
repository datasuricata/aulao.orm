using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aulao.orm.domain.Interfaces
{
    public interface ILenteService
    {
        Task CriarAsync(string nome);
        Task EditarAsync(Guid id, string nome);
        Task ExcluirAsync(Guid id);
        Task<Lente> PorIdAsync(Guid id);
        Task<List<Lente>> ListarAsync();

        //todo para os outros osbjetos da lente (caracteristicas, grau)
    }
}
