using System;
using System.Collections.Generic;
using StephaneHomePage.Struct.Astrologie.Text.ContentText;

namespace StephaneHomePage.Data.Astrologie.ThemeAstral.Text
{
/// Not culture varying, this program is on French
#pragma warning disable CA1307
public class CalcContent
{
    const string STARTTAGTIT = "<TIT>"; // Title private repository
    const string ENDTAGTIT = "</TIT>";
    const string STARTTAGTEX = "<TEX>"; // Text private reposition
    const string ENDTAGTEX = "</TEX>";
    const string STARTTAGSVG = "<SVG>"; // SVG private preposition
    const string ENDTAGSVG = "</SVG>";
    const string STARTTAGSVZ = "<SVZ>"; // SVG Asset in this git repository
    const string ENDTAGSVZ = "</SVZ>";
    const string STARTTAGPNG = "<PNG>";
    const string ENDTAGPNG = "</PNG>";

    // Param at begin of <TIT>
    const string STARTTAGSIZ = "<SIZ>";
    const string ENDTAGNES = "</SIZ>";

    // Rich text inside <TEX>
    const string STARTRICHNORMAL = "<N>";
    const string ENDRICHNORMAL = "</N>";
    const string STARTRICHITALIC = "<I>";
    const string ENDRICHITALIC = "</I>";
    const string STARTRICHBOLD = "<B>";
    const string ENDRICHBOLD = "</B>";

    const double TITLESIZ1 = 20.0;
    const double TITLESIZ2 = 18.0;
    const double TITLESIZ3 = 16.0;

    const System.StringComparison CULTURE = System.StringComparison.CurrentCulture;

