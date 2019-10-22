using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Model
{
    public class ThemeAstralModel
    {
        [Required]
        public string year_month_day { get; set; }
        [Required]
        public string hour_min { get; set; }
        [Required]
        public string utc { get; set; }
        [Required]
        public string geo_pos_ns { get; set; }
        [Required]
        public string geo_pos_we { get; set; }
    }
}
