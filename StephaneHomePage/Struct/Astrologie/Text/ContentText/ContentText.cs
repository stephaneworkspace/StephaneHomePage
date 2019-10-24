using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Struct.Astrologie.Text.ContentText
{
    public class ContentText
    {
        public IEnumerable<ContentTextRich> RichText { get; set; }
        public ContentText(List<ContentTextRich> richText)
        {
            RichText = richText;
        }
    }
}
