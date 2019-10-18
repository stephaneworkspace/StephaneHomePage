using ImageMagick;
using StephaneHomePage.Data.Type;
using System;
using System.Collections.Generic;
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

        public String GetSvg()
        {
            var r = "";
            using (MagickImage image = new MagickImage(new MagickColor("yellow"), 500, 500))
            {
                DrawableStrokeColor strokeColor = new DrawableStrokeColor(new MagickColor("purple"));
                DrawableStrokeWidth stokeWidth = new DrawableStrokeWidth(5);
                //DrawableFillColor fillColor = new DrawableFillColor(MagickColor.Transparent);
                DrawableFillColor fillColor = new DrawableFillColor(new MagickColor("red"));
                DrawableCircle circle = new DrawableCircle(250, 250, 100, 100);

                image.Draw(strokeColor, stokeWidth, fillColor, circle);
                // image.Write(@"C:\circl.png");
                image.Format = MagickFormat.Svg;
                Svg svg = new Svg(image.ToBase64());
                /*
                 * r = "DEBUG : svg.SvgStringWitoutMod" // go to https://yoksel.github.io/url-encoder/
                 * r = "'data:image/svg+xml;utf8," + svg.SvgStringWithMod + "'";
                 */
                r = "'data:image/svg+xml;base64," + svg.SvgB64 + "'";
            }
            return r;
        }
    }
}
