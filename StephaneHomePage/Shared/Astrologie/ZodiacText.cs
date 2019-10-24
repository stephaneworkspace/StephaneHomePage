using Microsoft.AspNetCore.Components;
using StephaneHomePage.Struct.Astrologie.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Shared.Astrologie
{
    public partial class ZodiacText
    {
        [Parameter]
        public ZodiacT ZodiacT { get; set; }

        private const double FONTSIZERICHTEXT = 14.0;
    }
}
