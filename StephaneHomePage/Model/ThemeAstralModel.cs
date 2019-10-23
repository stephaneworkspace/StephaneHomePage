using StephaneHomePage.Struct.AutoComplete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Model
{
    public class ThemeAstralModel
    {
        [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
        [Display(Name = "date")]
        public string year_month_day { get; set; }
        [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
        [Display(Name = "hh:mm")]
        public string hour_min { get; set; }
        [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
        [Display(Name = "latitude")]
        public string lat { get; set; }
        [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
        [Display(Name = "longitude")]
        public string lng { get; set; }
    }
}
