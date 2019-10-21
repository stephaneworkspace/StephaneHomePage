using MatBlazor;
using Newtonsoft.Json;
using StephaneHomePage.Model;
using StephaneHomePage.Services.Http;
using StephaneHomePage.Struct.ImportJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace StephaneHomePage.Pages
{
    public partial class Astrologie
    {
        private readonly IAstrologieServiceHttp _astrologieServiceHttp;
        private readonly IMatToaster _toaster;

        public Astrologie(IAstrologieServiceHttp astrologieServiceHttp, IMatToaster toaster)
        {
            this._astrologieServiceHttp = astrologieServiceHttp;
            this._toaster = toaster;
        }

        private ThemeAstralModel _model = new ThemeAstralModel();

        ImportJson data;
        bool swLoaded = false;

        private async Task HandleValidSubmit()
        {
            await LoadDatas();
        }

        protected override void OnInitialized()
        {
            this._model.utc = "+02:00";
            this._model.geo_pos_ns = "46n12";
            this._model.geo_pos_we = "6e9";
        }

        private async Task LoadDatas()
        {
            var response = await _astrologieServiceHttp.GetThemeAstral(this._model);
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    string content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<ImportJson>(content);
                    swLoaded = true;
                    break;
                default:
                    this._toaster.Add("Impossible de recevoir les données du serveur", MatToastType.Danger, "Erreur http " + response.StatusCode, "danger");
                    NavigationManager.NavigateTo("/");
                    break;
            }
        }
    }
}
