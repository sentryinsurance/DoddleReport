using System;
using System.Configuration;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;
using DoddleReport.Web;

namespace DoddleReport.Sample.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //DelimitedTextReportWriter.GetHeaderText = field => field.HeaderText;


            routes.MapRoute("LegacyUrl",
                    "home/{action}.{extension}",
                    new { controller = "Doddle" },
                    new { extension = new ReportRouteConstraint() }
                );

            routes.MapReportingRoute();

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional, area = "" } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            DoddleReport.Legacy.Configuration.Config.LoadConfiguration();
            //DoddleReport.Configuration.Config.Report.Writers.Add(
            //new DoddleReport.Configuration.WriterElement
            //{
            //    Writer = new DoddleReport.OpenXml.ExcelReportWriter(),
            //    FileExtension = ".xlsx",
            //    ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            //    OfferDownload = true
            //});

            ////Configuration.Config.Report.Styles[Configuration.Config.Report.HeaderRowStyleName].Underline = true;

            TryRegisterAbcPdf();
            
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }

        private static void TryRegisterAbcPdf()
        {
            try
            {
                var abcPdfLicenseKey = ConfigurationManager.AppSettings["AbcPdfLicense"];

                if (!string.IsNullOrWhiteSpace(abcPdfLicenseKey))
                {
                    var success = WebSupergoo.ABCpdf7.XSettings.InstallRedistributionLicense(abcPdfLicenseKey);
                    Debug.WriteLine("ABC PDF Registered: {0}", success);
                }
            }
            catch
            {
            }
        }
    }
}