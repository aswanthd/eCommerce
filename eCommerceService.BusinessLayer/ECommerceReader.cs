using eCommerce.CommonModel;
using eCommerceService.Business.Contracts;
using eCommerceService.DataAceess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceService.BusinessLayer
{
    public class ECommerceReader : IECommerceReader
    {
        private readonly IECommerceDataReader ecommerceDataReader;

        public ECommerceReader(IECommerceDataReader ecommerceDataReader)
        {
            this.ecommerceDataReader = ecommerceDataReader;
        }
         
        public async Task<List<Class>> GetValues()
        {
            return await ecommerceDataReader.GetValues();
        }

        public async Task<OperationOutcome> Save(Class value)
        {
            return await ecommerceDataReader.Save(value);
        }
    }
}
