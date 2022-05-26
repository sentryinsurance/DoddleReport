using System.Configuration;
using System;
using System.Linq;

namespace DoddleReport.Legacy.Configuration
{
    [ConfigurationCollection(typeof(WriterElement), CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
    public class WriterElementCollection : ConfigurationElementCollection
    {

        protected override ConfigurationElement CreateNewElement()
        {
            return new WriterElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((WriterElement)element).Format;
        }


        public void LoadConfiguration()
        {
            foreach (WriterElement element in this)
            {
                DoddleReport.Configuration.Config.Report.Writers.Add(new DoddleReport.Configuration.WriterElement
                {
                     ContentType = element.ContentType,
                     Format = element.Format,   
                     FileExtension = element.FileExtension,
                     OfferDownload = element.OfferDownload,
                     Writer = element.LoadWriter()
                });
            }
        }


    }
}