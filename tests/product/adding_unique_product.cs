using NUnit.Framework;
using System.Net;
using Parkwell.cms.server.serialisation;
using Parkwell.cms.server.product;

namespace Parkwell.cms.tests.product
{
    public class Adding_unqiue_product : contexts.infrastructure_context
    {
        public Adding_unqiue_product()
        {
            Given_a_server();

            When_adding_a_product(
                new {
                    @ref = "random",
                    description = "a test",
                    title = "title"
                }
            );

            When_retrieving_product_by_reference("random");
        }

        [Test]
        public void The_product_is_retrieved() 
        {
            Assert.That(last_http_response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var content = last_http_response.Content.ReadAsStringAsync().Result;

            var product = new BsonConverter().Deserialise<Product>(content);

            Assert.That(last_http_response.Content.ReadAsStringAsync().Result, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}