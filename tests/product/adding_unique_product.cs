using NUnit.Framework;
using System.Net;
using rgparkins.cms.server.serialisation;
using rgparkins.cms.server.product;

namespace rgparkins.cms.tests.product
{
    public class Adding_unqiue_product : contexts.infrastructure_context
    {
        public Adding_unqiue_product()
        {
            Given_a_server();

            When_adding_a_product(
                new {
                    @id = GetOrCreateRandomId(),
                    description = "a test",
                    title = "title"
                }
            );

            When_retrieving_product_by_reference(GetOrCreateRandomId(false));
        }

        [Test]
        public void The_product_is_retrieved() 
        {
            Assert.That(last_http_response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var content = last_http_response.Content.ReadAsStringAsync().Result;

            var product = new BsonConverter().Deserialise<Product>(content);

            Assert.That(product.Id, Is.EqualTo(GetOrCreateRandomId(false)));
            Assert.That(product.UnmappedProperties["description"], Is.EqualTo("a test"));
            Assert.That(product.UnmappedProperties["title"], Is.EqualTo("title"));
        }
    }
}