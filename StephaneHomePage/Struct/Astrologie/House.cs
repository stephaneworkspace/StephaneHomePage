using StephaneHomePage.Data.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Struct.Astrologie
{
    public class House
    {
        public int Id { get; set; }
        public int IdByAsc { get; set; }
        public String Sign { get; set; }
        public String Svg { get; set; }
        public double PosCircle360 { get; set; }
        public Offset XYHouse { get; set; }
        public House(int id, int idByAsc, String sign, String svg, double posCircle360, Offset xyHouse)
        {
            this.Id = id;
            this.IdByAsc = idByAsc;
            this.Sign = sign;
            this.Svg = svg;
            this.PosCircle360 = posCircle360;
            this.XYHouse = xyHouse;
        }
    }
}