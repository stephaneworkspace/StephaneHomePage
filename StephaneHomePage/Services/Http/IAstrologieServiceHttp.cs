using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StephaneHomePage.Services.Http
{
    /// <summary>
    /// Interface pour la partie astrologie
    /// </summary>
    public interface IAstrologieServiceHttp
    {
        Task<HttpResponseMessage> GetThemeAstral();
        Task<HttpResponseMessage> GetSwagger();
    }
}