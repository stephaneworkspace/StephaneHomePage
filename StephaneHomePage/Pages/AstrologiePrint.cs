using MatBlazor;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using StephaneHomePage.Model;
using StephaneHomePage.Services.Core;
using StephaneHomePage.Services.Http;
using StephaneHomePage.Struct.ImportJson;
using StephaneHomePage.Struct.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace StephaneHomePage.Pages
{
    public partial class AstrologiePrint
    {
        [Inject]
        private IAstrologieServiceHttp AstrologieServiceHttp { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject]
        private IMatToaster MatToaster { get; set; }

        [Parameter]
        public string YearMonthDay { get; set; }
        [Parameter]
        public string HourMin { get; set; }
        [Parameter]
        public string Lat { get; set; }
        [Parameter]
        public string Lng { get; set; }

        public ThemeAstralModel Model { get; set; }
        public ImportJson data;

        public bool swLoaded = false;

        protected override async Task OnParametersSetAsync()
        {
            Model = new ThemeAstralModel();
            Model.year_month_day = YearMonthDay.Replace('-', '/');
            Model.hour_min = HourMin;
            Model.lat = Lat;
            Model.lng = Lng;
            await LoadDatas();
        }

        private async Task LoadDatas()
        {
            var response = await AstrologieServiceHttp.GetThemeAstral(Model);
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    string content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<ImportJson>(content);
                    swLoaded = true;
                    break;
                default:
                    MatToaster.Add("Impossible de recevoir les données du serveur", MatToastType.Danger, "Erreur http " + response.StatusCode, "danger");
                    NavigationManager.NavigateTo("/");
                    break;
            }
        }
    }
}
