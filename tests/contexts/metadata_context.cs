using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using rgparkins.cms.server;
using Autofac;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace rgparkins.cms.tests.contexts
{
    public class metadata_context : IDisposable
    {
        TestServer server;
        private HttpClient client;
        protected HttpResponseMessage last_http_response;
        IContainer container;
        
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

        protected void When_adding_metadata<T>(T metadata) 
        {
            var postData = JsonConvert.SerializeObject(metadata, new JsonSerializerSettings {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            last_http_response = client.PostAsync("/api/metadata/", new StringContent(postData, Encoding.UTF8, "application/json")).Result;
        }

        protected void When_retrieving_metadata(string collectionName)
        {
            last_http_response = client.GetAsync("/api/metadata/" + collectionName).Result;
        }
    }
}