﻿using System;
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
        const double CIRC = 360.0;
        public double x { get; set; }
        public double y { get; set; }
        public Radius(double radius)
        {
            //double angle = 2 * Math.PI / CIRC;
            double angle = 2 * Math.PI / (CIRC - 180.0);
            //double angle = (180 / Math.PI) * radius; // nice picture
            this.x = radius * Math.Cos(Math.Sin(angle)) * -1;
            this.y = radius * Math.Cos(Math.Sin(angle));
        }
    }
}
