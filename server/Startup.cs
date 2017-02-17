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
        public static IContainer Container;

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseStatusMiddleware()
               .UseHealthMiddleware()
               .UseMvc();

            BsonClassMapper.Configure();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvcCore(options => {
                    options.InputFormatters.Clear();
                    options.OutputFormatters.Clear();

                    options.InputFormatters.Add(new CmsInputFormatter());
                    options.OutputFormatters.Add(new CmsOutputFormatter());
                });

            // Create the container builder.
            var builder = new ContainerBuilder();

            builder.RegisterModule<InMemoryModule>();
            builder.Populate(services);
            
            Container = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(Container);
        }
    }
}