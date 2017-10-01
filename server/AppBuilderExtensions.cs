using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Parkwell.cms.server
{
    public static class AppBuilderExtensions 
    {
        public static IApplicationBuilder UseHealthMiddleware(this IApplicationBuilder builder)
        {
            return builder.MapWhen(IsHealthRequest, app => {
                app.UseMiddleware<HealthMiddleware>();
            });
        }

        public static IApplicationBuilder UseStatusMiddleware(this IApplicationBuilder builder)
        {
            return builder.MapWhen(IsStatusRequest, app => {
                app.UseMiddleware<StatusMiddleware>();
            });
        }
        
        public static IApplicationBuilder UseEnvMiddleware(this IApplicationBuilder builder)
        {
            return builder.MapWhen(IsEnvRequest, app => {
                app.UseMiddleware<EnviromentVarsMiddleware>();
            });
        }

        private static bool IsStatusRequest(HttpContext context)
        {
            return context.Request.Path == "/status";
        }

        private static bool IsHealthRequest(HttpContext context)
        {
            return context.Request.Path == "/health";
        }
        
        private static bool IsEnvRequest(HttpContext context)
        {
            return context.Request.Path == "/env";
        }
    }
}