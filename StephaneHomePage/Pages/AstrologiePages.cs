﻿using MatBlazor;
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

        public ThemeAstralModel model = new ThemeAstralModel();
        public ImportJson data;
        public bool swLoaded = false;

        private async Task HandleValidSubmit()
        {
            await LoadDatas();
        }

        protected override async Task OnInitializedAsync()
        {
            await AppStateServiceCore.ChangeTitle("Astrologie");
            model.lat = "46.20222";
            model.lng = "6.14569";
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
                    // NavigationManager.NavigateTo("/");
                    break;
            }
        }
    }
}

