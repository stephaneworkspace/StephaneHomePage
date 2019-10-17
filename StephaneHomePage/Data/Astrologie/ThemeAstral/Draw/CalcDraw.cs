using StephaneHomePage.Data.Type;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Data.Astrologie.ThemeAstral.Draw
{
    public class CalcDraw
    {
        const double CIRC = 360.0;

        const double CIRCLE0 = 35;
        const double CIRCLE1 = 62;
        const double CIRCLE2 = 67;
        const double CIRCLE3INVISIBLE = 75;
        const double CIRCLE4INVISIBLE = 80;
        const double CIRCLE5INVISIBLE = 87;
        const double CIRCLE6INVISIBLE = 94;

        const double DIVTRAITPETIT = 0.1;
        const double DIVTRAITGRAND = 0.2;

        const double DIVTRAITPOINTER = 1.5;

        static double _sizeMinWorkingCanvasWidthHeight;
        static double _sizeMediaHeight;

        public CalcDraw(double mediaSizeWidth, double mediaSizeHeight)
        {
            _sizeMinWorkingCanvasWidthHeight = Math.Min(mediaSizeWidth, mediaSizeHeight);
            _sizeMediaHeight = mediaSizeHeight;
        }

        /// Size (Width Max - Height Max) -> The min value for draw the main content
        double getSizeWH()
        {
            return _sizeMinWorkingCanvasWidthHeight;
        }

        double getRadiusTotal()
        {
            //_radiusTotal = min(size.width / 2, size.height / 2);
            return getSizeWH() / 2;
        }

        public double getRadiusCircle(int i)
        {
            switch (i)
            {
                case 0:
                    return (getRadiusTotal() * CIRCLE0) / 100;
                case 1:
                    return (getRadiusTotal() * CIRCLE1) / 100;
                case 2:
                    return (getRadiusTotal() * CIRCLE2) / 100;
                case 3:
                    return (getRadiusTotal() * CIRCLE3INVISIBLE) / 100; // For planet (no circle, outside of circle)
                case 4:
                    return (getRadiusTotal() * CIRCLE4INVISIBLE) / 100; // For planet (no circle, outside of circle)
                case 5:
                    return (getRadiusTotal() * CIRCLE5INVISIBLE) / 100;
                case 6:
                    return (getRadiusTotal() * CIRCLE6INVISIBLE) / 100;
                default:
                    return getRadiusTotal();
            }
        }

        public double getRadiusCircleZodiac()
        {
            return (getRadiusTotal() * (((CIRCLE1 - CIRCLE0) / (2.0 + DIVTRAITGRAND)) + CIRCLE0)) / 100;
        }

        public double getRadiusCircleHouse()
        {
            return (getRadiusTotal() * (((CIRCLE2 - CIRCLE1) / 2.0) + CIRCLE1)) / 100;
        }

        public double getRadiusCircleZodiacCIRCLE1WithoutLine()
        {
            return getRadiusRulesInsideCircleZodiac(TypeTrait.Grand);
        }

        public double getRadiusCircleHouseCIRCLE2WithoutLine()
        {
            return (getRadiusTotal() * ((CIRCLE2 - CIRCLE1) + CIRCLE0)) / 100; // - CIRCLE2
        }

        public double getRadiusCirclePlanetCIRCLE3INVISIBLEWithoutLine()
        {
            return (getRadiusTotal() * ((CIRCLE3INVISIBLE - CIRCLE2) + CIRCLE0)) / 100; // - CIRCLE3INVISIBLE
        }

        public double getRadiusCirclePlanetCIRCLE4INVISIBLEWithoutLine()
        {
            return (getRadiusTotal() * ((CIRCLE4INVISIBLE - CIRCLE3INVISIBLE) + CIRCLE0)) / 100; // - CIRCLE4INVISIBLE
        }

        public double getRadiusCirclePlanetCIRCLE5INVISIBLEWithoutLine()
        {
            return (getRadiusTotal() * ((CIRCLE5INVISIBLE - CIRCLE4INVISIBLE) + CIRCLE0)) / 100; // - CIRCLE5INVISIBLE for °
        }

        public double getRadiusCirclePlanetCIRCLE6INVISIBLEWithoutLine()
        {
            return (getRadiusTotal() * ((CIRCLE6INVISIBLE - CIRCLE5INVISIBLE) + CIRCLE0)) / 100; // - CIRCLE5INVISIBLE for '
        }

        double getRadiusRulesInsideCircleZodiac(TypeTrait typeTrait)
        {
            double divTrait = 0.0;
            switch (typeTrait)
            {
                case TypeTrait.Petit:
                    divTrait = 1.0 + DIVTRAITPETIT;
                    break;
                case TypeTrait.Grand:
                    divTrait = 1.0 + DIVTRAITGRAND;
                    break;
            }
            return (getRadiusTotal() * (((CIRCLE1 - CIRCLE0) / divTrait) + CIRCLE0)) / 100; // - CIRCLE1
        }

        /// Bottom of Pointer
        ///     ..
        ///    /  \
        ///     II
        ///     II
        ///    HERE
        double getRadiusRulesInsideCircleHouseForPointerBottom()
        {
            return (getRadiusTotal() * (((CIRCLE2 - CIRCLE1) / DIVTRAITPOINTER) - CIRCLE2)) / 100; // - CIRCLE2
        }

        /// Top of Pointer
        ///    HERE
        ///    /  \
        ///     II
        ///     II
        double getRadiusRulesInsideCircleHouseForPointerTop()
        {
            return (getRadiusTotal() * ((CIRCLE2 - CIRCLE1) - CIRCLE2)) / 100; // - CIRCLE2
        }

        Offset getCenter()
        {
            //return new Offset(size.width / 2, size.height / 2);
            return new Offset(getRadiusTotal(), getRadiusTotal());
        }

        // Theorem Pythagoras => Distance between 2 offset
        public double sizeZodiac(Offset xy1, Offset xy2)
        {
            double a = xy1.dx - xy2.dx;
            double b = xy1.dy - xy2.dy;
            return Math.Sqrt(a * a + b * b);
        }

        // Theorem Pythagoras => Distance between 2 offset
        public double sizeHouse(Offset xy1, Offset xy2)
        {
            double a = xy1.dx - xy2.dx;
            double b = xy1.dy - xy2.dy;
            return Math.Sqrt(a * a + b * b);
        }

        // Theorem Pythagoras => Distance between 2 offset
        public double sizePlanet(Offset xy1, Offset xy2)
        {
            double a = xy1.dx - xy2.dx;
            double b = xy1.dy - xy2.dy;
            return Math.Sqrt(a * a + b * b);
        }

        // Theorem Pythagoras => Distance between 2 offset
        public double sizeAngle(Offset xy1, Offset xy2)
        {
            double a = xy1.dx - xy2.dx;
            double b = xy1.dy - xy2.dy;
            return Math.Sqrt(a * a + b * b);
        }

        /// Center for the svg zodiac
        /// 
        /// 0.0 - 0.0 = top left of the screen
        /// so this method is a helper for find the position of the sign
        public Offset getOffsetCenterZodiac(double sizeZodiac, Offset xy00)
        {
            return new Offset(xy00.dx - (sizeZodiac / 2), xy00.dy - (sizeZodiac / 2));
        }

        /// Center for the text house
        public Offset getOffsetCenterHouse(double sizeHouse, Offset xy00)
        {
            return new Offset(xy00.dx - (sizeHouse / 2), xy00.dy - (sizeHouse / 2));
        }

        public Offset getOffsetCenterPlanet(double sizePlanet, Offset xy00)
        {
            return new Offset(xy00.dx - (sizePlanet / 2), xy00.dy - (sizePlanet / 2));
        }

        // Trigonometry
        public List<Offset> lineTrigo(double angular, double radiusCircleBegin, double radiusCircleEnd)
        {
            List<Offset> returnList = new List<Offset>();
            double dx1 = getCenter().dx + Math.Cos(angular / CIRC * 2 * Math.PI) * -1 * new Radius(radiusCircleBegin).x;
            double dy1 = getCenter().dy + Math.Sin(angular / CIRC * 2 * Math.PI) * new Radius(radiusCircleBegin).y;
            returnList.Add(new Offset(dx1, dy1));
            double dx2 = getCenter().dx + Math.Cos(angular / CIRC * 2 * Math.PI) * -1 * new Radius(radiusCircleEnd).x;
            double dy2 = getCenter().dy + Math.Sin(angular / CIRC * 2 * Math.PI) * new Radius(radiusCircleEnd).y;
            returnList.Add(new Offset(dx2, dy2));
            return returnList;
        }

        // Trigonometry
        public Offset pointTrigo(double angular, double radiusCircle)
        {
            double dx = getCenter().dx + Math.Cos(angular / CIRC * 2 * Math.PI) * -1 * new Radius(radiusCircle).x;
            double dy = getCenter().dy + Math.Sin(angular / CIRC * 2 * Math.PI) * new Radius(radiusCircle).y;
            return new Offset(dx, dy);
        }

        // Not return radiusCircleEnd
        public List<Offset> pathTrianglePointer(double angular, double angularPointer, double radiusCircleBegin, double radiusCircleEnd)
        {
            List<Offset> returnList = new List<Offset>();
            double angular1 = angular - angularPointer;
            if (angular1 > 360)
            {
                angular1 -= 360;
            }
            double angular2 = angular + angularPointer;
            if (angular2 > 360)
            {
                angular2 -= 360;
            }
            double dx1 = getCenter().dx + Math.Cos(angular1 / CIRC * 2 * Math.PI) * -1 * new Radius(radiusCircleBegin).x;
            double dy1 = getCenter().dy + Math.Sin(angular1 / CIRC * 2 * Math.PI) * new Radius(radiusCircleBegin).y;
            returnList.Add(new Offset(dx1, dy1));
            double dx2 = getCenter().dx + Math.Cos(angular2 / CIRC * 2 * Math.PI) * -1 * new Radius(radiusCircleBegin).x;
            double dy2 = getCenter().dy + Math.Sin(angular2 / CIRC * 2 * Math.PI) * new Radius(radiusCircleBegin).y;
            returnList.Add(new Offset(dx2, dy2));
            double dx3 = getCenter().dx + Math.Cos(angular / CIRC * 2 * Math.PI) * -1 * new Radius(radiusCircleEnd).x;
            double dy3 = getCenter().dy + Math.Sin(angular / CIRC * 2 * Math.PI) * new Radius(radiusCircleEnd).y;
            returnList.Add(new Offset(dx3, dy3));
            return returnList;
        }
    }
}
