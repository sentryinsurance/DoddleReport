﻿using System;
using System.Drawing;
using System.Text;

namespace DoddleReport
{
    public static class HtmlFormatHelper
    {
        public static string ToCss(this ReportStyle style)
        {
            var css = new StringBuilder();

            css.Append(style.Bold ? "font-weight: bold;" : "font-weight: normal;");
            css.Append(style.Underline ? "text-decoration: underline;" : "text-decoration: none;");
            css.Append(style.Italic ? "font-style: italic;" : "font-style: none;");

            if (style.BackColor != Color.White)
            {
                css.AppendFormat("background-color: {0};", ToHtml(style.BackColor));
            }

            if (style.ForeColor != Color.Black)
            {
                css.AppendFormat("color: {0};", ToHtml(style.ForeColor));
            }

            if (style.FontSize != 8)
            {
                css.AppendFormat("font-size: {0}pt;", style.FontSize);
            }

            
            css.AppendFormat("text-align: {0};", style.HorizontalAlignment);
            
            css.AppendFormat("vertical-align: {0};", style.VerticalAlignment);

            if (style.Width != 0)
            {
                css.AppendFormat("width: {0}px", style.Width);
            }

            if (style.TextRotation != 0)
            {
                var degrees = style.TextRotation*-1;

                css.AppendFormat("-webkit-transform: rotate({0}deg);", degrees);
                css.AppendFormat("-moz-transform: rotate({0}deg);", degrees);
                css.AppendFormat("-ms-transform: rotate({0}deg);", degrees);
                css.AppendFormat("-o-transform: rotate({0}deg);", degrees);
                css.AppendFormat("transform: rotate({0}deg);", degrees);

                var rad = degrees*Math.PI/180;
                var costheta = Math.Cos(rad);
                var sintheta = Math.Sin(rad);

                css.AppendFormat("filter: progid:DXImageTransform.Microsoft.Matrix(/* IE6–IE9 */ M11={0}, M12={1}, M21={2}, M22={3}, sizingMethod='auto expand');zoom: 1;", costheta, -sintheta, sintheta, costheta);
            }

            return css.ToString();

        }

        public static string FormatHtml(this string source)
        {
            return source.Replace(Environment.NewLine, "<br />");
        }

        // This is copied from the System.Drawing.ColorTranslator.ToHtml source code, to avoid a dependency on System.Drawing.Common
        // https://referencesource.microsoft.com/#System.Drawing/commonui/System/Drawing/Advanced/ColorTranslator.cs
        private static string ToHtml(Color c)
        {
            string colorString = String.Empty;

            if (c.IsEmpty)
                return colorString;

             if (c.IsNamedColor)
            {
                if (c == Color.LightGray)
                {
                    // special case due to mismatch between Html and enum spelling
                    colorString = "LightGrey";
                }
                else
                {
                    colorString = c.Name;
                }
            }
            else
            {
                colorString = "#" + c.R.ToString("X2", null) +
                                    c.G.ToString("X2", null) +
                                    c.B.ToString("X2", null);
            }

            return colorString;
        }
    }
}
