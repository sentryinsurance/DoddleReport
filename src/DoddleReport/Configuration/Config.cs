using System.Configuration;

namespace DoddleReport.Configuration
{
    public static class Config
    {
        private static DoddleReportSection report = new DoddleReportSection();
        public static DoddleReportSection Report
        {
            get
            {
                return report;
            }
        }        
    }
}