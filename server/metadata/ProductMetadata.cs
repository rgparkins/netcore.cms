using System.Collections.Generic;

namespace Parkwell.cms.server.metadata
{
    public class ProductMetadata : Metadata
    {
        public List<string> Category { get; set;}

        public List<string> SubCategory { get; set;}
    }
}