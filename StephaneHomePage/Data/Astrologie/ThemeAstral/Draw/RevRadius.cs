using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Data.Astrologie.ThemeAstral.Draw
{
    public class RevRadius
    {
        public double Rad { get; set; }
        // Function to find the radius  
        public RevRadius(double d, double h)
        {
            Console.WriteLine("The radius of the circle is "
                + ((d * d) / (8 * h) + h / 2));
            this.Rad = ((d * d) / (8 * h) + h / 2);
        }
    }
}