    public List<Content> makeContent(String s)
    {
        if (s == null)
        {
            s = "";
        }
        // int temp = 0;
        List<Content> l = new List<Content>();
        bool swLoop = true;
        ContentNext cn = new ContentNext(TypeContent.Null, 0, "");
        while (swLoop)
        {
            cn = this._nextContent(s);
            if (cn.Type == TypeContent.Null)
            {
                s = "";
                swLoop = false;
            }
            else
            {
                if (s.Length >= cn.NextPos)
                {
                    s = s.Substring(cn.NextPos);
                    switch (cn.Type)
                    {
                    case TypeContent.TypeTitle:
                        string content = "";
                        double size = 18.0;
                        int startIndex = 0;
                        int endIndex = 0;
                        // Size
                        var test = cn.Content.IndexOf(STARTTAGSIZ);
                        startIndex = cn.Content.IndexOf(STARTTAGSIZ) == -1 ? 0 : cn.Content.IndexOf(STARTTAGSIZ) + STARTTAGSIZ.Length;
                        endIndex = cn.Content.IndexOf(ENDTAGNES, startIndex);
                        bool swValidTitle = (startIndex > 0) && (endIndex - startIndex) > 0;
                        if (!swValidTitle)
                        {
                            content = cn.Content;
                        }
                        else
                        {
                            // Mod of dart
                            //switch (cn.Content.Substring(startIndex, endIndex))
                            switch (cn.Content.Substring(startIndex, endIndex - startIndex))
                                // End mod of dart
                            {
                            case "1":
                                size = TITLESIZ1;
                                break;
                            case "2":
                                size = TITLESIZ2;
                                break;
                            case "3":
                                size = TITLESIZ3;
                                break;
                            default:
                                size = TITLESIZ2;
                                break;
                            }
                            if (cn.Content.Length >= endIndex + ENDTAGNES.Length)
                                content = cn.Content.Substring(endIndex + ENDTAGNES.Length);
                        }
                        ContentTitle itemTitle = new ContentTitle(content, size);
                        l.Add(new Content(TypeContent.TypeTitle, itemTitle, null, null, null));
                        break;
                    case TypeContent.TypeText:
                        bool swLoop2 = true;
                        String string2 = cn.Content;
                        List<ContentTextRich> listRich = new List<ContentTextRich>();
                        ContentNextTextRich cntr = new ContentNextTextRich(FontStyle.Normal, FontWeight.Normal, 0, "");
                        while (swLoop2)
                        {
                            if (cntr.FontStyle == FontStyle.Null || cntr.FontWeight == FontWeight.Null)
                            {
                                string2 = "";
                                swLoop2 = false;
                            }
                            else
                            {
                                if (string2.Length >= cntr.NextPos)
                                {
                                    string2 = string2.Substring(cntr.NextPos); // Init at 0
                                    cntr = _nextContentRichText(string2);
                                    if (cntr.Content != null)
                                        listRich.Add(new ContentTextRich(cntr.Content, cntr.FontStyle, cntr.FontWeight));
                                    else
                                    {
                                        string2 = "";
                                        swLoop2 = false;
                                    }
                                }
                                else
                                {
                                    string2 = "";
                                    swLoop2 = false;
                                }
                            }
                        }
                        ContentText itemText = new ContentText(listRich);
                        l.Add(new Content(TypeContent.TypeText, null, itemText, null, null));
                        break;
                    case TypeContent.TypeSvg:
                        ContentSvg itemSvg = new ContentSvg(cn.Content);
                        l.Add(new Content(TypeContent.TypeSvg, null, null, itemSvg, null));
                        break;
                    case TypeContent.TypePng:
                        ContentPng itemPng = new ContentPng(cn.Content);
                        l.Add(new Content(TypeContent.TypePng, null, null, null, itemPng));
                        break;
                    default:
                        break;
                    }
                }
                else
                {
                    s = "";
                    swLoop = false;
                }
            }
        }
        return l;
    }
    /// Next item detection
    /// Return a object ContentNext with the type of element and position in string
    private ContentNext _nextContent(String s)
    {
        // print('str: ' + s);
        int pos = s.Length;
        int nextPos = 0;
        String content = "";
        TypeContent type = TypeContent.Null;
        int startIndex = 0;
        int endIndex = 0;
        // Title
        startIndex = s.IndexOf(STARTTAGTIT) == -1 ? 0 : s.IndexOf(STARTTAGTIT) + STARTTAGTIT.Length;
        endIndex = s.IndexOf(ENDTAGTIT, startIndex);
        bool swValidTitle = (startIndex > 0) && (endIndex - startIndex) > 0;
        if (!swValidTitle)
        {
            startIndex = 0;
            endIndex = 0;
        }
        else
        {
            if (pos > startIndex)
            {
                pos = startIndex;
                nextPos = endIndex + ENDTAGTIT.Length;
                // Mod of dart
                content = s.Substring(startIndex, endIndex - startIndex);
                //content = s.Substring(startIndex, endIndex);
                // End mod of dart
                type = TypeContent.TypeTitle;
            }
        }
        // Text
        startIndex = s.IndexOf(STARTTAGTEX) == -1 ? 0 : s.IndexOf(STARTTAGTEX) + STARTTAGTEX.Length;
        endIndex = s.IndexOf(ENDTAGTEX, startIndex);
        bool swValidText = (startIndex > 0) && (endIndex - startIndex) > 0;
        if (!swValidText)
        {
            startIndex = 0;
            endIndex = 0;
        }
        else
        {
            if (pos > startIndex)
            {
                pos = startIndex;
                nextPos = endIndex + ENDTAGTEX.Length;
                // Mod of dart
                // content = s.Substring(startIndex, endIndex);
                content = s.Substring(startIndex, endIndex - startIndex);
                // End mod of dart
                type = TypeContent.TypeText;
            }
        }
        // Svg
        startIndex = s.IndexOf(STARTTAGSVG) == -1 ? 0 : s.IndexOf(STARTTAGSVG) + STARTTAGSVG.Length;
        endIndex = s.IndexOf(ENDTAGSVG, startIndex);
        bool swValidSvg = (startIndex > 0) && (endIndex - startIndex) > 0;
        if (!swValidSvg)
        {
            startIndex = 0;
            endIndex = 0;
        }
        else
        {
            if (pos > startIndex)
            {
                pos = startIndex;
                nextPos = endIndex + ENDTAGSVG.Length;
                // Mod of dart
                // content = "assets/svg/astro_py_text/" + s.Substring(startIndex, endIndex);
                content = "assets/svg/astro_py_text/" + s.Substring(startIndex, endIndex - startIndex);
                // End mod of dart
                type = TypeContent.TypeSvg;
            }
        }
        // Svg Zodiac local
        startIndex = s.IndexOf(STARTTAGSVZ) == -1 ? 0 : s.IndexOf(STARTTAGSVZ) + STARTTAGSVZ.Length;
        endIndex = s.IndexOf(ENDTAGSVZ, startIndex);
        bool swValidSvgz = (startIndex > 0) && (endIndex - startIndex) > 0;
        if (!swValidSvgz)
        {
            startIndex = 0;
            endIndex = 0;
        }
        else
        {
            if (pos > startIndex)
            {
                pos = startIndex;
                nextPos = endIndex + ENDTAGSVZ.Length;
                // Mod of dart
                // content = "assets/svg/zodiac/" + s.Substring(startIndex, endIndex);
                content = "assets/svg/zodiac/" + s.Substring(startIndex, endIndex - startIndex);
                // End mod of dart
                type = TypeContent.TypeSvg;
            }
        }
        // Png
        startIndex = s.IndexOf(STARTTAGPNG) == -1 ? 0 : s.IndexOf(STARTTAGPNG) + STARTTAGPNG.Length;
        endIndex = s.IndexOf(ENDTAGPNG, startIndex);
        bool swValidPng = (startIndex > 0) && (endIndex - startIndex) > 0;
        if (!swValidPng)
        {
            startIndex = 0;
            endIndex = 0;
        }
        else
        {
            if (pos > startIndex)
            {
                pos = startIndex;
                nextPos = endIndex + ENDTAGPNG.Length;
                // Mod of dart
                // content = "assets/png/astro_py_text/" + s.Substring(startIndex, endIndex);
                content = "assets/png/astro_py_text/" + s.Substring(startIndex, endIndex - startIndex);
                // End mod of dart
                type = TypeContent.TypePng;
            }
        }
        return new ContentNext(type, nextPos, content);
    }

