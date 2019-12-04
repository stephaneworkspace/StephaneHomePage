using StephaneHomePage.Data.Astrologie.ThemeAstral.Draw;
using StephaneHomePage.Data.Type;
using StephaneHomePage.Struct.Astrologie;
using StephaneHomePage.Struct.Astrologie.Text;
using StephaneHomePage.Struct.ImportJson;
using System.Collections.Generic;

namespace StephaneHomePage.Data.Astrologie.ThemeAstral
{
public class ComputeThemeAstral
{
    const double EXT0 = 30.0;
    const double EXT1 = 40.0;
    const double EXT2 = 90.0;
    const double EXT3 = 130.0;

    public CalcZodiac CalcZodiac
    {
        get;
        set;
    }
#pragma warning disable CA2227
    public List<Zodiac> Zodiac
    {
        get;
        set;
    }
#pragma warning restore CA2227
    public CalcHouse CalcHouse
    {
        get;
        set;
    }
#pragma warning disable CA2227
    public List<House> House
    {
        get;
        set;
    }
#pragma warning restore CA2227
    public CalcAngle CalcAngle
    {
        get;
        set;
    }
#pragma warning disable CA2227
    public List<Angle> Angle
    {
        get;
        set;
    }
    public CalcPlanet CalcPlanet
    {
        get;
        set;
    }
    public List<Planet> Planet
    {
        get;
        set;
    }
    public List<Offset> XYZodiacSizeLine
    {
        get; // size between 2 circle by point on 0+ for the size of zodiac
        set;
    }
    public List<Offset> XYHouseSizeLine
    {
        get;
        set;
    }
    public List<Offset> XYAngleSizeLine
    {
        get;
        set;
    }
    public List<Offset> XYAngleDegSizeLine
    {
        get;
        set;
    }
    public List<Offset> XYAngleMinSizeLine
    {
        get;
        set;
    }
    public List<Offset> XYPlanetSizeLine
    {
        get;
        set;
    }
    public List<Offset> XYPlanetDegSizeLine
    {
        get;
        set;
    }
    public List<Offset> XYPlanetMinSizeLine
    {
        get;
        set;
    }
#pragma warning restore CA2227
    public CalcDraw CalcDraw
    {
        get;
        set;
    }

    public double whZodiacSize
    {
        get;    // size zodiac by the
        set;
    }
    // line between 2 circle
    public double whHouseSize
    {
        get;
        set;
    }
    public double whAngleSymbolSize
    {
        get;
        set;
    }
    public double whAngleDegSymbolSize
    {
        get;
        set;
    }
    public double whAngleMinSymbolSize
    {
        get;
        set;
    }
    public double whPlanetSymbolSize
    {
        get;
        set;
    }
    public double whPlanetDegSymbolSize
    {
        get;
        set;
    }
    public double whPlanetMinSymbolSize
    {
        get;
        set;
    }

    // Text
    public CalcZodiacText CalcZodiactText
    {
        get;
        set;
    }
#pragma warning disable CA2227
    public List<ZodiacT> ZodiacT
    {
        get;
        set;
    }
#pragma warning restore CA2227

