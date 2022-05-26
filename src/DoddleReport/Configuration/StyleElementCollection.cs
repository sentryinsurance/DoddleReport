
using System.Collections.Generic;
using System.Linq;

namespace DoddleReport.Configuration
{
    public class StyleElementCollection : List<StyleElement>
    {

        public StyleElement this[string name]
        {
            get
            {
                var existing = this.FirstOrDefault(s => s.Name == name);
                if (existing != null) return existing;
                var newStyle = new StyleElement { Name = name };
                this.Add(newStyle);
                return newStyle;
            }
        }

        //public StyleElement this[ReportRowType rowType]
        //{
        //    get
        //    {
        //        return this[rowType.ToString()];
        //    }
        //}

    }
}