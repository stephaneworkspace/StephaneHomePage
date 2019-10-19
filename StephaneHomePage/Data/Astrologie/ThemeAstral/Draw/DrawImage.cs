using ImageMagick;
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

        public String GetSvgImage(bool swMode)
        {
            string br = swMode ? Environment.NewLine : "\\n";
            int size = Convert.ToInt32(this.Compute.CalcDraw.getSizeWH());
            string s = "";
            s += "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"" + size + "\" height=\"" + size + "\">" + br;
            // Circle 1
            //s += "  <circle cx=\"250\" cy=\"250\" r=\"212.132\" stroke=\"black\" fill-opacity=\"0.0\"/>" + br;
            for (int i = 0; i <= 2; i++)
            {
                s += "  <circle cx=\""+ this.Compute.CalcDraw.getCenter().dx + "\" cy=\""+ this.Compute.CalcDraw.getCenter().dy + "\" r=\""+ this.Compute.CalcDraw.getRadiusCircle(i) + "\" stroke=\"black\" fill-opacity=\"0.0\"/>" + br;
            }
            foreach (var i in this.Compute.Zodiac)
            {
                // 0°
                List<Offset> xy = this.Compute.CalcDraw.lineTrigo(i.PosCircle360, this.Compute.CalcDraw.getRadiusCircle(1), this.Compute.CalcDraw.getRadiusCircle(0));
                s += "<line x1=\""+xy[0].dx+"\" y1=\""+xy[0].dy+"\" x2=\""+xy[1].dx+"\" y2=\""+xy[1].dy+ "\" stroke=\"black\"/>";
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
                    s += "<line x1=\"" + xy[0].dx + "\" y1=\"" + xy[0].dy + "\" x2=\"" + xy[1].dx + "\" y2=\"" + xy[1].dy + "\" stroke=\"black\" />";
                }
            }




            s += "</svg>";
            //s = "'data:image/svg+xml;utf8," + s + "'";
            return s;
        }

        public String GetSvg()
        {
            var r = "";
            using (MagickImage image = new MagickImage(MagickColors.Transparent, Convert.ToInt32(this.Compute.CalcDraw.getSizeWH()), Convert.ToInt32(this.Compute.CalcDraw.getSizeWH())))
            {
                Radius tempRadius = new Radius(0.0);
                DrawableStrokeColor strokeColor = new DrawableStrokeColor(new MagickColor("black"));
                DrawableStrokeWidth stokeWidth = new DrawableStrokeWidth(5);
                DrawableFillColor fillColor = new DrawableFillColor(MagickColors.Transparent);
                //DrawableCircle circle = new DrawableCircle(250, 250, 100, 100);
                for (int i = 0; i <= 3; i++)
                {
                    tempRadius = new Radius(this.Compute.CalcDraw.getRadiusCircle(i));
                    DrawableCircle circle = new DrawableCircle(this.Compute.CalcDraw.getCenter().dx, this.Compute.CalcDraw.getCenter().dy, tempRadius.x, tempRadius.y);
                    // image.Draw(strokeColor, stokeWidth, fillColor, circle);
                }

                foreach (var i in this.Compute.Zodiac)
                {
                    DrawableLine line;
                    // 0°
                    List<Offset> xy = this.Compute.CalcDraw.lineTrigo(i.PosCircle360, this.Compute.CalcDraw.getRadiusCircle(1), this.Compute.CalcDraw.getRadiusCircle(0));
                    line = new DrawableLine(xy[0].dx, xy[0].dy, xy[1].dx, xy[1].dy);
                    image.Draw(strokeColor, stokeWidth, fillColor, line);
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
                        line = new DrawableLine(xy[0].dx, xy[0].dy, xy[1].dx, xy[1].dy);
                        image.Draw(strokeColor, stokeWidth, fillColor, line);
                    }
                }


                image.Format = MagickFormat.Svg;
                Svg svg = new Svg(image.ToBase64());
                /*
                 * r = "DEBUG : svg.SvgStringWitoutMod" // go to https://yoksel.github.io/url-encoder/
                 * r = "'data:image/svg+xml;utf8," + svg.SvgStringWithMod + "'";
                 */
                //r = "'data:image/svg+xml;base64," + svg.SvgB64 + "'";
                r = svg.SvgB64;
            }
            return r;
        }
        ///<summary>
        /// Converts the specified MagickColor to an instance of this type.
        ///</summary>
        public static MagickColor FromMagickColor(Color color)
        {
            if (color == null)
                return null;

            return new MagickColor(color.ToString());
        }
    }
}