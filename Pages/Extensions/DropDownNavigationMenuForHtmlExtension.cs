using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Abc.Pages.Extensions {
    public static class DropDownNavigationMenuForHtmlExtension {
        internal static void AddDropDownMenuItem(List<object> htmlStrings, Link item) {
            if (htmlStrings is null) return;
            if (item is null) return;
            var s = $"<a class='dropdown-item text-dark' href=\"{item.Url}\">{item.DisplayName}</a>";
            htmlStrings.Add(new HtmlString(s));
        }

        internal static void BeginDropDownNavigationMenu(List<object> htmlStrings, string name) {
            if (htmlStrings is null) return;
            htmlStrings.Add(new HtmlString("<li class=\"nav-item dropdown\">"));
            htmlStrings.Add(new HtmlString("<a class=\"nav-link text-dark dropdown-toggle\" href=\"#\" id=\"navbardrop\" data-toggle=\"dropdown\">"));
            htmlStrings.Add(new HtmlString(name));
            htmlStrings.Add(new HtmlString("</a>"));
            htmlStrings.Add(new HtmlString("<div class=\"dropdown-menu\">"));
        }

        internal static void EndDropDownNavigationMenu(List<object> htmlStrings) {
            if (htmlStrings is null) return;
            htmlStrings.Add(new HtmlString("</div>"));
            htmlStrings.Add(new HtmlString("</li>"));
        }

        public static IHtmlContent DropDownNavigationMenuFor(this IHtmlHelper helper, string name, params Link[] items) {
            var htmlStrings = new List<object>();
            BeginDropDownNavigationMenu(htmlStrings, name);
            foreach (var item in items) AddDropDownMenuItem(htmlStrings, item);
            EndDropDownNavigationMenu(htmlStrings);
            return new HtmlContentBuilder(htmlStrings);
        }
    }
}
