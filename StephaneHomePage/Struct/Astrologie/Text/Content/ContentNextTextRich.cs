using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Struct.Astrologie.Text.Content
{
    public class ContentNextTextRich
    {
        public FontStyle FontStyle { get; set; }
        public FontWeight FontWeight { get; set; }
        public int NextPos { get; set; }
        public string Content { get; set; }
        public ContentNextTextRich(FontStyle fontStyle, FontWeight fontWeight, int nextPos, string content)
        {
            FontStyle = fontStyle;
            FontWeight = fontWeight;
            NextPos = nextPos;
            Content = content;
        }
    }
}