    private ContentNextTextRich _nextContentRichText(String s)
    {
        // print('str: ' + s);
        int pos = s.Length;
        int nextPos = 0;
        String content = "";
        FontStyle fontStyle = FontStyle.Normal;
        FontWeight fontWeight = FontWeight.Normal;
        int startIndex = 0;
        int endIndex = 0;
        // Normal <N> -> STARTRICHNORMAL </N> -> ENDRICHNORMAL
        startIndex = s.IndexOf(STARTRICHNORMAL) == -1 ? 0 : s.IndexOf(STARTRICHNORMAL) + STARTRICHNORMAL.Length;
        endIndex = s.IndexOf(ENDRICHNORMAL, startIndex);
        bool swValidN = (startIndex > 0) && (endIndex - startIndex) > 0;
        if (!swValidN)
        {
            startIndex = 0;
            endIndex = 0;
        }
        else
        {
            if (pos > startIndex)
            {
                pos = startIndex;
                nextPos = endIndex + ENDRICHNORMAL.Length;
                // Mod of dart
                // content = s.Substring(startIndex, endIndex);
                content = s.Substring(startIndex, endIndex - startIndex);
                // End mod of dart
                fontStyle = FontStyle.Normal;
            }
        }
        // Italic <I> -> STARTRICHITALIC </> -> ENDRICHITALIC
        startIndex = s.IndexOf(STARTRICHITALIC) == -1 ? 0 : s.IndexOf(STARTRICHITALIC) + STARTRICHITALIC.Length;
        endIndex = s.IndexOf(ENDRICHITALIC, startIndex);
        bool swValidI = (startIndex > 0) && (endIndex - startIndex) > 0;
        if (!swValidI)
        {
            startIndex = 0;
            endIndex = 0;
        }
        else
        {
            if (pos > startIndex)
            {
                pos = startIndex;
                nextPos = endIndex + ENDRICHITALIC.Length;
                // Mod of dart
                // content = s.Substring(startIndex, endIndex);
                content = s.Substring(startIndex, endIndex - startIndex);
                // End mod of dart
                fontStyle = FontStyle.Italic;
            }
        }
        // Italic <B> -> STARTRICHBOLD </> -> ENDRICHBOLD
        startIndex = s.IndexOf(STARTRICHBOLD) == -1 ? 0 : s.IndexOf(STARTRICHBOLD) + STARTRICHBOLD.Length;
        endIndex = s.IndexOf(ENDRICHBOLD, startIndex);
        bool swValidB = (startIndex > 0) && (endIndex - startIndex) > 0;
        if (!swValidB)
        {
            startIndex = 0;
            endIndex = 0;
        }
        else
        {
            if (pos > startIndex)
            {
                pos = startIndex;
                nextPos = endIndex + ENDRICHBOLD.Length;
                // Mod of dart
                //content = s.Substring(startIndex, endIndex);
                content = s.Substring(startIndex, endIndex - startIndex);
                // En mod of dart
                fontWeight = FontWeight.Bold;
            }
        }
        if (content.Length == 0)
            return new ContentNextTextRich(FontStyle.Null, FontWeight.Null, nextPos, content);
        else
            return new ContentNextTextRich(fontStyle, fontWeight, nextPos, content);
    }
}
#pragma warning restore CA1307
}
