using System.Net;
using NUnit.Framework;
using rgparkins.cms.tests.contexts;

namespace rgparkins.cms.tests.infrastructure
{
    public class Status_endpoint : infrastructure_context
    {
        public Status_endpoint()
        {
            Given_a_server();

            When_calling_status_endpoint();
        }

        [Test]
        public void Status_is_retrieved()
        {
            Assert.That(last_http_response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(last_http_response.Content.ReadAsStringAsync().Result, Is.EqualTo("No. 5 is alive"));
        }
    }
}