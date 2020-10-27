using System;
using System.Globalization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace TheWebShop.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var culture = new CultureInfo("da-DK");
            CultureInfo.DefaultThreadCurrentCulture = culture;

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog(
                    (context, configuration) =>
                    {
                        configuration.Enrich.FromLogContext()
                            .Enrich.WithMachineName()
                            .WriteTo.Console()
                            .WriteTo.Elasticsearch(
                                new ElasticsearchSinkOptions(
                                    new Uri(context.Configuration.GetConnectionString("DevelopmentElasticsearch"))
                                )
                                {
                                    IndexFormat =
                                        $"{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}-logs-{DateTime.UtcNow:MM-yyyy}",
                                    AutoRegisterTemplate = true,
                                    NumberOfShards = 2,
                                    NumberOfReplicas = 1
                                }
                            )
                            .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                            .ReadFrom.Configuration(context.Configuration);
                    })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}