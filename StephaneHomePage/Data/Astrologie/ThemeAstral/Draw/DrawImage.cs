using StephaneHomePage.Data.Type;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StephaneHomePage.Data.Astrologie.ThemeAstral.Draw
{
    public class DrawImage
    {
        private ComputeThemeAstral Compute;

        public DrawImage(ComputeThemeAstral computeThemeAstral)
        {
            this.Compute = computeThemeAstral;
        }

        public String GetSvg(bool swMode)
        {
            string br = swMode ? Environment.NewLine : "\\n";
            int size = Convert.ToInt32(this.Compute.CalcDraw.getSizeWH());
            string s = "";
            s += "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"" + size + "\" height=\"" + size + "\">" + br;
            // Circle 1
            //s += "  <circle cx=\"250\" cy=\"250\" r=\"212.132\" stroke=\"black\" fill-opacity=\"0.0\"/>" + br;
            for (int i = 0; i <= 2; i++)
            {
                s += "  <circle cx=\""+ this.Compute.CalcDraw.getCenter().dx + "\" cy=\""+ this.Compute.CalcDraw.getCenter().dy + "\" r=\""+ this.Compute.CalcDraw.getRadiusCircle(i) + "\" stroke-width=\"1\" stroke=\"black\" fill-opacity=\"0.0\"/>" + br;
            }
            foreach (var i in this.Compute.Zodiac)
            {
                // 0°
                List<Offset> xy = this.Compute.CalcDraw.lineTrigo(i.PosCircle360, this.Compute.CalcDraw.getRadiusCircle(1), this.Compute.CalcDraw.getRadiusCircle(0));
                s += "  <line x1=\""+xy[0].dx+"\" y1=\""+xy[0].dy+"\" x2=\""+xy[1].dx+"\" y2=\""+xy[1].dy+ "\" stroke-width=\"1\" stroke=\"black\"/>";
                // 1° -> 29 °
                for (int j = 1; j < 15; j++)
                {
                    var typeTrait = TypeTrait.Petit;
                    if (j == 5 || j == 10 || j == 15)
                    {
                        typeTrait = TypeTrait.Grand;
                    }
                    // calc angular
                    double angular = i.PosCircle360 + j * 2.0;
                    if (angular > 360.0)
                    {
                        angular -= 360.0;
                    }
                    xy = this.Compute.CalcDraw.lineTrigo(angular, this.Compute.CalcDraw.getRadiusCircle(1), this.Compute.CalcDraw.getRadiusRulesInsideCircleZodiac(typeTrait));
                    s += "  <line x1=\"" + xy[0].dx + "\" y1=\"" + xy[0].dy + "\" x2=\"" + xy[1].dx + "\" y2=\"" + xy[1].dy + "\" stroke-width=\"1\" stroke=\"black\" />";
                }
            }
            // Draw lines house
            foreach (var i in this.Compute.House)
            {
                // 0°
                List<Offset> xy = this.Compute.CalcDraw.lineTrigo(i.PosCircle360, this.Compute.CalcDraw.getRadiusCircle(2), this.Compute.CalcDraw.getRadiusCircle(1));
                s += "  <line x1=\"" + xy[0].dx + "\" y1=\"" + xy[0].dy + "\" x2=\"" + xy[1].dx + "\" y2=\"" + xy[1].dy + "\" stroke-width=\"1\" stroke=\"black\"/>";
                // Draw triange only if not == AC / IC / DESC / MC
                bool swPointer = true;
                foreach (var j in this.Compute.Angle)
                {
                    if (j.PosCircle360 == i.PosCircle360)
                    {
                        swPointer = false;
                    }
                }
                if (swPointer)
                {
                    double angularPointer = 1.0;
                    List<Offset> xyT = this.Compute.CalcDraw.pathTrianglePointer(i.PosCircle360, angularPointer, this.Compute.CalcDraw.getRadiusRulesInsideCircleHouseForPointerBottom(), this.Compute.CalcDraw.getRadiusRulesInsideCircleHouseForPointerTop());

                    s += "  <path d=\"M " + xyT[2].dx + " " + xyT[2].dy + " L " + xyT[0].dx + " " + xyT[0].dy + " L " + xyT[1].dx + " " + xyT[1].dy + " z\" fill=\"black\" stroke-width=\"1\" fill-opacity=\"0.0\" />";
                }
            }
            s += "</svg>";
            //s = "'data:image/svg+xml;utf8," + s + "'";
            return s;
        }
    }
}