using System.Collections.Generic;

namespace Parkwell.cms.server.metadata
{
    public class ProductMetadata : Metadata
    {
        public List<string> Categories { get; set;}

        public List<string> SubCategories { get; set;}
    }
}