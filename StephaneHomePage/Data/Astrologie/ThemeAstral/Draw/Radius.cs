using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Data.Astrologie.ThemeAstral.Draw
{
    /// <summary>
    /// Radius circular
    /// </summary>
    public class Radius
    {
        const double ANGLE = 360.0;
        public double x { get; set; }
        public double y { get; set; }
        public Radius(double radius)
        {
            this.x = radius * Math.Cos(Math.Sin(ANGLE));
            this.y = radius * Math.Sin(ANGLE);
        }
    }
}
