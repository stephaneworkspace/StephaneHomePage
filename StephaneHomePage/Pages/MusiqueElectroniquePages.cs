using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using StephaneHomePage.Services.Core;
using StephaneHomePage.Struct.Layout;

namespace StephaneHomePage.Pages
{
    public partial class MusiqueElectroniquePages
    {
        [Inject]
        public AppStateServiceCore AppStateServiceCore { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var oldStruct = AppStateServiceCore.AppBarStruct;
            var newStruct = new AppBarStruct("Musique électronique", false, oldStruct.AstroZoom, oldStruct.LockBook);
            await AppStateServiceCore.ChangeStruct(newStruct);
        }
    }
}
