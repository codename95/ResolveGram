using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace ResolveGram.Helper
{
    public static class MenuHelper
    {
        public static MvcHtmlString MenuLink(
    this HtmlHelper helper,
    string text, string action, string controller)
        {
            var routeData = helper.ViewContext.RouteData.Values;
            var currentController = routeData["controller"];
            var currentAction = routeData["action"];

            if (String.Equals(action, currentAction as string,
                      StringComparison.OrdinalIgnoreCase)
                &&
               String.Equals(controller, currentController as string,
                       StringComparison.OrdinalIgnoreCase))

            {
                return helper.ActionLink(
                    text, action, controller, null,
                    new { @class = "menu-top-active" }
                    );
            }
            return helper.ActionLink(text, action, controller);
        }
    }
}