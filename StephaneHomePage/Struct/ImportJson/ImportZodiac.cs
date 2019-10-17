using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Struct.ImportJson
{
    public class ImportZodiac
    {
        public int id { get; set; }
        public int id_by_asc { get; set; }
        public Double pos_circle_360 { get; set; }
        public String sign { get; set; }
        public String element { get; set; }
        public String svg { get; set; }
        public String symbol { get; set; }
    }
}
