using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Parkwell.cms.server
{
    public class Document
    {
        public Document()
        {
            UnmappedProperties = new Dictionary<string, object>();
        }
        
        [BsonExtraElements]
        public IDictionary<string, object> UnmappedProperties { get; set; }
    }
}