using MatBlazor;
using Microsoft.AspNetCore.Components;
using StephaneHomePage.Data.Astrologie.ThemeAstral;
using StephaneHomePage.Data.Astrologie.ThemeAstral.Draw;
using StephaneHomePage.Services.Http;
using StephaneHomePage.Struct.ImportJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Shared.Astrologie
{
    public partial class ThemeAstral
    {
        [Inject]
        private IMatToaster Toaster { get; set; }

        [Parameter]
        public ImportJson Json { get; set; }
        [Parameter]
        public double MaxWidth { get; set; }
        [Parameter]
        public double MaxHeight { get; set; }

        const string SVGRETROGRADE = "assets/svg/planet/Retrograde.svg";

        private bool _swOk { get; set; }
        private ComputeThemeAstral _computeThemeAstral;
        private DrawImage _drawImage;
        private string _sizeThemeAstralpx;

        protected override void OnInitialized()
        {
            _swOk = false;
            if (Json != null)
                ComputeAndGeneratePicture();
        }

        protected override void OnParametersSet()
        {
            if (Json != null)
                ComputeAndGeneratePicture();
        }

        private void ComputeAndGeneratePicture()
        {
            _computeThemeAstral = new ComputeThemeAstral(Json, MaxWidth, MaxHeight);
            _sizeThemeAstralpx = this._computeThemeAstral.CalcDraw.getSizeWH().ToString() + "px";
            _drawImage = new DrawImage(_computeThemeAstral);
            _swOk = true;
        }
    }
}
