using System.Threading.Tasks;
using MongoDB.Driver;
using System.Linq;

namespace rgparkins.cms.server.metadata
{
    public class MongoMetadataStore : IFetchMetadata, IStoreMetadata
    {
        IMongoDatabase _database;

        public MongoMetadataStore(IMongoDatabase database)
        {
            _database = database;
        }

        IMongoCollection<Metadata> Collection
        {
            get { return _database.GetCollection<Metadata>(CollectionName); }
        }

        public string CollectionName
        {
            get { return "metadata"; }
        }

        public async Task<Metadata> FetchByCollection(string collectionName)
        {
            var list = await Collection.Find(s => s.CollectionName == collectionName)
                                       .ToListAsync();

            return list.SingleOrDefault();
        }

        public async Task Store(Metadata data)
        {
            await Collection.ReplaceOneAsync(
                Builders<Metadata>.Filter.Where(s => s.CollectionName == data.CollectionName),
                data,
                new ReplaceOptions() { IsUpsert = true });
        }
    }
}