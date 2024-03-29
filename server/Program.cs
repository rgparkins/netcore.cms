﻿using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace rgparkins.cms.server
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
                .UseKestrel()
                .UseUrls("http://*:5000");

            var host = builder.Build();
            host.Run();
        }
    }
}
