using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using StephaneHomePage.Data.Astrologie.ThemeAstral.Draw;
using StephaneHomePage.Data.Type;
using StephaneHomePage.Struct.Astrologie;
using StephaneHomePage.Struct.ImportJson;

namespace StephaneHomePage.Data.Astrologie.ThemeAstral
{
    public class CalcZodiac
    {
        static List<Zodiac> _zodiac = new List<Zodiac>();

        public void parseJson(List<ImportZodiac> import)
        {
            _zodiac.Clear();
            foreach (var i in import)
            {
                Color color = Color.Black;
                switch (i.element)
                {
                    case "Feu":
                        color = Color.Red;
                        break;
                    case "Terre":
                        color = Color.Orange;
                        break;
                    case "Air":
                        color = Color.Green;
                        break;
                    case "Eau":
                        color = Color.Blue;
                        break;
                }
                _zodiac.Add(new Zodiac(i.id, i.id_by_asc, i.symbol, new El(i.element, color), i.sign, i.svg, i.pos_circle_360, new Offset(0.0, 0.0)));
            }
        }


        public List<Zodiac> calcDrawZodiac(CalcDraw calcDraw, double size)
        {
            List<Zodiac> z = new List<Zodiac>();
            // test null if file don't exist
            if (_zodiac != null)
            {
                 foreach (var i in _zodiac)
                 {
                    // 0° + 15°
                    double degre15 = i.PosCircle360 + 15.0;
                    if (degre15 > 360.0)
                    {
                        degre15 -= 360.0;
                    }
                    Offset xy = calcDraw.getOffsetCenterZodiac(size, calcDraw.pointTrigo(degre15, calcDraw.getRadiusCircleZodiac()));
                    z.Add(new Zodiac(i.Id, i.IdByAsc, i.Symbol, i.Element, i.Sign, i.Svg, i.PosCircle360, xy));
                 }
            }
            return z;
        }
    }
}