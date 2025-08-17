using ControlsLib.Controls.Interfaces;
using System.Windows;
using System.Windows.Media;

namespace ControlsLib.Controls
{
    public class Button : System.Windows.Controls.Button, IRounded, IResponsive
    {
        public static DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(Button));
        public static DependencyProperty HoverBackgroundColorProperty =
            DependencyProperty.Register("HoverBackgroundColor", typeof(Brush), typeof(Button));
        public static DependencyProperty ClickBackgroundColorProperty =
            DependencyProperty.Register("ClickBackgroundColor", typeof(Brush), typeof(Button));
        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        public Brush HoverBackgroundColor
        {
            get => (Brush)GetValue(HoverBackgroundColorProperty);
            set => SetValue(HoverBackgroundColorProperty, value);
        }
        public Brush ClickBackgroundColor
        {
            get => (Brush)GetValue(ClickBackgroundColorProperty);
            set => SetValue(ClickBackgroundColorProperty, value);
        }
        static Button()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(Button),
                new FrameworkPropertyMetadata(typeof(Button)));
        }
    }
}
