using System.Threading.Tasks;

namespace rgparkins.cms.server.metadata
{
    public interface IFetchMetadata
    {
        Task<Metadata> FetchByCollection(string collectionName);
    }

    public interface IStoreMetadata
    {
        Task Store(Metadata data);
    }
}