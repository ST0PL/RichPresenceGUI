using System.Windows;
using System.Windows.Media;

namespace ControlsLib.Controls.Interfaces
{
    public interface IImageControl
    {
        public ImageSource ImageSource { get; set; }
        public double ImageWidth { get; set; }
        public Thickness ImageMargin {  get; set; }
    }
}
