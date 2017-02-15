using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Parkwell.cms.server;

namespace Parkwell.cms.tests.contexts
{
    public class infrastructure_context : IDisposable
    {
        TestServer server;
        private HttpClient client;
        protected HttpResponseMessage last_http_response;

        public void Dispose()
        {
            ((IDisposable)server).Dispose();
        }

        protected void Given_a_server(int port)
        {
            server = new TestServer(
                new WebHostBuilder()
                .UseStartup<Startup>());

            client = server.CreateClient();
        }

        protected void When_calling_status_endpoint() 
        {
            last_http_response = client.GetAsync("/status").Result;
        }

        protected void When_calling_health_endpoint() 
        {
            last_http_response = client.GetAsync("/health").Result;
        }
    }
}