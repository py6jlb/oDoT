using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        var env = hostingContext.HostingEnvironment;
                        config.SetBasePath(Directory.GetCurrentDirectory());
                        Console.Write(Directory.GetCurrentDirectory());
                        config.AddJsonFile(Path.Combine("Configurations", "appsettings.json"), optional: true, reloadOnChange: true)
                            .AddJsonFile(Path.Combine("Configurations", $"appsettings.{env.EnvironmentName}.json"), optional: true, reloadOnChange: true);
                        config.AddEnvironmentVariables();
                        config.AddCommandLine(args);
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
