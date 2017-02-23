using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Parkwell.cms.server.metadata
{

    public class MetaController : Controller
    {
        IFetchMetadata _getMetaData;
        IStoreMetadata _storeMetadata;

        public MetaController(IFetchMetadata getMetadata, IStoreMetadata storeMetadata)
        {
            _getMetaData = getMetadata;
            _storeMetadata = storeMetadata;
        }
        
        [Route("api/metadata")]
        [HttpPost]
        public async Task<IActionResult> PutMetadata([FromBody]Metadata metadata) 
        {
             if (ModelState.IsValid)
             {
                 await _storeMetadata.Store(metadata);

                 return CreatedAtRoute("GetMetadata", new { collectionName = metadata.CollectionName}, metadata);
             }

             return BadRequest("Please set a collectionName");
             
        }

        [Route("api/metadata/{collectionName}", Name="GetMetadata")]
        [HttpGet]
        public async Task<IActionResult> GetMetadata(string collectionName) 
        {
             var data = await _getMetaData.FetchByCollection(collectionName);
             
             if (data == null) 
             {
                 return NotFound();
             }
             
             return Ok(data);
        }
    }
}