using MatBlazor;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StephaneHomePage.Services.Core;
using StephaneHomePage.Struct.Layout;

namespace StephaneHomePage.Shared
{
    public partial class MainLayout
    {
        [Inject]
        public IMatToaster Toaster { get; set; }

        [Inject]
        public AppStateServiceCore AppStateServiceCore { get; set; }

        protected override void OnInitialized()
        {
            AppStateServiceCore.AppBarStruct = new AppBarStruct("Page d'acceuil", false, 1);
            AppStateServiceCore.OnChange += OnStructChange;
        }

        #pragma warning disable 1998
        private async Task OnStructChange(AppBarStruct appBarStruct)
        {
            AppStateServiceCore.AppBarStruct = appBarStruct;
            StateHasChanged();
        }
        #pragma warning restore 1998

        MatTheme _theme = new MatTheme()
        {
            Primary = MatThemeColors.Indigo._300.Value,
            Secondary = MatThemeColors.Blue._500.Value
        };
    }
}
