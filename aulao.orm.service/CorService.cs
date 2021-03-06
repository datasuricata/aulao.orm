using aulao.orm.domain;
using aulao.orm.domain.Exceptions;
using aulao.orm.domain.Interfaces;
using aulao.orm.infra;
using aulao.orm.infra.Persistence;
using aulao.orm.service.Base;
using aulao.orm.service.Validacoes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aulao.orm.service
{
    public class CorService : ServiceBase, ICorService
    {
        private readonly IRepository<Cor> _repoCor;

        public CorService(IRepository<Cor> repoCor, IServiceProvider provider) : base(provider)
        {
            _repoCor = repoCor;
        }

        public async Task CriarAsync(string nome)
        {
            var entity = new Cor(nome);

            _notificador.Validar(entity, new CorValidator());

            await _repoCor.RegistrarAsync(entity);
        }

        public async Task EditarAsync(Guid id, string nome)
        {
            var entity = await _repoCor.PorIdAsync(id);

            entity.Nome = nome;

            _repoCor.Atualizar(entity);
        }

        public async Task<IEnumerable<Cor>> ListarAsync()
        {
            return await _repoCor.ListarAsync();
        }

        public async Task<Cor> PorIdAsync(Guid id)
        {
            return await _repoCor.PorIdAsync(id);
        }
    }
}
