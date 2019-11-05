using Microsoft.AspNetCore.Components;
using StephaneHomePage.Services.Core;
using StephaneHomePage.Struct.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Pages
{
    public partial class ViPages
    {
        [Inject]
        public AppStateServiceCore AppStateServiceCore { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var oldStruct = AppStateServiceCore.AppBarStruct;
            var newStruct = new AppBarStruct("Commandes vim", false, oldStruct.AstroZoom, oldStruct.LockBook);
            await AppStateServiceCore.ChangeStruct(newStruct);
        }
    }
}
