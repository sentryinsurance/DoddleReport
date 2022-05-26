

using System.Collections.Generic;

namespace DoddleReport.Configuration
{
    public sealed class DoddleReportSection
    {
        public WriterElementCollection Writers { get; set; } = new WriterElementCollection();

        public StyleElementCollection Styles { get; set; } = new StyleElementCollection();

        public string DefaultWriter { get; set; } = "Html";

        public string DataRowStyleName { get; set; } = "DataRowStyle";

        public string HeaderRowStyleName { get; set; } = "HeaderRowStyle";

        public string FooterRowStyleName { get; set; } = "FooterRowStyle";
    }
}