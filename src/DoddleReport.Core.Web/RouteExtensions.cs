using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace DoddleReport.Web
{
    public static class RouteExtensions
    {

        /// <summary>
        /// Register the ReportingRoute. This Route allows ReportResult Actions to be accessed via a file extension in the URL, for example http://localhost/MyController/MyActionResult.html to get an HTML Report
        /// </summary>
        public static ControllerActionEndpointConventionBuilder MapReportingRouteWithAreaSupport(this WebApplication routes)
        {
            return routes.MapReportingRouteWithAreaSupport(null, null);
        }

        /// <summary>
        /// Register the ReportingRoute. This Route allows ReportResult Actions to be accessed via a file extension in the URL, for example http://localhost/MyController/MyActionResult.html to get an HTML Report
        /// </summary>
        public static ControllerActionEndpointConventionBuilder MapReportingRouteWithAreaSupport(this WebApplication app, string? defaultController, string? defaultAction)
        {
            return app.MapControllerRoute("DoddleReportWithArea",
                                   "{area:exists}/{controller}/{action}.{extension}/{*pathInfo}",
                                   new { controller = defaultController, action = defaultAction },
                                   new { extension = new ReportRouteConstraint() }
                );
        }

        /// <summary>
        /// Register the ReportingRoute. This Route allows ReportResult Actions to be accessed via a file extension in the URL, for example http://localhost/MyController/MyActionResult.html to get an HTML Report
        /// </summary>
        public static ControllerActionEndpointConventionBuilder MapReportingRoute(this WebApplication routes)
        {
            return routes.MapReportingRoute(null, null);
        }

        /// <summary>
        /// Register the ReportingRoute. This Route allows ReportResult Actions to be accessed via a file extension in the URL, for example http://localhost/MyController/MyActionResult.html to get an HTML Report
        /// </summary>
        public static ControllerActionEndpointConventionBuilder MapReportingRoute(this WebApplication app, string? defaultController, string? defaultAction)
        {
            return app.MapControllerRoute("DoddleReport",
                                   "{controller}/{action}.{extension}/{*pathInfo}",
                                   new { controller = defaultController, action = defaultAction },
                                   new { extension = new ReportRouteConstraint() }
                );
        }
    }
}