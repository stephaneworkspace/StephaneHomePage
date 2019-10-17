using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Data.Type
{
    public class Offset
    {
        public double dx { get; set; }
        public double dy { get; set; }

        public Offset(double dx, double dy)
        {
            this.dx = dx;
            this.dy = dy;
        }
    }
}
