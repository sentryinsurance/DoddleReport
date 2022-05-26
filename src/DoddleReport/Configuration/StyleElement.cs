using System.Drawing;

namespace DoddleReport.Configuration
{
    public sealed class StyleElement
    {
        public string Name { get; set; }

        public bool Bold { get; set; } = false;

        public bool Underline { get; set; } = false;

        public bool Italic { get; set; } = false;

        public int FontSize { get; set; } = 9;

        public int TextRotation { get; set; } = 0;

        public Color BackColor { get; set; } = Color.White;

        public Color ForeColor { get; set; } = Color.Black;

        internal void ApplyStyle(ReportStyle reportStyle)
        {
            reportStyle.Bold = Bold;
            reportStyle.Underline = Underline;
            reportStyle.Italic = Italic;

            reportStyle.BackColor = BackColor;
            reportStyle.ForeColor = ForeColor;

            reportStyle.FontSize = FontSize;
            reportStyle.TextRotation = TextRotation;
        }
    }
}