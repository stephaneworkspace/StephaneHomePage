using StephaneHomePage.Data.Astrologie.ThemeAstral.Draw;
using StephaneHomePage.Data.Type;
using StephaneHomePage.Struct.Astrologie;
using StephaneHomePage.Struct.ImportJson;
using System.Collections.Generic;

namespace StephaneHomePage.Data.Astrologie.ThemeAstral
{
public class CalcHouse
{
    static List<House> _house = new List<House>();

    public void parseJson(List<ImportHouses> import)
    {
        // Fix warning CA1062
        if (import == null)
            import = new List<ImportHouses>();
        _house.Clear();
        foreach (var i in import)
        {
            _house.Add(new House(i.id, i.id_by_asc, i.sign, i.svg, i.pos_circle_360, new Offset(0.0, 0.0)));
        }
    }

#pragma warning disable CA1062
    public List<House> calcDrawHouse(CalcDraw calcDraw, double size)
    {
        List<House> z = new List<House>();
        // test null if file don't exist
        if (_house != null)
        {
            foreach (var i in _house)
            {
                // 0° -> to 0° next house
                // 0° -> to 0° next house
                double degreNext = 0.0;
                switch (i.Id)
                {
                case 12:
                    degreNext = _house[0].PosCircle360;
                    break;
                default:
                    degreNext = _house[i.Id].PosCircle360;
                    break;
                }
                double temp = 0.0;
                if (i.PosCircle360 > degreNext)
                {
                    temp = 360.0 + degreNext - i.PosCircle360;
                }
                else
                {
                    temp = degreNext - i.PosCircle360;
                }
                double degreMid = i.PosCircle360 + (temp / 2);
                if (degreMid > 360.0)
                {
                    degreMid -= 360.0;
                }
                Offset xy = calcDraw.getOffsetCenterHouse(size, calcDraw.pointTrigo(degreMid, calcDraw.getRadiusCircleHouse()));
                z.Add(new House(i.Id, i.IdByAsc, i.Sign, i.Svg, i.PosCircle360, xy));
            }
        }
        return z;
    }
}
#pragma warning restore CA1062
}
