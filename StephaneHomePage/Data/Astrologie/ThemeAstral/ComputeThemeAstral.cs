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
        this.CalcZodiac = new CalcZodiac();
        this.Zodiac = new List<Zodiac>();
        this.CalcHouse = new CalcHouse();
        this.House = new List<House>();
        this.CalcAngle = new CalcAngle();
        this.Angle = new List<Angle>();
        this.CalcPlanet = new CalcPlanet();
        this.Planet = new List<Planet>();
        this.CalcZodiac.parseJson(json.zodiac);
        this.CalcHouse.parseJson(json.houses);
        this.CalcAngle.parseJson(json.angles);
        this.CalcPlanet.parseJson(json.planets);

        this.CalcDraw = new CalcDraw(maxWidth, maxHeight);
        // At °0, no importance, ist juste for have the size of zodiac container care
        this.XYZodiacSizeLine = this.CalcDraw.lineTrigo(0, this.CalcDraw.getRadiusCircleZodiacCIRCLE1WithoutLine(), this.CalcDraw.getRadiusCircle(0));
        this.whZodiacSize = this.CalcDraw.sizeZodiac(this.XYZodiacSizeLine[0], this.XYZodiacSizeLine[1]);
        this.whZodiacSize = (this.whZodiacSize * 50) / 100;
        this.Zodiac = this.CalcZodiac.calcDrawZodiac(this.CalcDraw, this.whZodiacSize);

        this.XYHouseSizeLine = this.CalcDraw.lineTrigo(0, this.CalcDraw.getRadiusCircleHouseCIRCLE2WithoutLine(), this.CalcDraw.getRadiusCircle(0));
        this.whHouseSize = this.CalcDraw.sizeHouse(this.XYHouseSizeLine[0], this.XYHouseSizeLine[1]);
        this.whHouseSize = (this.whHouseSize * 70) / 100;
        this.House = this.CalcHouse.calcDrawHouse(this.CalcDraw, this.whHouseSize);

        this.XYAngleSizeLine = this.CalcDraw.lineTrigo(0, this.CalcDraw.getRadiusCirclePlanetCIRCLE4INVISIBLEWithoutLine(), this.CalcDraw.getRadiusCircle(0));
        this.whAngleSymbolSize = this.CalcDraw.sizePlanet(this.XYAngleSizeLine[0], this.XYAngleSizeLine[1]);
        this.whAngleSymbolSize = (this.whAngleSymbolSize * 150) / 100;
        this.XYAngleDegSizeLine = this.CalcDraw.lineTrigo(0, this.CalcDraw.getRadiusCirclePlanetCIRCLE5INVISIBLEWithoutLine(), this.CalcDraw.getRadiusCircle(0));
        this.whAngleDegSymbolSize = this.CalcDraw.sizeAngle(this.XYAngleDegSizeLine[0], this.XYAngleDegSizeLine[1]);
        this.whAngleDegSymbolSize = (this.whAngleDegSymbolSize * 110) / 100;
        this.XYAngleMinSizeLine = this.CalcDraw.lineTrigo(0, this.CalcDraw.getRadiusCirclePlanetCIRCLE6INVISIBLEWithoutLine(), this.CalcDraw.getRadiusCircle(0));
        this.whAngleMinSymbolSize = this.CalcDraw.sizeAngle(this.XYAngleMinSizeLine[0], this.XYAngleMinSizeLine[1]);
        this.whAngleMinSymbolSize = (this.whAngleMinSymbolSize * 80) / 100;
        this.Angle = this.CalcAngle.calcDrawAngle(this.CalcDraw, this.whAngleSymbolSize, this.whAngleDegSymbolSize, this.whAngleMinSymbolSize); // todo angle size for outside circle

        this.XYPlanetSizeLine = this.CalcDraw.lineTrigo(0, this.CalcDraw.getRadiusCirclePlanetCIRCLE4INVISIBLEWithoutLine(), this.CalcDraw.getRadiusCircle(0));
        this.whPlanetSymbolSize = this.CalcDraw.sizePlanet(this.XYPlanetSizeLine[0], this.XYPlanetSizeLine[1]);
        this.whPlanetSymbolSize = (this.whPlanetSymbolSize * 150) / 100;
        this.XYPlanetDegSizeLine = this.CalcDraw.lineTrigo(0, this.CalcDraw.getRadiusCirclePlanetCIRCLE5INVISIBLEWithoutLine(), this.CalcDraw.getRadiusCircle(0));
        this.whPlanetDegSymbolSize = this.CalcDraw.sizePlanet(this.XYPlanetDegSizeLine[0], this.XYPlanetDegSizeLine[1]);
        this.whPlanetDegSymbolSize = (this.whPlanetDegSymbolSize * 110) / 100;
        this.XYPlanetMinSizeLine = this.CalcDraw.lineTrigo(0, this.CalcDraw.getRadiusCirclePlanetCIRCLE6INVISIBLEWithoutLine(), this.CalcDraw.getRadiusCircle(0));
        this.whPlanetMinSymbolSize = this.CalcDraw.sizeAngle(this.XYPlanetMinSizeLine[0], this.XYPlanetMinSizeLine[1]);
        this.whPlanetMinSymbolSize = (this.whPlanetMinSymbolSize * 80) / 100;
        this.Planet = this.CalcPlanet.calcDrawPlanet(this.CalcDraw, this.whPlanetSymbolSize, this.whPlanetDegSymbolSize, this.whPlanetMinSymbolSize);

        // Compute text
        this.CalcZodiactText = new CalcZodiacText();
        this.ZodiacT = new List<ZodiacT>();
        this.ZodiacT = this.CalcZodiactText.parseJson(json.zodiac_text);
    }
}
}
