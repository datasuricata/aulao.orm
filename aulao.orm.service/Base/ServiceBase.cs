using aulao.orm.infra;
using aulao.orm.infra.Transaction;
using aulao.orm.service.Notificacoes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aulao.orm.service.Base
{
    public class ServiceBase : IServiceBase
    {
        private readonly IUnitOfWork _uow;
        protected readonly INotificadorEvento _notificador;

        public ServiceBase(IServiceProvider provider)
        {
            _uow = (IUnitOfWork)provider
                .GetService(typeof(IUnitOfWork));

            _notificador = (INotificadorEvento)provider
                .GetService(typeof(INotificadorEvento));
        }

        public async Task Commit()
        {
            if (_notificador.Validado)
                await _uow.Commit();
        }
    }
}
