using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Struct.Astrologie.Text.Content
{
    public class ContentTextRich
    {
        public string Text { get; set; }
        public FontStyle FontStyle { get; set; }
        public FontWeight FontWeight { get; set; }
        
        public ContentTextRich(string text, FontStyle fontStyle, FontWeight fontWeight)
        {
            Text = text;
            FontStyle = fontStyle;
            FontWeight = fontWeight;
        }
    }
}
