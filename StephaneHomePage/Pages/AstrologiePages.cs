using MatBlazor;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using StephaneHomePage.Model;
using StephaneHomePage.Services.Core;
using StephaneHomePage.Services.Http;
using StephaneHomePage.Struct.ImportJson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using StephaneHomePage.Struct.AutoComplete;
using StephaneHomePage.Struct.ImportJson.Filter;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Components.Routing;
using StephaneHomePage.Struct.Layout;

namespace StephaneHomePage.Pages
{
    public partial class AstrologiePages
    {
        [Inject]
        private AppStateServiceCore AppStateServiceCore { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject]
        private IMatToaster MatToaster { get; set; }
        [Inject]
        private IAstrologieServiceHttp AstrologieServiceHttp { get; set; }
        [Inject]
        private ICityServiceHttp CityServiceHttp { get; set; }

        public bool swLock { get; set; }
        public bool swLoaded {get; set; }

        public ThemeAstralModel model { get; set; }
        public ImportJson data { get; set; }
        
        public bool swSearch { get; set; }
        public List<CityWithFlag> search { get; set; }

        public string citySearch
        {
            get { return _citySearch; }
            set
            {
                _citySearch = value;
                SearchCity();
            }
        }
        private string _citySearch { get; set; }

        public string citySearchId
        {
            get { return _citySearchId; }
            set
            {
                _citySearchId = value;
                BindCity();
            }
        }
        public string _citySearchId { get; set; }

        private async Task HandleValidSubmit()
        {
            await this.LoadDatas();
        }

        protected override async Task OnInitializedAsync()
        {
            // Init fields
            this.swLock = false;
            this.swLoaded = false;
            this.model = new ThemeAstralModel();
            this.model.lat = "46.20222";
            this.model.lng = "6.14569";
            this.swSearch = false;
            this.search = new List<CityWithFlag>(); 
            
            // Event
            this.NavigationManager.LocationChanged += OnLocationChanges;
            var oldStruct = this.AppStateServiceCore.AppBarStruct;
            var newStruct = new AppBarStruct("Astrologie", true, oldStruct.AstroZoom, oldStruct.LockBook);
            await this.AppStateServiceCore.ChangeStruct(newStruct);
            this.AppStateServiceCore.OnChange += OnStructChange;
        }

        private void OnLocationChanges(object sender, LocationChangedEventArgs e)
        {
            var uri = new Uri(NavigationManager.Uri);
            string swRefreshQuery = QueryHelpers.ParseQuery(uri.Query).TryGetValue("swRefresh", out var sw) ? sw.First() : "";
            if (swRefreshQuery.Length == 0)
            {
            } else
            {
                if (swRefreshQuery == "refresh")
                {
                    this.model = new ThemeAstralModel();
                    this.citySearch = "";
                    this.citySearchId = "";
                    this.model.lat = "46.20222";
                    this.model.lng = "6.14569";
                    this.swLock = false;
                    this.swLoaded = false;
                }
            }
            StateHasChanged();
        }

        private async Task LoadDatas()
        {
            var response = await AstrologieServiceHttp.GetThemeAstral(model);
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    string content = await response.Content.ReadAsStringAsync();
                    this.data = JsonConvert.DeserializeObject<ImportJson>(content);
                    this.swLoaded = true;
                    this.swLock = true;
                    break;
                default:
                    this.MatToaster.Add("Impossible de recevoir les données du serveur", MatToastType.Danger, "Erreur http " + response.StatusCode, "danger");
                    this.NavigationManager.NavigateTo("/");
                    break;
            }
        }

        private async void SearchCity()
        {
            this.swSearch = false;
            var response = await CityServiceHttp.GetCitys(_citySearch);
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    string content = await response.Content.ReadAsStringAsync();
                    if (content != "[]")
                    {
                        var data_city_filter = JsonConvert.DeserializeObject<CityFilter>(content);
                        var data_return = new List<CityWithFlag>();
                        if (data_city_filter.filter != null)
                            foreach (var d in data_city_filter.filter)
                            {
                                this.swSearch = true;
                                data_return.Add(new CityWithFlag(d.id, d.name, d.lat, d.lng, d.country, ""));
                            }
                        this.search = data_return;
                    } else
                    {
                        this.search = new List<CityWithFlag>();
                        this.model.lat = "46.20222";
                        this.model.lng = "6.14569";
                    }
                    StateHasChanged();
                    break;
                default:
                    this.MatToaster.Add("Impossible de recevoir les données des villes du serveur", MatToastType.Danger, "Erreur http " + response.StatusCode, "danger");
                    this.NavigationManager.NavigateTo("/");
                    this.search = null;
                    StateHasChanged();
                    break;
            }
        }

        private void BindCity()
        {
            this.model.lat = "";
            this.model.lng = "";
            foreach (var b in search)
            {
                if (b.Id.ToString() == this._citySearchId)
                {
                    this.model.lat = b.Lat.ToString();
                    this.model.lng = b.Lng.ToString();
                }
            }
            StateHasChanged();
        }


        /// <summary>
        /// For detect zoom change
        /// </summary>
        /// <param name="appBarStruct">App bar struct</param>
        /// <returns></returns>
        #pragma warning disable 1998
        private async Task OnStructChange(AppBarStruct appBarStruct)
        {
            this.AppStateServiceCore.AppBarStruct = appBarStruct;
            StateHasChanged();
        }
        #pragma warning restore 1998
    }
}
