using System.Threading.Tasks;
using MongoDB.Driver;
using System.Linq;
using rgparkins.cms.server.product;
using System;

namespace rgparkins.cms.server.metadata
{
    public class MongoProductStore : IFetchProducts, IStoreProducts
    {
        IMongoDatabase _database;

        public MongoProductStore(IMongoDatabase database)
        {
            _database = database;
        }

        IMongoCollection<Product> Collection
        {
            get { return _database.GetCollection<Product>(CollectionName); }
        }

        public string CollectionName
        {
            get { return "metadata"; }
        }

        public async Task<Product> Get(string productReference)
        {
             var list = await Collection.Find(s => s.Id == productReference)
                                       .ToListAsync();

            return list.SingleOrDefault();
        }

        public async Task Save(Product product)
        {
            await Collection.ReplaceOneAsync(
                Builders<Product>.Filter.Where(s => s.Id == product.Id),
                product,
                new ReplaceOptions() { IsUpsert = true });
        }
    }
}