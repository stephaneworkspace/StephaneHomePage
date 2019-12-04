﻿using System;
using System.Text;
using System.Text.RegularExpressions;

namespace StephaneHomePage.Data.Type
{
/// Not culture varying, this program is on French
#pragma warning disable CA1307
public class Svg
{
    public String SvgB64
    {
        get;
        set;
    }
    public String SvgStringWithoutMod
    {
        get;
        set;
    }
    public String SvgStringWithMod
    {
        get;
        set;
    }

    /// <summary>
    /// inspired from https://github.com/yoksel/url-encoder/
    /// </summary>
    /// <param name="imageMagickB64">Base 64 from ImageMagik</param>
    public Svg (String imageB64)
    {
        byte[] dataByteArray = Convert.FromBase64String(imageB64);
        String temp = ASCIIEncoding.UTF8.GetString(dataByteArray);
        this.SvgStringWithoutMod = temp;
        Regex r;
        if (temp.IndexOf("http://www.w3.org/2000/svg") < 0)
        {
            r = new Regex("<svg");
            temp = r.Replace(temp, "<svg xmlns=\"http://www.w3.org/2000/svg\"");
        }
        this.SvgStringWithMod = temp;
        dataByteArray = Encoding.UTF8.GetBytes(temp);
        this.SvgB64 = Convert.ToBase64String(dataByteArray);
    }
}
#pragma warning restore CA1307
}
