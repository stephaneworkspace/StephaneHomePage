using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using StephaneHomePage.Data.Astrologie.ThemeAstral.Draw;
using StephaneHomePage.Data.Astrologie.ThemeAstral.Text;
using StephaneHomePage.Data.Type;
using StephaneHomePage.Struct.Astrologie;
using StephaneHomePage.Struct.Astrologie.Text;
using StephaneHomePage.Struct.ImportJson;

namespace StephaneHomePage.Data.Astrologie.ThemeAstral
{
    public class CalcZodiacText
    {
        private List<ZodiacT> _zodiacText = new List<ZodiacT>();

        public List<ZodiacT> parseJson(List<ImportZodiacText> import)
        {
            _zodiacText.Clear();
            foreach (var i in import)
            {
                CalcContent c = new CalcContent();
                ZodiacT zt = new ZodiacT(i.sign, c.makeContent(i.content));
                _zodiacText.Add(zt);
            }
            return _zodiacText;
        }
    }
}