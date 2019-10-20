using StephaneHomePage.Data.Type;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Struct.Astrologie
{
    public class Planet
    {
        public String Id { get; set; }
        public String Sign { get; set; }
        public String SignPos { get; set; }
        public String Svg { get; set; }
        public String SvgDegre { get; set; }
        public String SvgMin { get; set; }
        public double PosCircle360 { get; set; }
        public Offset XYPlanet { get; set; }
        public Offset XYDeg { get; set; }
        public Offset XYMin { get; set; }
        public Color Color { get; set; }
        public String Movement { get; set; }
        public bool IsRetrograde { get; set; }
        public Planet(String id, String sign, String signPos, String svg, String svgDegre, String svgMin, double posCircle360, Offset xyPlanet, Offset xyDeg, Offset xyMin, Color color, String movement, bool isRetrograde)
        {
            this.Id = id;
            this.Sign = sign;
            this.SignPos = signPos;
            this.Svg = svg;
            this.SvgDegre = svgDegre;
            this.SvgMin = svgMin;
            this.PosCircle360 = posCircle360;
            this.XYPlanet = xyPlanet;
            this.XYDeg = xyDeg;
            this.XYMin = xyMin;
            this.Color = color;
            this.Movement = movement;
            this.IsRetrograde = isRetrograde;
        }
    }   
}