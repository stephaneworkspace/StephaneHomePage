using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.Configure<KestrelServerOptions>(
                        context.Configuration.GetSection("Kestrel"));
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().ConfigureKestrel(serverOptions =>
                    {

                        serverOptions.ConfigureHttpsDefaults(listenOptions =>
                        {
                            // certificate is an X509Certificate2
                            listenOptions.ServerCertificate = new X509Certificate2("/app/dev_cert.pfx", "123456");
                        });
                        serverOptions.ListenUnixSocket("/tmp/kestrel-test.sock");
                        serverOptions.ListenUnixSocket("/tmp/kestrel-test.sock", listenOptions =>
                        {
                            listenOptions.UseHttps("test_cert.pfx", "123456");
                        });

                    /*
                     *       .PersistKeysToFileSystem(new DirectoryInfo(@"./")) // \\root\.aspnet\https\
                             .UnprotectKeysWithAnyCertificate(
                                new X509Certificate2("dev_cert.pfx", "123456"));
                    */


                }); //.UseSetting(WebHostDefaults.DetailedErrorsKey, "true");
                });
    }
}
