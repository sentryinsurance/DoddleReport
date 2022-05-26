using System.Configuration;

namespace DoddleReport.Legacy.Configuration
{
    [ConfigurationCollection(typeof(StyleElement), CollectionType = ConfigurationElementCollectionType.BasicMap, AddItemName="style")]
    public class StyleElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new StyleElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((StyleElement)element).Name;
        }


        public void LoadConfiguration()
        {
            foreach (StyleElement element in this)
            {
                DoddleReport.Configuration.Config.Report.Styles.Add(new DoddleReport.Configuration.StyleElement
                {
                     BackColor = element.BackColor, 
                     Bold = element.Bold,
                     FontSize = element.FontSize,
                     ForeColor = element.ForeColor,
                     Italic = element.Italic,
                     Name = element.Name,
                     TextRotation = element.TextRotation,
                     Underline = element.Underline
                });
            }
        }

    }
}