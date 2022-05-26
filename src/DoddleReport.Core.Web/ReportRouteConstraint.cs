using System;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Routing;
using System.IO;
using DoddleReport.Configuration;
using Microsoft.AspNetCore.Http;

namespace DoddleReport.Web
{
    public class ReportRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (routeDirection == RouteDirection.UrlGeneration)
            {
                return true;
            }


            var configuredExtensions = Config.Report.Writers.OfType<WriterElement>().Select(e => e.FileExtension).ToList();

            var requestExtension = Path.GetExtension(httpContext!.Request.Path);
            return configuredExtensions.Contains(requestExtension, StringComparer.InvariantCultureIgnoreCase);
        }

    }
}