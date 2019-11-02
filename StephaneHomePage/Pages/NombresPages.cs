using MatBlazor;
using Microsoft.AspNetCore.Components;
using StephaneHomePage.Model;
using StephaneHomePage.Services.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace StephaneHomePage.Pages
{
    public partial class NombresPages
    {
        [Inject]
        private IAstrologieServiceHttp AstrologieServiceHttp { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject]
        private IMatToaster MatToaster { get; set; }

        [Parameter]
        public string date { get; set; }
        [Parameter]
        public string nom { get; set; }
        [Parameter]
        public string prenom { get; set; }

        public bool swLoaded { get; set; } = false;

        public string contentHtml { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadDatas();
        }

        private async Task LoadDatas()
        {
            ThemeNombresModel model = new ThemeNombresModel();
            model.date = date;
            model.nom = nom;
            model.prenom = prenom;
            var response = await AstrologieServiceHttp.GetNombres(model);
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    string content = await response.Content.ReadAsStringAsync();
                    //data = JsonConvert.DeserializeObject<ImportJson>(content);
                    contentHtml = content;
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
