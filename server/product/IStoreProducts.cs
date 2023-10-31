using System.Threading.Tasks;

namespace rgparkins.cms.server.product
{
    public interface IStoreProducts
    {
        Task Save(Product product);
    }
}