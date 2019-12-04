using System;

namespace StephaneHomePage.Struct.ImportJson
{
/// Non PascalCase, the backend for astrology is snake_case
#pragma warning disable CA1707
public class ImportAngles
{
    public String id
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
    public String sign_pos
    {
        get;
        set;
    }
    public String svg
    {
        get;
        set;
    }
    public String svg_degre
    {
        get;
        set;
    }
    public String svg_min
    {
        get;
        set;
    }
}
#pragma warning restore CA1707
}
