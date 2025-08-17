using System.Windows.Media;

namespace ControlsLib.Controls.Interfaces
{
    public interface IResponsive
    {
        public Brush HoverBackgroundColor { get; set; }
        public Brush ClickBackgroundColor { get; set; }
    }
}
