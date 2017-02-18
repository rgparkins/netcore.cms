using NUnit.Framework;
using System.Net;
using Parkwell.cms.server.serialisation;
using Parkwell.cms.server.product;

namespace Parkwell.cms.tests.product
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
            Assert.That(last_http_response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
    }
}