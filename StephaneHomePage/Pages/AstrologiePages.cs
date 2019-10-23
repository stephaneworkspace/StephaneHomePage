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

        public bool swLock { get; set; } = false;
        public bool swLoaded = false;

        public ThemeAstralModel model = new ThemeAstralModel();
        public ImportJson data;
        
        public bool swSearch { get; set; } = false;
        public List<CityWithFlag> search = new List<CityWithFlag>();

        public string citySearch
        {
            get { return _citySearch; }
            set
            {
                _citySearch = value;
                SearchCity();
            }
        }
        private string _citySearch;

        public string citySearchId
        {
            get { return _citySearchId; }
            set
            {
                _citySearchId = value;
                BindCity();
            }
        }
        public string _citySearchId;

        private async Task HandleValidSubmit()
        {
            await LoadDatas();
        }

        protected override async Task OnInitializedAsync()
        {
            NavigationManager.LocationChanged += OnLocationChanges;
            await AppStateServiceCore.ChangeTitle("Astrologie");
            model.lat = "46.20222";
            model.lng = "6.14569";
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
                    model = new ThemeAstralModel();
                    model.lat = "46.20222";
                    model.lng = "6.14569";
                    citySearch = "";
                    citySearchId = "";
                    swLock = false;
                    swLoaded = false;
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
                    data = JsonConvert.DeserializeObject<ImportJson>(content);
                    swLoaded = true;
                    swLock = true;
                    break;
                default:
                    MatToaster.Add("Impossible de recevoir les données du serveur", MatToastType.Danger, "Erreur http " + response.StatusCode, "danger");
                    NavigationManager.NavigateTo("/");
                    break;
            }
        }

        private async void SearchCity()
        {
            swSearch = false;
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
                                swSearch = true;
                                data_return.Add(new CityWithFlag(d.id, d.name, d.lat, d.lng, d.country, ""));
                            }
                        search = data_return;
                    } else
                    {
                        search = new List<CityWithFlag>();
                        model.lat = "46.20222";
                        model.lng = "6.14569";
                    }
                    StateHasChanged();
                    break;
                default:
                    MatToaster.Add("Impossible de recevoir les données des villes du serveur", MatToastType.Danger, "Erreur http " + response.StatusCode, "danger");
                    NavigationManager.NavigateTo("/");
                    search = null;
                    StateHasChanged();
                    break;
            }
        }

        private void BindCity()
        {
            model.lat = "";
            model.lng = "";
            foreach (var b in search)
            {
                if (b.Id.ToString() == _citySearchId)
                {
                    model.lat = b.Lat.ToString();
                    model.lng = b.Lng.ToString();
                }
            }
            StateHasChanged();
        }
    }
}

