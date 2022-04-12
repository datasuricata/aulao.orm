using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aulao.orm.domain.Interfaces
{
    public interface IArmacaoService
    {
        Task CriarAsync(string marca, TipoMaterial material, Cor cor);
        Task EditarAsync(Guid id, string marca, TipoMaterial material, Cor cor);
        Task ExcluirAsync(Guid id);
        Task<Armacao> PorIdAsync(Guid id);
        Task<List<Armacao>> ListarAsync();
    }
}
