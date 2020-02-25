﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Abc.Pages.Extensions
{
    public static class DisplayControlsForHtmlExtension
    { //expression peab minema funktsioonile ja funktsioon peab olema klassil ja tulemus peab olema propertyl. 
        public static IHtmlContent DisplayControlsFor<TClassType, TPropertyType>(this IHtmlHelper<TClassType>htmlHelper, Expression<Func<TClassType,TPropertyType>> expression)
        {
            var s = HtmlString(htmlHelper, expression);
            return new HtmlContentBuilder(s);
        }

        internal static List<object>HtmlString<TClassType, TPropertyType>(IHtmlHelper<TClassType> htmlHelper, Expression<Func<TClassType, TPropertyType>> expression)
        {
            return new List<object>
            {
                new HtmlString("<dt class=\"col-sm-2\">"),
                htmlHelper.DisplayNameFor(expression),
                new HtmlString("</dt>"),
                new HtmlString("<dd class=\"col-sm-10\">"),
                htmlHelper.DisplayFor(expression),
                new HtmlString("</dd>")
            };
            
        }
    }
}
