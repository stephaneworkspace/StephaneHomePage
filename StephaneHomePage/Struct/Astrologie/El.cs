using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Struct.Astrologie
{
    public class El
    {
        public String Name { get; set; }
        public Color Color { get; set; }
        public El(String name, Color color)
        {
            this.Name = name;
            this.Color = color;
        }
    }
}