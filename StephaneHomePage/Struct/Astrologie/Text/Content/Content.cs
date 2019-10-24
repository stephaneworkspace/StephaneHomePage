using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephaneHomePage.Struct.Astrologie.Text.Content
{
    public class Content
    {
        public TypeContent TypeContent { get; set; }
        public ContentTitle ContentTitle { get; set; }
        public ContentText ContentText { get; set; }
        public ContentSvg ContentSvg { get; set; }
        public ContentPng ContentPng { get; set; }
        public Content(TypeContent typeContent, ContentTitle contentTitle, ContentText contentText, ContentSvg contentSvg, ContentPng contentPng)
        {
            TypeContent = typeContent;
            ContentTitle = contentTitle;
            ContentText = contentText;
            ContentSvg = contentSvg;
            ContentPng = contentPng;
        }
    }
}
