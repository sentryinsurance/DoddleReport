using System;

namespace DoddleReport.Configuration
{
    public class WriterElement
    {
        public string Format { get; set; }

        public IReportWriter Writer { get; set; }

        public string ContentType { get; set; } = "text/html";

        public bool OfferDownload { get; set; } = false;

        public string FileExtension { get; set; }

        public IReportWriter LoadWriter()
        {
            return Writer;
        }     
    }
}