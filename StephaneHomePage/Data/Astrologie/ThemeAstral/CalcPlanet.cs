using StephaneHomePage.Data.Astrologie.ThemeAstral.Draw;
using StephaneHomePage.Data.Type;
using StephaneHomePage.Struct.Astrologie;
using StephaneHomePage.Struct.ImportJson;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Data.Astrologie.ThemeAstral
{
    public class CalcPlanet
    {
        static List<Planet> _angle = new List<Planet>();

        public void parseJson(List<ImportPlanets> import)
        {
            _angle.Clear();
            // Order by Asc
            foreach (var i in import)
            {
                Color c;
                c = ColorTranslator.FromHtml("#000000");
                switch (i.id)
                {
                    case "Soleil":
                        c = ColorTranslator.FromHtml("#d79a3f");
                        break;
                    case "Lune":
                        c = ColorTranslator.FromHtml("#a78500");
                        break;
                    case "Mercure":
                        c = ColorTranslator.FromHtml("#755175");
                        break;
                    case "Venus":
                        c = ColorTranslator.FromHtml("#c55d81");
                        break;
                    case "Mars":
                        c = ColorTranslator.FromHtml("#bd3036");
                        break;
                    case "Jupiter":
                        c = ColorTranslator.FromHtml("#478c89");
                        break;
                    case "Saturne":
                        c = ColorTranslator.FromHtml("#b44b45");
                        break;
                    case "Uranus":
                        c = ColorTranslator.FromHtml("#895349");
                        break;
                    case "Neptune":
                        c = ColorTranslator.FromHtml("#5e6d59");
                        break;
                    case "Pluton":
                        c = ColorTranslator.FromHtml("#db5053");
                        break;
                    case "Chiron":
                    case "Noeud nord":
                    case "Noeud sud":
                    case "Part de fortune":
                        c = ColorTranslator.FromHtml("#7c7459");
                        break;
                    //default:
                    //    c = ColorTranslator.FromHtml("#000000");
                }
                _angle.Add(new Planet(i.id, i.sign, i.sign_pos, i.svg, i.svg_degre, i.svg_min, i.pos_circle_360, new Offset(0.0, 0.0), new Offset(0.0, 0.0), new Offset(0.0, 0.0), c, i.movement, i.sw_movement_is_retrograde));
            }
        }

        public List<Planet> calcDrawPlanet(CalcDraw calcDraw, double sizePlanet, double sizeDegre, double sizeMin)
        {
            List<Planet> z = new List<Planet>();
            // test null if file don't exist
            if (_angle != null)
            {
                foreach (var i in _angle)
                {
                    // 0° todo... colision detector
                    Offset xy1 = calcDraw.getOffsetCenterPlanet(sizePlanet, calcDraw.pointTrigo(i.PosCircle360, calcDraw.getRadiusCircle(4))); // symbol
                    Offset xy2 = calcDraw.getOffsetCenterPlanet(sizeDegre, calcDraw.pointTrigo(i.PosCircle360, calcDraw.getRadiusCircle(5))); // °
                    Offset xy3 = calcDraw.getOffsetCenterPlanet(sizeMin, calcDraw.pointTrigo(i.PosCircle360, calcDraw.getRadiusCircle(6))); // '
                                                                                                                                            // todo, calc of position outside circle with text
                    z.Add(new Planet(i.Id, i.Sign, i.SignPos, i.Svg, i.SvgDegre, i.SvgMin, i.PosCircle360, xy1, xy2, xy3, i.Color, i.Movement, i.IsRetrograde));
                }
            }
            return z;
        }
    }
}