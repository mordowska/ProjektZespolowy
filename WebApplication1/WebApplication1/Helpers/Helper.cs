using System;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace WebApplication1.Helpers
{
    public static class MyHTMLHelpers
    {
        public static IHtmlContent Currency(this IHtmlHelper htmlHelper, decimal price, string currency)
            => new HtmlString($"<span>{price} {currency}</span>");
    }
}
