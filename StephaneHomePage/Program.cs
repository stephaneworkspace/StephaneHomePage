using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace StephaneHomePage
{
    static class Constants
    {
        public const string URL_BASE = "http://www.stephane-bressani.ch:8000/";
        public const string URL_BASE_TEST = "http://www.stephane-bressani.ch:8888/";
        public const string URL_BASE_RUST = "http://www.stephane-bressani.ch:3000/";
		// Définit si je travail en local en http avec docker sur mon desktop debian ou sur le web https / ou iis windows 10
		public const bool PROD = false;
	}

    public static class Program
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
#pragma warning disable CS0162
                if (Constants.PROD)
                    webBuilder.UseUrls("http://0.0.0.0:80;https://0.0.0.0:443");
				else
					webBuilder.UseUrls("http://0.0.0.0:80");
#pragma warning restore CS0162
				webBuilder.UseStartup<Startup>()
                    .UseSetting(WebHostDefaults.DetailedErrorsKey, "true");
            });
    }
}
