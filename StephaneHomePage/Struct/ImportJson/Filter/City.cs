using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Struct.ImportJson.Filter
{
    public class City
    {
        public int id { get; set; }
        public string country { get; set; }
        public string name { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
    }
}
