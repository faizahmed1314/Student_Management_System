using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace StudentManagementSystem.CustomHtmlHelpers
{
    public static class CustomHtmlHelpers
    {
        public static IHtmlString Image(this IHtmlString heplper, string src, string alt)
        {
            var tb=new TagBuilder("img");
            tb.Attributes.Add("src",VirtualPathUtility.ToAbsolute(src));
            tb.Attributes.Add("alt",alt);
            return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
        }
    }
}