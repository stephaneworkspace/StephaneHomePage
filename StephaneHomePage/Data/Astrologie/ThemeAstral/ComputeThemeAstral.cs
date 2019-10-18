using StephaneHomePage.Data.Astrologie.ThemeAstral.Draw;
using StephaneHomePage.Data.Type;
using StephaneHomePage.Struct.Astrologie;
using StephaneHomePage.Struct.ImportJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Data.Astrologie.ThemeAstral
{
    public class ComputeThemeAstral
    {
        const double EXT0 = 30.0;
        const double EXT1 = 40.0;
        const double EXT2 = 90.0;
        const double EXT3 = 130.0;

        public CalcZodiac CalcZodiac;
        public List<Zodiac> Zodiac;
        public CalcHouse CalcHouse;
        public List<House> House;
        public CalcAngle CalcAngle;
        public List<Angle> Angle;
        public CalcPlanet CalcPlanet;
        public List<Planet> Planet;
        public List<Offset> XYZodiacSizeLine; // size between 2 circle by point on 0° for the size of zodiac
        public List<Offset> XYHouseSizeLine;
        public List<Offset> XYAngleSizeLine;
        public List<Offset> XYAngleDegSizeLine;
        public List<Offset> XYAngleMinSizeLine;
        public List<Offset> XYPlanetSizeLine;
        public List<Offset> XYPlanetDegSizeLine;
        public List<Offset> XYPlanetMinSizeLine;
       
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

            double whZodiacSize; // size zodiac by the line between 2 circle
            double whHouseSize;
            double whAngleSymbolSize;
            double whAngleDegSymbolSize;
            double whAngleMinSymbolSize;
            double whPlanetSymbolSize;
            double whPlanetDegSymbolSize;
            double whPlanetMinSymbolSize;

            CalcDraw calcDraw = new CalcDraw(maxWidth, maxHeight);
            // At °0, no importance, ist juste for have the size of zodiac container care
            XYZodiacSizeLine = calcDraw.lineTrigo(0, calcDraw.getRadiusCircleZodiacCIRCLE1WithoutLine(), calcDraw.getRadiusCircle(0));
            whZodiacSize = calcDraw.sizeZodiac(XYZodiacSizeLine[0], XYZodiacSizeLine[1]);
            whZodiacSize = (whZodiacSize * 50) / 100;
            Zodiac = CalcZodiac.calcDrawZodiac(calcDraw, whZodiacSize);

            XYHouseSizeLine = calcDraw.lineTrigo(0, calcDraw.getRadiusCircleHouseCIRCLE2WithoutLine(), calcDraw.getRadiusCircle(0));
            whHouseSize = calcDraw.sizeHouse(XYHouseSizeLine[0], XYHouseSizeLine[1]);
            whHouseSize = (whHouseSize * 70) / 100;
            House = CalcHouse.calcDrawHouse(calcDraw, whHouseSize);

            XYAngleSizeLine = calcDraw.lineTrigo(0, calcDraw.getRadiusCirclePlanetCIRCLE4INVISIBLEWithoutLine(), calcDraw.getRadiusCircle(0));
            whAngleSymbolSize = calcDraw.sizePlanet(XYAngleSizeLine[0], XYAngleSizeLine[1]);
            whAngleSymbolSize = (whAngleSymbolSize * 150) / 100;
            XYAngleDegSizeLine = calcDraw.lineTrigo(0, calcDraw.getRadiusCirclePlanetCIRCLE5INVISIBLEWithoutLine(), calcDraw.getRadiusCircle(0));
            whAngleDegSymbolSize = calcDraw.sizeAngle(XYAngleDegSizeLine[0], XYAngleDegSizeLine[1]);
            whAngleDegSymbolSize = (whAngleDegSymbolSize * 110) / 100;
            XYAngleMinSizeLine = calcDraw.lineTrigo(0, calcDraw.getRadiusCirclePlanetCIRCLE6INVISIBLEWithoutLine(), calcDraw.getRadiusCircle(0));
            whAngleMinSymbolSize = calcDraw.sizeAngle(XYAngleMinSizeLine[0], XYAngleMinSizeLine[1]);
            whAngleMinSymbolSize = (whAngleMinSymbolSize * 80) / 100;
            Angle = CalcAngle.calcDrawAngle(calcDraw, whAngleSymbolSize, whAngleDegSymbolSize, whAngleMinSymbolSize); // todo angle size for outside circle

            XYPlanetSizeLine = calcDraw.lineTrigo(0, calcDraw.getRadiusCirclePlanetCIRCLE4INVISIBLEWithoutLine(), calcDraw.getRadiusCircle(0));
            whPlanetSymbolSize = calcDraw.sizePlanet(XYPlanetSizeLine[0], XYPlanetSizeLine[1]);
            whPlanetSymbolSize = (whPlanetSymbolSize * 150) / 100;
            XYPlanetDegSizeLine = calcDraw.lineTrigo(0, calcDraw.getRadiusCirclePlanetCIRCLE5INVISIBLEWithoutLine(), calcDraw.getRadiusCircle(0));
            whPlanetDegSymbolSize = calcDraw.sizePlanet(XYPlanetDegSizeLine[0], XYPlanetDegSizeLine[1]);
            whPlanetDegSymbolSize = (whPlanetDegSymbolSize * 110) / 100;
            XYPlanetMinSizeLine = calcDraw.lineTrigo(0, calcDraw.getRadiusCirclePlanetCIRCLE6INVISIBLEWithoutLine(), calcDraw.getRadiusCircle(0));
            whPlanetMinSymbolSize = calcDraw.sizeAngle(XYPlanetMinSizeLine[0], XYPlanetMinSizeLine[1]);
            whPlanetMinSymbolSize = (whPlanetMinSymbolSize * 80) / 100;
            Planet = CalcPlanet.calcDrawPlanet(calcDraw, whPlanetSymbolSize, whPlanetDegSymbolSize, whPlanetMinSymbolSize);
        }
    }
}
