using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Parkwell.cms.server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Running demo with Kestrel.");

            var config = new ConfigurationBuilder()
                .Build();

            var builder = new WebHostBuilder()
                .UseStartup<Startup>()
                .UseKestrel(options =>
                {
                    if (config["threadCount"] != null)
                    {
                        options.ThreadCount = int.Parse(config["threadCount"]);
                    }
                })
                .UseUrls("http://localhost:5000");

            var host = builder.Build();
            host.Run();
        }
    }
}
