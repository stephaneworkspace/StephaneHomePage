using System;

namespace StephaneHomePage.Struct.ImportJson
{
/// Non PascalCase, the backend for astrology is snake_case
#pragma warning disable CA1707
public class ImportZodiac
{
    public int id
    {
        get;
        set;
    }
    public int id_by_asc
    {
        get;
        set;
    }
    public Double pos_circle_360
    {
        get;
        set;
    }
    public String sign
    {
        get;
        set;
    }
    public String element
    {
        get;
        set;
    }
    public String svg
    {
        get;
        set;
    }
    public String symbol
    {
        get;
        set;
    }
}
#pragma warning restore CA1707
}
