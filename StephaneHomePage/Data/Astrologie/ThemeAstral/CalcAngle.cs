using StephaneHomePage.Data.Astrologie.ThemeAstral.Draw;
using StephaneHomePage.Data.Type;
using StephaneHomePage.Struct.Astrologie;
using StephaneHomePage.Struct.ImportJson;
using System.Collections.Generic;
using System.Drawing;

namespace StephaneHomePage.Data.Astrologie.ThemeAstral
{
public class CalcAngle
{
    static List<Angle> _angle = new List<Angle>();

    public void parseJson(List<ImportAngles> import)
    {
        if (import == null)
        {
            import = new List<ImportAngles>();
        }
        _angle.Clear();
        // Order by Asc
        foreach (var i in import)
        {
            _angle.Add(new Angle(i.id, i.sign, i.sign_pos, i.svg, i.svg_degre, i.svg_min, i.pos_circle_360, new Offset(0.0, 0.0), new Offset(0.0, 0.0), new Offset(0.0, 0.0), ColorTranslator.FromHtml("#7c7459")));
        }
    }

    public List<Angle> calcDrawAngle(CalcDraw calcDraw, double sizeAngle, double sizeDegre, double sizeMin)
    {
        List<Angle> z = new List<Angle>();
        // test null if file don't exist
        if (_angle != null)
        {
            foreach (var i in _angle)
            {
                // 0° todo... colision detector
                Offset xy1 = calcDraw.getOffsetCenterPlanet(sizeAngle, calcDraw.pointTrigo(i.PosCircle360, calcDraw.getRadiusCircle(4))); // symbol
                Offset xy2 = calcDraw.getOffsetCenterPlanet(sizeDegre, calcDraw.pointTrigo(i.PosCircle360, calcDraw.getRadiusCircle(5))); // °
                Offset xy3 = calcDraw.getOffsetCenterPlanet(sizeDegre, calcDraw.pointTrigo(i.PosCircle360, calcDraw.getRadiusCircle(6))); // '
                z.Add(new Angle(i.Id, i.Sign, i.SignPos, i.Svg, i.SvgDegre, i.SvgMin, i.PosCircle360, xy1, xy2, xy3, i.Color));
            }
        }
        return z;
    }

}
}
