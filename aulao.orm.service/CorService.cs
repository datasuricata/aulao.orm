using aulao.orm.domain;
using aulao.orm.domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aulao.orm.service
{
    public class CorService : ICorService
    {
        public Task CriarAsync(string nome)
        {
            throw new NotImplementedException();
        }

        public Task EditarAsync(Guid id, string nome)
        {
            throw new NotImplementedException();
        }

        public Task ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cor>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Cor> PorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
