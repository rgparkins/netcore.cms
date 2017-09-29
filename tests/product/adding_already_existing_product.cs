using NUnit.Framework;
using System.Net;

namespace Parkwell.cms.tests.product
{
    public class Adding_already_existing_product : contexts.infrastructure_context
    {
        public Adding_already_existing_product()
        {
            Given_a_server();

            When_adding_a_product(
                new {
                    @id = GetOrCreateRandomId(),
                    description = "a test",
                    title = "title"
                }
            );

            When_adding_a_product(
                new {
                    @id = GetOrCreateRandomId(false),
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