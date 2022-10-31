using Azure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MsEmployee.Api
{
    [ExcludeFromCodeCoverage]
    public class Program
    {

        protected Program() { }

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((config) =>
                {

                    Console.WriteLine("AZURE_CLIENT_ID => " + System.Environment.GetEnvironmentVariable("AZURE_CLIENT_ID"));
                    Console.WriteLine("AZURE_CLIENT_SECRET => " + System.Environment.GetEnvironmentVariable("AZURE_CLIENT_SECRET"));
                    Console.WriteLine("AZURE_TENANT_ID => " + System.Environment.GetEnvironmentVariable("AZURE_TENANT_ID"));

                    var configurationRoot = config.Build();
                    config.AddAzureKeyVault(new Uri(System.Environment.GetEnvironmentVariable("AZURE_KEY_VAULT")), new DefaultAzureCredential());
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
