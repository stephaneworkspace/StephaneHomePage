using System.Collections.Generic;

namespace StephaneHomePage.Struct.ImportJson
{
public class ImportJson
{
#pragma warning disable CA2227
    public List<ImportAngles> angles
    {
        get;
        set;
    }
    public List<ImportHouses> houses
    {
        get;
        set;
    }
    public List<ImportPlanets> planets
    {
        get;
        set;
    }
    public List<ImportZodiac> zodiac
    {
        get;
        set;
    }
    public List<ImportZodiacText> zodiac_text
    {
        get;
        set;
    }
#pragma warning restore CA2227
}
}
