using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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
                webBuilder
                    .ConfigureKestrel(serverOptions =>
                    {

                        serverOptions.ConfigureHttpsDefaults(listenOptions =>
                        {
                            string certificate = File.ReadAllText(@"./dev_cert.pfx");
                            Console.WriteLine(certificate);
                            string base64str = Convert.ToBase64String(Encoding.ASCII.GetBytes(certificate));

                            // certificate is an X509Certificate2
                            listenOptions.ServerCertificate = new X509Certificate2(Encoding.ASCII.GetBytes(certificate), "123456", X509KeyStorageFlags.Exportable); // new X509Certificate2("dev_cert.pfx", "123456");
                        });
                        serverOptions.Listen(IPAddress.Loopback, 80);
                        serverOptions.Listen(IPAddress.Loopback, 443, listenOptions =>
                        {
                            string certificate = File.ReadAllText(@"./dev_cert.pfx");
                            Console.WriteLine(certificate);
                            listenOptions.UseHttps(new X509Certificate2(Encoding.ASCII.GetBytes(certificate), "123456", X509KeyStorageFlags.Exportable));
                        });
                    })
                    .UseStartup<Startup>();
                    //.UseSetting(WebHostDefaults.DetailedErrorsKey, "true");
            });
    }
}
