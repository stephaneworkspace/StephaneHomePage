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
        public const string URL_BASE_TEST = "http://www.stephane-bressani.ch:8888/";
		// Définit si je travail en local en http avec docker sur mon desktop debian ou sur le web https / ou iis windows 10
		public const bool PROD = true;
	}

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            /*.ConfigureServices((context, services) =>
            {
                services.Configure<KestrelServerOptions>(
                    context.Configuration.GetSection("Kestrel"));
                    
            })*/
            .ConfigureWebHostDefaults(webBuilder =>
            {
                //webBuilder
                    /*.ConfigureKestrel(serverOptions =>
                    {
                        serverOptions.Listen(IPAddress.Any, 80);
                        serverOptions.Listen(IPAddress.Any, 443, listenOptions =>
                        {
                            listenOptions.UseHttps(new X509Certificate2(@"./dev_cert.pfx", "123456", X509KeyStorageFlags.Exportable));
                        });
                    })*/
                if (Constants.PROD)
                    webBuilder.UseUrls("http://0.0.0.0:80;https://0.0.0.0:443");
				else
					webBuilder.UseUrls("http://0.0.0.0:80");
				webBuilder.UseStartup<Startup>()
                    .UseSetting(WebHostDefaults.DetailedErrorsKey, "true");
            });
    }
}
