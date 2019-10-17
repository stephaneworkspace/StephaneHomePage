using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Struct.ImportJson
{
    public class ImportJson
    {
        public List<ImportAngles> angles { get; set; }
        public List<ImportHouses> houses { get; set; }
        public List<ImportPlanets> planets { get; set; }
        public List<ImportZodiac> zodiac { get; set; }
        public List<ImportZodiacText> zodiac_text { get; set; }
    }
}
