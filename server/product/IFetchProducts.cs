using System.Threading.Tasks;

namespace rgparkins.cms.server.product
{
    public interface IFetchProducts
    {
        Task<Product> Get(string productReference);
    }
}