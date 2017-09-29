using System;
using System.IO;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;

namespace Parkwell.cms.server
{
    public class Startup 
    {
        public static IContainer Container;
        public IConfigurationRoot Configuration { get; set; }
        
        public Startup(IHostingEnvironment env)
        {
            var cwd = Directory.GetCurrentDirectory();
           
            var configurationBuilder = new ConfigurationBuilder();
            
            Configuration = configurationBuilder.Build();
        }
        
        public void Configure(IApplicationBuilder app)
        {
            app.UseStatusMiddleware()
               .UseHealthMiddleware()
               .UseDefaultFiles()
//               .UseStaticFiles(new StaticFileOptions
//               {
//                    FileProvider = new PhysicalFileProvider(
//                        Path.Combine(Directory.GetCurrentDirectory(), "server/web")),
//                    RequestPath = new PathString("")
//               })
               .UseMvc();

            BsonClassMapper.Configure();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services
                .AddMvcCore(options => {
                    options.InputFormatters.Clear();
                    options.OutputFormatters.Clear();

                    options.InputFormatters.Add(new CmsInputFormatter());
                    options.OutputFormatters.Add(new CmsOutputFormatter());
                });

            // Create the container builder.
            var builder = new ContainerBuilder();

            builder.RegisterModule<InMemoryStorageModule>();
            builder.Populate(services);
            
            Container = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(Container);
        }
    }
}