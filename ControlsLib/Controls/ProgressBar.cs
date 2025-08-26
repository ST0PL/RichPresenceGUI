using ControlsLib.Controls.Interfaces;
using System.Windows;

namespace ControlsLib.Controls
{
    public class ProgressBar : System.Windows.Controls.ProgressBar, IRounded
    {
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ProgressBar));
        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        static ProgressBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(ProgressBar),
                new FrameworkPropertyMetadata(typeof(ProgressBar)));
        }
    }
}
