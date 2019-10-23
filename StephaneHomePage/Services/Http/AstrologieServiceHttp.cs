using StephaneHomePage.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StephaneHomePage.Services.Http
{
    /// <summary>
    /// Astrologie
    /// </summary>
    public class AstrologieServiceHttp : IAstrologieServiceHttp
    {
        /// <summary>
        /// HttpClient
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClient">HttpClient</param>
        public AstrologieServiceHttp(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> GetThemeAstral(ThemeAstralModel model)
        {
            //NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            //queryString["year_month_day"] = $"'{model.year_month_day.Replace('-', '/')}'";
            //queryString["hour_min"] = $"'{model.hour_min}'";
            //queryString["lat"] = model.lat.ToString();
            //queryString["lng"] = model.lng.ToString();
            string queryString = $"year_month_day={model.year_month_day.Replace('-', '/')}";
            queryString += $"&hour_min={model.hour_min.Substring(0, 5)}";
            queryString += $"&lat={model.lat}";
            queryString += $"&lng={model.lng}";
            var req = new HttpRequestMessage(HttpMethod.Get, $"{Constants.URL_BASE}api/astrology_birth_theme?{queryString.ToString()}");
            // req.Headers.Add("Authorization", $"Bearer {_storage["token"]}");
            return await _httpClient.SendAsync(req);
        }
        public async Task<HttpResponseMessage> GetSwagger()
        {
            var req = new HttpRequestMessage(HttpMethod.Get, $"{Constants.URL_BASE}api/swagger");
            // req.Headers.Add("Authorization", $"Bearer {_storage["token"]}");
            return await _httpClient.SendAsync(req);
        }
    }
}