    public ComputeThemeAstral(ImportJson json, double maxWidth, double maxHeight)
    {
        CalcZodiac = new CalcZodiac();
        Zodiac = new List<Zodiac>();
        CalcHouse = new CalcHouse();
        House = new List<House>();
        CalcAngle = new CalcAngle();
        Angle = new List<Angle>();
        CalcPlanet = new CalcPlanet();
        Planet = new List<Planet>();
        CalcZodiac.parseJson(json.zodiac);
        CalcHouse.parseJson(json.houses);
        CalcAngle.parseJson(json.angles);
        CalcPlanet.parseJson(json.planets);

        CalcDraw = new CalcDraw(maxWidth, maxHeight);
        // At °0, no importance, ist juste for have the size of zodiac container care
        XYZodiacSizeLine = CalcDraw.lineTrigo(0, CalcDraw.getRadiusCircleZodiacCIRCLE1WithoutLine(), CalcDraw.getRadiusCircle(0));
        whZodiacSize = CalcDraw.sizeZodiac(XYZodiacSizeLine[0], XYZodiacSizeLine[1]);
        whZodiacSize = (whZodiacSize * 50) / 100;
        Zodiac = CalcZodiac.calcDrawZodiac(CalcDraw, whZodiacSize);

        XYHouseSizeLine = CalcDraw.lineTrigo(0, CalcDraw.getRadiusCircleHouseCIRCLE2WithoutLine(), CalcDraw.getRadiusCircle(0));
        whHouseSize = CalcDraw.sizeHouse(XYHouseSizeLine[0], XYHouseSizeLine[1]);
        whHouseSize = (whHouseSize * 70) / 100;
        House = CalcHouse.calcDrawHouse(CalcDraw, whHouseSize);

        XYAngleSizeLine = CalcDraw.lineTrigo(0, CalcDraw.getRadiusCirclePlanetCIRCLE4INVISIBLEWithoutLine(), CalcDraw.getRadiusCircle(0));
        whAngleSymbolSize = CalcDraw.sizePlanet(XYAngleSizeLine[0], XYAngleSizeLine[1]);
        whAngleSymbolSize = (whAngleSymbolSize * 150) / 100;
        XYAngleDegSizeLine = CalcDraw.lineTrigo(0, CalcDraw.getRadiusCirclePlanetCIRCLE5INVISIBLEWithoutLine(), CalcDraw.getRadiusCircle(0));
        whAngleDegSymbolSize = CalcDraw.sizeAngle(XYAngleDegSizeLine[0], XYAngleDegSizeLine[1]);
        whAngleDegSymbolSize = (whAngleDegSymbolSize * 110) / 100;
        XYAngleMinSizeLine = CalcDraw.lineTrigo(0, CalcDraw.getRadiusCirclePlanetCIRCLE6INVISIBLEWithoutLine(), CalcDraw.getRadiusCircle(0));
        whAngleMinSymbolSize = CalcDraw.sizeAngle(XYAngleMinSizeLine[0], XYAngleMinSizeLine[1]);
        whAngleMinSymbolSize = (whAngleMinSymbolSize * 80) / 100;
        Angle = CalcAngle.calcDrawAngle(CalcDraw, whAngleSymbolSize, whAngleDegSymbolSize, whAngleMinSymbolSize); // todo angle size for outside circle

        XYPlanetSizeLine = CalcDraw.lineTrigo(0, CalcDraw.getRadiusCirclePlanetCIRCLE4INVISIBLEWithoutLine(), CalcDraw.getRadiusCircle(0));
        whPlanetSymbolSize = CalcDraw.sizePlanet(XYPlanetSizeLine[0], XYPlanetSizeLine[1]);
        whPlanetSymbolSize = (whPlanetSymbolSize * 150) / 100;
        XYPlanetDegSizeLine = CalcDraw.lineTrigo(0, CalcDraw.getRadiusCirclePlanetCIRCLE5INVISIBLEWithoutLine(), CalcDraw.getRadiusCircle(0));
        whPlanetDegSymbolSize = CalcDraw.sizePlanet(XYPlanetDegSizeLine[0], XYPlanetDegSizeLine[1]);
        whPlanetDegSymbolSize = (whPlanetDegSymbolSize * 110) / 100;
        XYPlanetMinSizeLine = CalcDraw.lineTrigo(0, CalcDraw.getRadiusCirclePlanetCIRCLE6INVISIBLEWithoutLine(), CalcDraw.getRadiusCircle(0));
        whPlanetMinSymbolSize = CalcDraw.sizeAngle(XYPlanetMinSizeLine[0], XYPlanetMinSizeLine[1]);
        whPlanetMinSymbolSize = (whPlanetMinSymbolSize * 80) / 100;
        Planet = CalcPlanet.calcDrawPlanet(CalcDraw, whPlanetSymbolSize, whPlanetDegSymbolSize, whPlanetMinSymbolSize);

        // Compute text

        CalcZodiactText = new CalcZodiacText();
        ZodiacT = new List<ZodiacT>();
        ZodiacT = CalcZodiactText.parseJson(json.zodiac_text);
    }
}
}
