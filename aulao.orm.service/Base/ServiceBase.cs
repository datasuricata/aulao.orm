using aulao.orm.infra;
using aulao.orm.infra.Transaction;
using aulao.orm.service.Validacoes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aulao.orm.service.Base
{
    public class ServiceBase : IServiceBase
    {
        private readonly IUnitOfWork _uow;
        private readonly CorValidator _cor;
       

        public ServiceBase(IServiceProvider provider,CorValidator cor)
        {
            _uow = (IUnitOfWork)provider.GetService(typeof(IUnitOfWork));
            _cor = cor;
        }

        public async Task Commit()
        {
            //if(existe mensagem de validacao == false) 
            if ()
            {
                
            }
            await _uow.Commit();
        }
    }
}
