using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Parkwell.cms.server;
using Autofac;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace Parkwell.cms.tests.contexts
{
    public class infrastructure_context : IDisposable
    {
        TestServer server;
        private HttpClient client;
        protected HttpResponseMessage last_http_response;
        IContainer container;
        private Guid _randomId;

        public string GetOrCreateRandomId(bool create=true)
        {
            if (create)
            {
                _randomId = Guid.NewGuid();
            }

            return _randomId.ToString();
        }

        public void Dispose()
        {
            ((IDisposable)server).Dispose();
        }

        protected void Given_a_server()
        {
            server = new TestServer(
                new WebHostBuilder()
                .UseStartup<Startup>());

            client = server.CreateClient();

            container = Startup.Container;
        }

        protected void When_calling_status_endpoint() 
        {
            last_http_response = client.GetAsync("/status").Result;
        }

        protected void When_calling_health_endpoint() 
        {
            last_http_response = client.GetAsync("/health").Result;
        }

        protected void When_adding_a_product<T>(T o) 
        {
            var postData = JsonConvert.SerializeObject(o, new JsonSerializerSettings {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            last_http_response = client.PostAsync("/api/products", new StringContent(postData, Encoding.UTF8, "application/json")).Result;
        }

        protected void When_retrieving_product_by_reference(string productRef) 
        {
            last_http_response = client.GetAsync("/api/products/" + productRef).Result;;
        }
    }
}