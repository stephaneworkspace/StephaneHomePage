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
            double angle = 2 * Math.PI / ANGLE;
            //double angle = (180 / Math.PI) * radius; // nice picture
            this.x = radius * Math.Cos(Math.Sin(angle)) * -1; // Because in dart it convert with -1
            this.y = radius * Math.Cos(Math.Sin(angle));
        }
    }
}
