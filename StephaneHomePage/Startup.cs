using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StephaneHomePage.Data;
using StephaneHomePage.Services.Http;
using EmbeddedBlazorContent;
using MatBlazor;
using StephaneHomePage.Services.Core;
using McMaster.AspNetCore.LetsEncrypt;

namespace StephaneHomePage
{
    public class Startup
    {
        private IWebHostEnvironment env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            this.env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
#pragma warning disable CS0162
            if (Constants.PROD)
            {
                var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("password.json").Build();
                services.AddLetsEncrypt();
                // services.PersistCertificatesToDirectory(new DirectoryInfo("/home/stephane/www/cert"), config.GetSection("password").Value);
            }
#pragma warning restore CS0162
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<HttpClient>();
            services.AddMatToaster(config =>
            {
                config.Position = MatToastPosition.BottomFullWidth;
                config.PreventDuplicates = true;
                config.NewestOnTop = true;
                config.ShowCloseButton = true;
                config.MaximumOpacity = 95;
                config.VisibleStateDuration = 10000;
            });
            services.AddSingleton<WeatherForecastService>();
            services.AddSingleton<IAstrologieServiceHttp, AstrologieServiceHttp>();
            services.AddSingleton<ICityServiceHttp, CityServiceHttp>();
            services.AddSingleton<AppStateServiceCore>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseEmbeddedBlazorContent(typeof(MatBlazor.BaseMatComponent).Assembly);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
#pragma warning disable CS0162
                if (Constants.PROD)
					app.UseHsts();
#pragma warning restore CS0162
            }
#pragma warning disable CS0162
			if (Constants.PROD)
				app.UseHttpsRedirection();
#pragma warning restore CS0162
            app.UseStaticFiles();
    
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
