using StephaneHomePage.Struct.AutoComplete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Model
{
    public class ThemeNombresModel
    {
        [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
        [Display(Name = "date")]
        public string date { get; set; }
        [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
        [Display(Name = "nom")]
        public string nom { get; set; }
        [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
        [Display(Name = "prenom")]
        public string prenom { get; set; }
    }
}
