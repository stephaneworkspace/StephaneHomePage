using StephaneHomePage.Struct.Astrologie.Text.ContentText;
using System.Collections.Generic;

namespace StephaneHomePage.Struct.Astrologie.Text
{
public class ZodiacT
{
    public string Sign
    {
        get;
        set;
    }
#pragma warning disable CA2227
    public List<Content> Content
    {
        get;
        set;
    }
#pragma warning restore CA2227
    public ZodiacT(string sign, List<Content> content)
    {
        this.Sign = sign;
        this.Content = content;
    }
}
}
