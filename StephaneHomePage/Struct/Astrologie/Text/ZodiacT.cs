using StephaneHomePage.Struct.Astrologie.Text.ContentText;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Struct.Astrologie.Text
{
    public class ZodiacT
    {
        public string Sign { get; set; }
        public List<Content> Content { get; set; } 
        public ZodiacT(string sign, List<Content> content)
        {
            Sign = sign;
            Content = content;
        }
    }
}
