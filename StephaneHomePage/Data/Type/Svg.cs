using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StephaneHomePage.Data.Type
{
    public class Svg
    {
        public String SvgB64;
        public String SvgStringWithoutMod;
        public String SvgStringWithMod;

        /// <summary>
        /// inspired from https://github.com/yoksel/url-encoder/
        /// </summary>
        /// <param name="imageMagickB64">Base 64 from ImageMagik</param>
        public Svg (String imageMagickB64)
        {
            byte[] dataByteArray = Convert.FromBase64String(imageMagickB64);
            String temp = ASCIIEncoding.UTF8.GetString(dataByteArray);
            this.SvgStringWithoutMod = temp;
            Regex r;
            if (temp.IndexOf("http://www.w3.org/2000/svg") < 0)
            {
                r = new Regex("<svg");
                temp = r.Replace(temp, "<svg xmlns=\"http://www.w3.org/2000/svg\"");
            }
            this.SvgStringWithMod = temp;
            dataByteArray = Encoding.UTF8.GetBytes(temp);
            this.SvgB64 = Convert.ToBase64String(dataByteArray);
        }
    }
}
