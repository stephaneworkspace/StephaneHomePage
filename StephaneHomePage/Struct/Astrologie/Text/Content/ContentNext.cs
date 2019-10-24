using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Struct.Astrologie.Text.Content
{
    public class ContentNext
    {
        public TypeContent Type { get; set; }
        public int NextPos { get; set; }
        public string Content { get; set; }
        
        public ContentNext(TypeContent type, int nextPos,string content)
        {
            Type = type;
            NextPos = nextPos;
            Content = content;
        }
    }
}
