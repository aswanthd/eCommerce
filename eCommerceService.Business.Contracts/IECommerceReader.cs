using eCommerce.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceService.Business.Contracts
{
    public interface IECommerceReader
    {
        Task<List<Class>> GetValues();

        Task<OperationOutcome> Save(Class value);
    }
}
