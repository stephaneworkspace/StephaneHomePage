using System.Collections.Generic;

namespace StephaneHomePage.Struct.ImportJson
{
public class ImportJson
{
/// Non PascalCase, the backend for astrology is snake_case
#pragma warning disable CA1707
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
#pragma warning restore CA1707
#pragma warning restore CA2227
}
}
