using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Struct.Astrologie.Text.Content
{
    public class ContentTitle
    {
        public string Text { get; set; }
        public double FontSize { get; set; }
        
        public ContentTitle(string text, double fontSize)
        {
            Text = text;
            FontSize = fontSize;
        }
    }
}
