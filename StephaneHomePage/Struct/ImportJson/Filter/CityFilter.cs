using System.Collections.Generic;

namespace StephaneHomePage.Struct.ImportJson.Filter
{
public class CityFilter
{
#pragma warning disable CA2227
    public List<City> filter
    {
        get;
        set;
    }
    public List<Country> country
    {
        get;
        set;
    }
#pragma warning restore CA2227
}
}
