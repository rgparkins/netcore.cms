using System.ComponentModel.DataAnnotations;

namespace Parkwell.cms.server.metadata
{
    public class Metadata : Document
    {
        [Required]
        public string CollectionName { get; set; }
    }
}