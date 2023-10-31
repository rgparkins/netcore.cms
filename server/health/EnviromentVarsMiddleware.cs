using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace rgparkins.cms.server
{
    public class EnviromentVarsMiddleware 
    {
        RequestDelegate _next;

        public EnviromentVarsMiddleware(RequestDelegate next, ILoggerFactory loggerFactory) 
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context) {
           await RespondWithEnvironmentVariables(context, Json());
        }

        async Task RespondWithEnvironmentVariables(HttpContext context, byte[] data)
        {
            context.Response.ContentLength = data.Length;
            context.Response.StatusCode = 200;
            context.Response.ContentType = "application/json";
            
            await context.Response.WriteAsync(Encoding.ASCII.GetString(data));
        }

        byte[] Json()
        {
            var ms = new MemoryStream();
            using (var streamWriter = new StreamWriter(ms))
            {
                JsonSerializer.CreateDefault().Serialize(
                        streamWriter, 
                        GetEnvironmentVariables());
            }
            return ms.ToArray();
        }

        private static IDictionary GetEnvironmentVariables()
        {
            return Environment.GetEnvironmentVariables();
        }
    }
}