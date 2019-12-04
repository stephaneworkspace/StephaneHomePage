using System.ComponentModel.DataAnnotations;

namespace StephaneHomePage.Model
{
/// Non PascalCase, the backend for astrology is snake_case
#pragma warning disable CA1707
public class ThemeAstralModel
{
    [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
    [Display(Name = "date")]
    public string year_month_day
    {
        get;
        set;
    }
    [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
    [Display(Name = "hh:mm")]
    public string hour_min
    {
        get;
        set;
    }
    [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
    [Display(Name = "latitude")]
    public string lat
    {
        get;
        set;
    }
    [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
    [Display(Name = "longitude")]
    public string lng
    {
        get;
        set;
    }
}
#pragma warning restore CA1707
}
