using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Struct.ImportJson
{
    public class ImportJson
    {
        public List<Angles> angles { get; set; }
        public List<Houses> houses { get; set; }
        public List<Planets> planets { get; set; }
        public List<Zodiac> zodiac { get; set; }
        public List<ZodiacText> zodiac_text { get; set; }
    }
}
