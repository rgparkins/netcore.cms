using System.Threading.Tasks;

namespace Parkwell.cms.server.product
{
    public interface IStoreProducts
    {
        Task Save(Product product);
    }
}