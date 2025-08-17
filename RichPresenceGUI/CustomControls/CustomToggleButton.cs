using ControlsLib.Controls.Interfaces;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace RichPresenceGUI.CustomControls
{
    class RoundedToggleButton : ToggleButton, IRounded
    {
        public static DependencyProperty? CornerRadiusProperty
            = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(RoundedToggleButton));

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
    }
}
