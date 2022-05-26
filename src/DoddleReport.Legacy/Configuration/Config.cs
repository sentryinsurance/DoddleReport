using System.Configuration;

namespace DoddleReport.Legacy.Configuration
{
    public static class Config
    {
        public static void LoadConfiguration()
        {

             var section = ConfigurationManager.GetSection("doddleReport") as DoddleReportSection;
             
            if (section != null)
            {
                section.LoadConfiguration();
            }

        }   
        

    }
}