using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Configuration;
using StephaneHomePage.Services.Core;
using StephaneHomePage.Struct.Layout;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Shared
{
    public partial class AppBar
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public AppStateServiceCore AppStateServiceCore { get; set; }

        [Parameter] 
        public string Title { get; set; }

        [Parameter]
        public bool ShowSwAstroZoom { get; set; }

        [Parameter]
        public int Zoom { get; set; }

        bool unlockDialogIsOpen = false;
        bool unlockDialogIsOpen2 = false;
        string password = null;
        bool swSecret = false;

        public void NewThemeOnClick(MouseEventArgs e)
        {
            NavigationManager.NavigateTo("/astrologie?swRefresh=refresh");
        }

        public async Task ZoomThemeInOnClick(MouseEventArgs e)
        {
            Zoom += 1;
            var newStruct = new AppBarStruct("Astrologie", true, Zoom);
            await AppStateServiceCore.ChangeStruct(newStruct);
            StateHasChanged();
        }

        public async Task ZoomThemeOutOnClick(MouseEventArgs e)
        {
            Zoom = 1;
            var newStruct = new AppBarStruct("Astrologie", true, Zoom);
            await AppStateServiceCore.ChangeStruct(newStruct);
            StateHasChanged();
        }

        public void UnlockOnClick(MouseEventArgs e)
        {
            unlockDialogIsOpen = true;
        }

        void UnlockVerifPasswordOnClick()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("password.json").Build();
            if (password == config.GetSection("password").Value)
            {
                swSecret = true;
                unlockDialogIsOpen = false;
                unlockDialogIsOpen2 = true;
            }
        }
    }
}
