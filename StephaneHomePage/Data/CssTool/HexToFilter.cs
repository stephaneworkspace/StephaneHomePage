using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Data.CssTool
{
    /// <summary>
    /// Imported from https://github.com/willmendesneto/hex-to-css-filter/blob/master/index.js
    /// </summary>
    public class Color
    {
        private int R { get; set; }
        private int G { get; set; }
        private int B { get; set; }

        public Color(int r, int g, int b)
        {
            Set(r, g, b);
        }
        private void Set(int r, int g, int b)
        {
            R = Clamp(r);
            G = Clamp(g);
            B = Clamp(b);
        }

        private int Clamp(int value) 
        {
            if (value > 255) 
            {
                value = 255;
            } else if (value < 0) 
            {
                value = 0;
            }
            return value;
        }
    }
    public class HexToFilter
    {
    }
}
