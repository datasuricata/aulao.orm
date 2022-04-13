using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aulao.orm.infra.Transaction
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
