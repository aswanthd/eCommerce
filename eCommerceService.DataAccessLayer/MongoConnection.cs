using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using eCommerce.CommonModel;
using eCommerceService.DataAccessLayer.Properties;
using MongoDB.Bson;
using MongoDB.Driver;

namespace eCommerceService.DataAccessLayer
{
    public class MongoConnection
    {
        private MongoClient mongoClient;
        private IMongoCollection<Class> mongoCollection;

        public MongoConnection()
        {
            mongoClient = new MongoClient(Settings.Default.DbConnection);
            var database = mongoClient.GetDatabase(Settings.Default.Database);
            mongoCollection = database.GetCollection<Class>("Demo");
        }

        public Task<List<Class>> FindAll()
        {
            var result = mongoCollection.AsQueryable<Class>().ToList();
            return Task.FromResult<List<Class>>(result);
        }

        public Task<OperationOutcome> Save(Class value)
        {
            OperationOutcome outcome = new OperationOutcome();
            mongoCollection.InsertOne(value);
            outcome.Messages = new List<OperationOutcomeMessage>();
            OperationOutcomeMessage message = new OperationOutcomeMessage();
            message.Message = "Success";
            outcome.Messages.Add(message);
            return Task.FromResult<OperationOutcome>(outcome);
        }
    }
}
