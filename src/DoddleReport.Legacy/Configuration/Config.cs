using System.Configuration;

namespace DoddleReport.Legacy.Configuration
{
    public static class Config
    {
        public static DoddleReportSection Report
        {
            get
            {
                 var section = ConfigurationManager.GetSection("doddleReport") as DoddleReportSection;
                 return section ?? new DoddleReportSection();
            }
        }        
    }
}