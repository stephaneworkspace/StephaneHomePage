using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace StephaneHomePage
{
    static class Constants
    {
        // Je ne sais plus ce qu'il y a la dedans... mais le URL_BASE_RUST est
        // désactivé ça j'en suis sur... le reste ça doit être pour
        // l'astrologie qui est deperaced aussi
        public const string URL_BASE = "http://www.stephane-bressani.ch:8000/";
        public const string URL_BASE_TEST = "http://www.stephane-bressani.ch:8888/";
        public const string URL_BASE_RUST = "http://www.stephane-bressani.ch:3000/";
		// Définit si je travail en local en http avec docker sur mon desktop debian ou sur le web https / ou iis windows 10 (deprecated)
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
            .ConfigureWebHostDefaults(webBuilder =>
            {
				webBuilder.UseUrls("http://0.0.0.0:4000");
				webBuilder.UseStartup<Startup>()
                    .UseSetting(WebHostDefaults.DetailedErrorsKey, "true");
            });
    }
}
