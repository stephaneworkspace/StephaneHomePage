using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StephaneHomePage.Services.Http
{
    public class CityServiceHttp : ICityServiceHttp
    {
        /// <summary>
        /// HttpClient
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClient">HttpClient</param>
        public CityServiceHttp(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> GetCitys(string name)
        {
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString["name"] = name;
            var req = new HttpRequestMessage(HttpMethod.Get, $"{Constants.URL_BASE}api/citys_filter?{queryString.ToString()}");
            // req.Headers.Add("Authorization", $"Bearer {_storage["token"]}");
            return await _httpClient.SendAsync(req);
        }
    }
}
