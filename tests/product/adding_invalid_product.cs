using NUnit.Framework;
using System.Net;

namespace rgparkins.cms.tests.product
{
    public class adding_invalid_product : contexts.infrastructure_context
    {
        public adding_invalid_product()
        {
            Given_a_server();

            When_adding_a_product(
                new {
                    description = "a test",
                    title = "title"
                }
            );
        }

        [Test]
        public void The_response_indicates_failure() 
        {
            var content = last_http_response.Content.ReadAsStringAsync().Result;
            
            Assert.That(last_http_response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(content, Is.EqualTo("Invalid product reference"));
        }
    }
}