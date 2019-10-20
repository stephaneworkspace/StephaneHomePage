using StephaneHomePage.Data.Type;
using StephaneHomePage.Struct.Astrologie;
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

        /// <summary>
        /// Generate a SVG for the circle, ang line for house, and zodiac
        /// </summary>
        /// <param name="swMode">If true, export svg else compress in base 64</param>
        /// <returns></returns>
        public string GetSvgCircle(bool swEncodeB64)
        {
            string br = swEncodeB64 ? "\\n" : Environment.NewLine;
            int size = Convert.ToInt32(this.Compute.CalcDraw.getSizeWH());
            string s = "";
            s += "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"" + size + "\" height=\"" + size + "\" >" + br;
            for (int i = 0; i <= 2; i++)
            {
                s += "  <circle cx=\""+ this.Compute.CalcDraw.getCenter().dx + "\" cy=\""+ this.Compute.CalcDraw.getCenter().dy + "\" r=\""+ this.Compute.CalcDraw.getRadiusCircle(i) + "\" stroke-width=\"1\" stroke=\"black\" fill-opacity=\"0.0\"/>" + br;
            }
            foreach (var i in this.Compute.Zodiac)
            {
                // 0°
                List<Offset> xy = this.Compute.CalcDraw.lineTrigo(i.PosCircle360, this.Compute.CalcDraw.getRadiusCircle(1), this.Compute.CalcDraw.getRadiusCircle(0));
                s += DrawSvgLine(xy);
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
                    s += DrawSvgLine(xy); 
                }
            }
            // Draw lines house
            foreach (var i in this.Compute.House)
            {
                // 0°
                List<Offset> xy = this.Compute.CalcDraw.lineTrigo(i.PosCircle360, this.Compute.CalcDraw.getRadiusCircle(2), this.Compute.CalcDraw.getRadiusCircle(1));
                s += DrawSvgLine(xy);
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
            // Draw lines planet
            foreach (var i in this.Compute.Planet)
            {/*
              // 0°
              paint = Paint()
              ..color = i.color
              ..style = PaintingStyle.stroke
              ..strokeWidth = 1.0;
              */
                List<Offset> xy = this.Compute.CalcDraw.lineTrigo(i.PosCircle360, this.Compute.CalcDraw.getRadiusCircle(3), this.Compute.CalcDraw.getRadiusCircle(1));
                //s += DrawSvgLine(xy);
            }
            s += "</svg>";
            if (swEncodeB64)
                s = EncodeB64(s);
            return s;
        }

        public string GetSvgAngle(bool swEncodeB64, Angle angle)
        {
            string br = swEncodeB64 ? "\\n" : Environment.NewLine;
            int size = Convert.ToInt32(this.Compute.CalcDraw.getSizeWH());
            string s = "";
            s += "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"" + size + "\" height=\"" + size + "\" >" + br;
            // Draw lines angle
            // 0°
            /*paint = Paint()
            ..color = i.color
            ..style = PaintingStyle.stroke
            ..strokeWidth = 1.0;*/
            List<Offset> xy = this.Compute.CalcDraw.lineTrigo(angle.PosCircle360, this.Compute.CalcDraw.getRadiusCircle(2), this.Compute.CalcDraw.getRadiusCircle(1));
            s += DrawSvgLine(xy);
            // Draw Big triangle
            /*paint = Paint()
            ..color = i.color
            ..style = PaintingStyle.fill;*/
            double angularPointer = 1.0;
            List<Offset> xyT = this.Compute.CalcDraw.pathTrianglePointer(angle.PosCircle360, angularPointer, this.Compute.CalcDraw.getRadiusCircle(2), this.Compute.CalcDraw.getRadiusCircle(1));
            s += "  <path d=\"M " + xyT[2].dx + " " + xyT[2].dy + " L " + xyT[0].dx + " " + xyT[0].dy + " L " + xyT[1].dx + " " + xyT[1].dy + " z\" fill=\"black\" stroke-width=\"1\" fill-opacity=\"1.0\" />";
            // Draw line if svg (Asc and MC)
            if (angle.Svg != "")
            {
                /*paint = Paint()
                ..color = i.color
                ..style = PaintingStyle.stroke
                ..strokeWidth = 1.0;*/
                xy = this.Compute.CalcDraw.lineTrigo(angle.PosCircle360, this.Compute.CalcDraw.getRadiusCircle(3), this.Compute.CalcDraw.getRadiusCircle(2));
                s += DrawSvgLine(xy);
            }
            s += "</svg>";
            if (swEncodeB64)
                s = EncodeB64(s);
            return s;
        }

        private String DrawSvgLine(List<Offset> xy)
        {
            return "  <line x1=\"" + xy[0].dx + "\" y1=\"" + xy[0].dy + "\" x2=\"" + xy[1].dx + "\" y2=\"" + xy[1].dy + "\" stroke-width=\"1\" stroke=\"black\" />";
        }

        private String EncodeB64(string s)
        {
            return Convert.ToBase64String(ASCIIEncoding.UTF8.GetBytes(s));
            //s = "'data:image/svg+xml;utf8," + s + "'"; or ;base64,
        }
    }
}