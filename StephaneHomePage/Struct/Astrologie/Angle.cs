using StephaneHomePage.Data.Type;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Struct.Astrologie
{
    public class Angle
    {
        public String Id { get; set; }
        public String Sign { get; set; }
        public String SignPos { get; set; }
        public String Svg { get; set; }
        public String SvgDegre { get; set; }
        public String SvgMin { get; set; }
        public double PosCircle360 { get; set; }
        public double PosCircle360Svg { get; set; }
        public Offset XYAngle { get; set; }
        public Offset XYDef { get; set; }
        public Offset XYMin { get; set; }
        public Color Color { get; set; }
        public Angle(String id, String sign, String signPos, String svg, String svgDegre, String svgMin, double posCircle360, double posCircle360Svg, Offset xyAngle, Offset xyDef, Offset xyMin, Color color)
        {
            this.Id = id;
            this.Sign = sign;
            this.SignPos = signPos;
            this.Svg = svg;
            this.SvgDegre = svgDegre;
            this.SvgMin = svgMin;
            this.PosCircle360 = posCircle360;
            this.PosCircle360Svg = posCircle360Svg;
            this.XYAngle = xyAngle;
            this.XYDef = xyDef;
            this.XYMin = xyMin;
            this.Color = color;
        }
    }
}