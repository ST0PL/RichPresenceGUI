using ControlsLib.Controls.Interfaces;
using System.Windows;

namespace ControlsLib.Controls
{
    public class ToggleButton : System.Windows.Controls.Primitives.ToggleButton, IRounded
    {
        public static DependencyProperty? CornerRadiusProperty
            = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ToggleButton));

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        static ToggleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(ToggleButton),
                new FrameworkPropertyMetadata(typeof(ToggleButton)));
        }
    }
}
