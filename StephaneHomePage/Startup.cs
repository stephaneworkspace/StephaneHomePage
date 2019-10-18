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
            //services.AddLetsEncrypt();
            services.AddRazorPages();
            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
                //options.ExcludedHosts.Add("stephane-bressani.ch");
                //options.ExcludedHosts.Add("www.stephane-bressani.ch");
            });
            // IWebHostEnvironment (stored in _env) is injected into the Startup class.
            if (!this.env.IsDevelopment())
            {
                services.AddHttpsRedirection(options =>
                {
                    options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
                    options.HttpsPort = 443;
                });
                Console.WriteLine("Debug");
                string[] dir = Directory.GetFiles(@"./");
                foreach(string d in dir)
                {
                    Console.WriteLine(d);
                }
                services.AddDataProtection()
                    .PersistKeysToFileSystem(new DirectoryInfo(@"./")) // \\root\.aspnet\https\
                    .UnprotectKeysWithAnyCertificate(
                        new X509Certificate2("dev_cert.pfx", "123456"));
            }

            services.AddServerSideBlazor();
            services.AddSingleton<HttpClient>();
            services.AddSingleton<WeatherForecastService>();
            services.AddSingleton<IAstrologieServiceHttp, AstrologieServiceHttp>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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
