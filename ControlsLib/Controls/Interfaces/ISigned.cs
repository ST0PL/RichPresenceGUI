using System.Windows;
using System.Windows.Media;

namespace ControlsLib.Controls.Interfaces
{
    public interface ISigned
    {
        public string Title { get; set; }
        public double TitleFontSize { get; set; }
        public FontWeight TitleFontWeight { get; set; }
        public FontStyle TitleFontStyle { get; set; }
        public FontFamily TitleFontFamily { get; set; }
        public FontStretch TitleFontStretch { get; set; }
        public Brush TitleForeground { get; set; }
        public double TitleOpacity { get; set; }
    }
}
