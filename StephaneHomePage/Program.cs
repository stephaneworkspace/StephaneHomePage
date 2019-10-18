using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace StephaneHomePage
{
    static class Constants
    {
        public const string URL_BASE = "http://www.stephane-bressani.ch:8000/";
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Debug
            /*var tempFile = Path.Combine(Path.GetTempPath(), "dev_cert.pfx");
            File.WriteAllText(tempFile, "Hello");
            File.Move(tempFile, "/key/.aspnet/https/dev_cert.pfx");*/
            // Start
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>(); //.UseSetting(WebHostDefaults.DetailedErrorsKey, "true");
                });
    }
}
