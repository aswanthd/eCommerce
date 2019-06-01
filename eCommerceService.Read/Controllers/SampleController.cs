using eCommerce.CommonModel;
using eCommerceService.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace eCommerceService.Read.Controllers
{
    [RoutePrefix("api/v1/sample")]
    public class SampleController : ApiController
    {
        private readonly IECommerceReader ecommerceReader;

        public SampleController(IECommerceReader ecommerceReader)
        {
            this.ecommerceReader = ecommerceReader;
        }

        [Route("getValues")]
        public async Task<IHttpActionResult> GetValues()
        {
            return this.Ok(await ecommerceReader.GetValues());
        }

        //public async Task<IHttpActionResult> GetById(string id)
        //{
        //    return 
        //}

        [HttpPost]
        [Route("save")]
        public async Task<HttpResponseMessage> Save(Class value)
        {
            OperationOutcome outcome = await ecommerceReader.Save(value);
            return Request.CreateResponse(HttpStatusCode.OK, outcome);
        }
    }
}
