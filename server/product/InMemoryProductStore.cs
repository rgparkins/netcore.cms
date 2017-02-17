using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace Parkwell.cms.server.product 
{
    public class InMemoryProductStore : IStoreProducts, IFetchProducts
    {
        ConcurrentBag<Product> products = new ConcurrentBag<Product>();

        public Task<Product> Get(string productReference)
        {
            var result = products.SingleOrDefault(p => p.Ref == productReference);

            return Task.FromResult(result);
        }

        public Task Save(Product product)
        {
            if (products.Any(p => p.Ref == product.Ref)) 
            {
                throw new Exception("Duplicate key exception");
            }
            products.Add(product);

            return Task.FromResult(0);
        }
    }
}