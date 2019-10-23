using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Struct.Layout
{
    public class AppBarStruct
    {
        public string Title { get; set; }
        public bool ShowSwAstroZoom { get; set; }
        public int AstroZoom { get; set; }


        /// <summary>
        /// Structur for AppBar
        /// </summary>
        /// <param name="text">Title of the nav bar</param>
        /// <param name="swAstroZoom">Switch if display zoom</param>
        public AppBarStruct(string title, bool showSwAstroZoom, int astroZoom)
        {
            Title = title;
            ShowSwAstroZoom = showSwAstroZoom;
            AstroZoom = astroZoom;
        }
    }
}
