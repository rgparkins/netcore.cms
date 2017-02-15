using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Parkwell.cms.server
{
    public class Startup 
    {
        IContainer Container;

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseStatusMiddleware()
               .UseHealthMiddleware();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Create the container builder.
            var builder = new ContainerBuilder();

            builder.Populate(services);
            
            Container = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(Container);
        }
    }
}