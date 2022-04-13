using aulao.orm.infra;
using aulao.orm.infra.Transaction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aulao.orm.service.Base
{
    public class ServiceBase : IServiceBase
    {
        private readonly IUnitOfWork _uow;

        public ServiceBase(IServiceProvider provider)
        {
            _uow = (IUnitOfWork)provider.GetService(typeof(IUnitOfWork));
        }

        public async Task Commit()
        {
           //if(existe mensagem de validacao == false) 
            await _uow.Commit();
        }
    }
}
