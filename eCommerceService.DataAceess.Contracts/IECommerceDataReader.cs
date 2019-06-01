using eCommerce.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceService.DataAceess.Contracts
{
    public interface IECommerceDataReader
    {
        Task<List<Class>> GetValues();

        Task<OperationOutcome> Save(Class value);
    }
}
