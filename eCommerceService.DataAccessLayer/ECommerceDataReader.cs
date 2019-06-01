using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using eCommerce.CommonModel;
using eCommerceService.DataAceess.Contracts;
using MongoDB.Bson;
using MongoDB.Driver;

namespace eCommerceService.DataAccessLayer
{
    public class ECommerceDataReader : IECommerceDataReader
    {
        MongoConnection mongoCOnnection = new MongoConnection();
        //private MongoConnection mongoClient = new MongoConnection("mongodb://localhost:27017");

        //private database = mongoClient.GetDatabase("startup");

        public async Task<List<Class>> GetValues()
        {
            return await mongoCOnnection.FindAll();
        }

        public async Task<OperationOutcome> Save(Class value)
        {
            return await mongoCOnnection.Save(value);
        }
    }
}
