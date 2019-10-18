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
            s += "  <circle cx=\"250\" cy=\"250\" r=\"212.132\" stroke=\"black\" fill-opacity=\"0.0\"/>" + br;
            s += "</svg>";
            //s = "'data:image/svg+xml;utf8," + s + "'";
            return s;
        }

        public String GetSvg()
        {
            var r = "";
            using (MagickImage image = new MagickImage(MagickColors.Transparent, Convert.ToInt32(this.Compute.CalcDraw.getSizeWH()), Convert.ToInt32(this.Compute.CalcDraw.getSizeWH())))
            {
                DrawableStrokeColor strokeColor = new DrawableStrokeColor(new MagickColor("black"));
                DrawableStrokeWidth stokeWidth = new DrawableStrokeWidth(5);
                DrawableFillColor fillColor = new DrawableFillColor(MagickColors.Transparent);
                DrawableCircle circle = new DrawableCircle(250, 250, 100, 100);

                image.Draw(strokeColor, stokeWidth, fillColor, circle);

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

/*
 * 
    @*

        void Draw()
        {
            CalcDraw _calcDraw = new CalcDraw(MaxWidth, MaxHeight);
            bitmap = new Bitmap(Convert.ToInt32(_calcDraw.getSizeWH()), Convert.ToInt32(_calcDraw.getSizeWH()));
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.Green);

            /*var paint = Paint()
                ..color = Colors.black
                ..style = PaintingStyle.stroke
                ..strokeWidth = 1.0;
Pen pen = new Pen(ColorTranslator.FromHtml("#000000"), Convert.ToInt32(1.0));
Rectangle rectangle = new Rectangle();
            for (int i = 0; i <= 3; i++)
            {
                Radius tempRadius = new Radius(_calcDraw.getRadiusCircle(i));
rectangle.Width = Convert.ToInt32(tempRadius.x);
                rectangle.Height = Convert.ToInt32(tempRadius.y);
                rectangle.X = Convert.ToInt32(_calcDraw.getCenter().dx);
                rectangle.Y = Convert.ToInt32(_calcDraw.getCenter().dy);
                graphics.DrawEllipse(pen, rectangle);
            }

            //canvas.drawCircle(_calcDraw.getCenter(), _calcDraw.getRadiusCircle(0), paint);
            //canvas.drawCircle(_calcDraw.getCenter(), _calcDraw.getRadiusCircle(1), paint);
            //canvas.drawCircle(_calcDraw.getCenter(), _calcDraw.getRadiusCircle(2), paint);







            //Pen pen = new Pen(Color.White, 2);
            graphics.DrawRectangle(pen, 50, 50, 250, 200);
            MemoryStream memoryStream = new MemoryStream();
bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            byteArray = memoryStream.ToArray();
            b64 = Convert.ToBase64String(byteArray);
            //brush.Dispose();
            graphics.Dispose();
            bitmap.Dispose();
        }
    */