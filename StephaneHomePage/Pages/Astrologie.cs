using MatBlazor;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using StephaneHomePage.Model;
using StephaneHomePage.Services.Http;
using StephaneHomePage.Struct.ImportJson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace StephaneHomePage.Pages
{
    public partial class Astrologie
    {
        [Inject]
        private NavigationManager _navigationManager { get; set; }

        [Inject]
        private IMatToaster _matToaster { get; set; }

        [Inject]
        private IAstrologieServiceHttp _astrologieServiceHttp { get; set; }

        public ThemeAstralModel model = new ThemeAstralModel();

        public ImportJson data;

        public bool swLoaded = false;

        public Astrologie(NavigationManager navigationManager, IMatToaster matToaster, IAstrologieServiceHttp astrologieServiceHttp)
        {
            _navigationManager = navigationManager;
            _matToaster = matToaster;
            _astrologieServiceHttp = astrologieServiceHttp;
        }

        public Astrologie()
        {

        }


        private async Task HandleValidSubmit()
        {
            await LoadDatas();
        }

        protected override void OnInitialized()
        {
            model.utc = "+02:00";
            model.geo_pos_ns = "46n12";
            model.geo_pos_we = "6e9";
        }

        private async Task LoadDatas()
        {
            var response = await _astrologieServiceHttp.GetThemeAstral(model);
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    string content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<ImportJson>(content);
                    swLoaded = true;
                    break;
                default:
                    _matToaster.Add("Impossible de recevoir les données du serveur", MatToastType.Danger, "Erreur http " + response.StatusCode, "danger");
                    _navigationManager.NavigateTo("/");
                    break;
            }
        }
    }
}

