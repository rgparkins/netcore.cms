using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace rgparkins.cms.server
{
    public class StatusMiddleware 
    {
        RequestDelegate _next;

        public StatusMiddleware(RequestDelegate next, ILoggerFactory loggerFactory) 
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context) {
           await context.Response.WriteAsync("No. 5 is alive");
        }
    }
}