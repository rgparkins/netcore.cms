using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Parkwell.cms.server
{
    public class HealthMiddleware 
    {
        RequestDelegate _next;

        public HealthMiddleware(RequestDelegate next, ILoggerFactory loggerFactory) 
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context) {
           await context.Response.WriteAsync("No. 5 is alive");
        }
    }
}