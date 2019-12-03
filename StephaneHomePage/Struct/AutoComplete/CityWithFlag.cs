using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Struct.AutoComplete
{
    public class CityWithFlag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Country { get; set; }
        public string Flag { get; set; }

        public CityWithFlag(int id, string name, double lat, double lng, string country, string flag) 
        {
            Id = id;
            Name = name;
            Lat = lat;
            Lng = lng;
            Country = country;
            Flag = flag;
        }
    }
}
