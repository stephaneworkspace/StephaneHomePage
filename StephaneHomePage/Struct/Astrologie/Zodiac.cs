using StephaneHomePage.Data.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Struct.Astrologie
{
    public class Zodiac
    {
        public int Id { get; set; }
        public int IdByAsc { get; set; }
        public String Symbol { get; set; }
        public El Element { get; set; }
        public String Sign { get; set; }
        public String Svg { get; set; }
        public double PosCircle360 { get; set; }
        public Offset XYZodiac { get; set; }
        
        public Zodiac(int id, int idByAsc, string symbol, El element, string sign, string svg, double posCircle360, Offset xyZodiac)
        {
            this.Id = id;
            this.IdByAsc = idByAsc;
            this.Symbol = symbol;
            this.Element = element;
            this.Sign = sign;
            this.Svg = svg;
            this.PosCircle360 = posCircle360;
            this.XYZodiac = xyZodiac;
        }

        public Zodiac()
        {

        }
    }
}