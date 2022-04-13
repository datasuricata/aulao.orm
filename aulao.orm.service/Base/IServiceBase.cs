using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aulao.orm.service.Base
{
    public interface IServiceBase
    {
        Task Commit();
    }
}
