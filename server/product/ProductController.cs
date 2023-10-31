using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rgparkins.cms.server.product
{
    public class ProductController : Controller
    {
        private IStoreProducts _storeProducts;
        private IFetchProducts _fetchProducts;

        public ProductController(IStoreProducts storeProducts, IFetchProducts fetchProducts)
        {
            _storeProducts = storeProducts;
            _fetchProducts = fetchProducts;
        }
        
        [Route("api/products")]
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody]Product product) 
        {
            if(string.IsNullOrEmpty(product.Id)) 
            {
                return new ContentResult
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = "Invalid product reference"
                };
            }
            
            var storedProduct = await _fetchProducts.Get(product.Id);

            if (storedProduct != null) 
            {
                return new StatusCodeResult((int)HttpStatusCode.Conflict);
            }
            
            await _storeProducts.Save(product);
            
            return Ok();
        }

        [Route("api/products/{reference}")]
        [HttpGet]
        public async Task<IActionResult> GetProduct(string reference) 
        {
            var product = await _fetchProducts.Get(reference);
            
            if (product == null) 
            {
                return NotFound();
            }
            
            return Ok(product);
        }
    }
}