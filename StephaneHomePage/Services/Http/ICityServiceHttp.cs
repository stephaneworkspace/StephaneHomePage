using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StephaneHomePage.Services.Http
{
    public interface ICityServiceHttp
    {
        Task<HttpResponseMessage> GetCitys(string name);
    }
}
