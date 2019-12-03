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

        [Parameter]
        public bool LockBook { get; set; }

        bool unlockDialogIsOpen { get; set; }
        bool unlockDialogIsOpen2 { get; set; }
        string password { get; set; }
        bool swSecret { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.unlockDialogIsOpen = false;
            this.unlockDialogIsOpen = false;
            this.password = null;
            this.swSecret = false;
        }

        public void NewThemeOnClick(MouseEventArgs e)
        {
            this.NavigationManager.NavigateTo("/astrologie?swRefresh=refresh");
        }

        public async Task ZoomThemeInOnClick(MouseEventArgs e)
        {
            this.Zoom += 1;
            var newStruct = new AppBarStruct("Astrologie", true, this.Zoom, this.LockBook);
            await this.AppStateServiceCore.ChangeStruct(newStruct);
            StateHasChanged();
        }

        public async Task ZoomThemeOutOnClick(MouseEventArgs e)
        {
            this.Zoom = 1;
            var newStruct = new AppBarStruct("Astrologie", true, this.Zoom, this.LockBook);
            await this.AppStateServiceCore.ChangeStruct(newStruct);
            StateHasChanged();
        }

        public void UnlockOnClick(MouseEventArgs e)
        {
            this.unlockDialogIsOpen = true;
        }

        public async Task UnlockVerifPasswordOnClick()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("password.json").Build();
            if (this.password == config.GetSection("password").Value)
            {
                this.swSecret = true;
                this.unlockDialogIsOpen = false;
                this.unlockDialogIsOpen2 = true;
                this.LockBook = true;
                var newStruct = new AppBarStruct("Astrologie", true, this.Zoom, this.LockBook);
                await this.AppStateServiceCore.ChangeStruct(newStruct);
                StateHasChanged();
            }
        }
    }
}
