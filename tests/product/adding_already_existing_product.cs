using NUnit.Framework;
using System.Net;
using Parkwell.cms.server.serialisation;
using Parkwell.cms.server.product;

namespace Parkwell.cms.tests.product
{
    public class Adding_already_existing_product : contexts.infrastructure_context
    {
        public Adding_already_existing_product()
        {
            Given_a_server();

            When_adding_a_product(
                new {
                    @ref = GetOrCreateRandomId(),
                    description = "a test",
                    title = "title"
                }
            );

            When_adding_a_product(
                new {
                    @ref = GetOrCreateRandomId(false),
                    description = "a test",
                    title = "title"
                }
            );
        }

        [Test]
        public void The_product_is_retrieved() 
        {
            Assert.That(last_http_response.StatusCode, Is.EqualTo(HttpStatusCode.Conflict));
        }
    }
}