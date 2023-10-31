using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace rgparkins.cms.server.metadata
{
    public class InMemoryMetadataStore : IFetchMetadata, IStoreMetadata
    {
        ConcurrentDictionary<string, Metadata> metadatas = new ConcurrentDictionary<string, Metadata>();

        public Task<Metadata> FetchByCollection(string collectionName)
        {
            if (metadatas.ContainsKey(collectionName))
            {
                return Task.FromResult(metadatas[collectionName]);
            }

            return Task.FromResult<Metadata>(null);
        }

        public Task Store(Metadata data)
        {
            if (metadatas.ContainsKey(data.CollectionName))
            {
                throw new Exception("Already exists");
            }

            metadatas.AddOrUpdate(data.CollectionName, data, (k, v) => { return data; });

            return Task.FromResult(0);
        }
    }
}