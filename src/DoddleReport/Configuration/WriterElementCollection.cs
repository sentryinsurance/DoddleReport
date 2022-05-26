using System.Configuration;
using System;
using System.Linq;
using System.Collections.Generic;

namespace DoddleReport.Configuration
{
    public class WriterElementCollection : List<WriterElement>
    {
        public WriterElementCollection()
        {
            AddDefaults();
        }

        public void AddDefaults()
        {
            var htmlElement = new WriterElement
             {
                 Format = "Html",
                 Writer = new DoddleReport.Writers.HtmlReportWriter(),
                 ContentType = "text/html",
                 FileExtension = ".htm"
             };

            var excelElement = new WriterElement
            {
                Format = "Excel",
                Writer = new DoddleReport.Writers.ExcelReportWriter(),
                ContentType = "application/vnd.ms-excel",
                FileExtension = ".xls"
            };

            var txtElement = new WriterElement
            {
                Format = "Delimited",
                Writer = new DoddleReport.Writers.DelimitedTextReportWriter(),
                ContentType = "text/plain",
                FileExtension = ".txt",
                OfferDownload = true
            };

            Add(htmlElement);
            Add(txtElement);
            Add(excelElement); 
        }

        public WriterElement GetWriterConfigurationByFormat(string format)
        {
            var writerElement = this.FirstOrDefault(k => k.Format.Equals(format, StringComparison.OrdinalIgnoreCase));

            if(writerElement == null)
                throw new ArgumentException(string.Format("Unable to locate a ReportWriter Configuration with the format '{0}'. Has this format been registered in configuration?", format));

            return writerElement;
        }

        public WriterElement GetWriterConfigurationForFileExtension(string extension)
        {

            var writerElement = this.FirstOrDefault(k => k.FileExtension.Equals(extension, StringComparison.OrdinalIgnoreCase));

            if (writerElement == null)
                throw new ArgumentException(string.Format("Unable to locate a ReportWriter Configuration with the extension '{0}'. Has this format been registered in configuration?", extension));

            return writerElement;
        }


        public IReportWriter GetWriterForFileExtension(string extension)
        {
            try
            {
                var writer = GetWriterConfigurationForFileExtension(extension).Writer;
                return writer;
            }
            catch
            {
                throw new InvalidOperationException(string.Format("Unable to locate report writer by the name of '{0}'"));
            }
        }

        public IReportWriter GetWriterByName(string name)
        {
            try
            {
                var writer = GetWriterConfigurationByFormat(name).Writer;
                return writer;
            }
            catch
            {
                throw new InvalidOperationException(string.Format("Unable to locate report writer by the name of '{0}'")); 
            }
        }


    }
}