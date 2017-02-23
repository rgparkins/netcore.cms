using System.Threading.Tasks;

namespace Parkwell.cms.server.product
{
    public interface IFetchProducts
    {
        Task<Product> Get(string productReference);
    }
}