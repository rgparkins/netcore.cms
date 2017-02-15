using System.Net;
using NUnit.Framework;
using Parkwell.cms.tests.contexts;

namespace Parkwell.cms.tests.infrastructure
{
    public class Health_endpoint : infrastructure_context
    {
        public Health_endpoint()
        {
            Given_a_server(port: 8001);

            When_calling_status_endpoint();
        }

        [Test]
        public void Health_is_retrieved() {
            Assert.That(last_http_response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(last_http_response.Content.ReadAsStringAsync().Result, Is.EqualTo("No. 5 is alive"));
        }
    }
}