using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Data.Astrologie.ThemeAstral
{
    public class CalcPos
    {
        public double Convert(double d)
        {
            d += 180.0;
            if (d > 360.0)
            {
                d -= 360.0;
            }
            return d;
        }  
    }
}
