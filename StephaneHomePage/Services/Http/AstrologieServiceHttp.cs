using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        public async Task<HttpResponseMessage> GetThemeAstral()
        {
            var req = new HttpRequestMessage(HttpMethod.Get, $"{Constants.URL_BASE}api/astrology_birth_theme");
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
