using NUnit.Framework;
using System.Net;
using Parkwell.cms.server.serialisation;
using Parkwell.cms.server.metadata;

namespace Parkwell.cms.tests.product
{
    public class Adding_metadata : contexts.metadata_context
    {
        public Adding_metadata()
        {
            Given_a_server();

            When_adding_metadata(
                new {
                    categories = new []
                    {
                        "Watches",
                        "Rings"
                    },
                    subCategories = new []
                    {
                        "Tissot",
                        "Rolex",
                        "Cartier"
                    },
                    collectionName = "product"
                }
            );

            When_retrieving_metadata("product");
        }

        [Test]
        public void The_metadata_is_retrieved() 
        {
            Assert.That(last_http_response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var content = last_http_response.Content.ReadAsStringAsync().Result;

            var metaData = new BsonConverter().Deserialise<ProductMetadata>(content);

            Assert.That(metaData.Categories.Count, Is.EqualTo(2));
            Assert.That(metaData.SubCategories.Count, Is.EqualTo(3));
        }
    }
}