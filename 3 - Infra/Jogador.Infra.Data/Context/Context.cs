using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Jogador.Infra.Data.Context
{
    public class Context
    {
        protected IMongoClient MongoClient { get; }
        public IMongoDatabase Database { get; }
        public Context(string connectionString)
        {
            MongoClient = new MongoClient();
            Database = MongoClient.GetDatabase("Player");
        }
    }
}
