using System.Windows;
using System.Windows.Media;

namespace ControlsLib.Controls
{
    public class ScrollViewer : System.Windows.Controls.ScrollViewer
    {
        public static readonly DependencyProperty ScrollBarWidthProperty
            = DependencyProperty.Register("ScrollBarWidth", typeof(double), typeof(ScrollViewer));
        public static readonly DependencyProperty ScrollBarBackgroundProperty
            = DependencyProperty.Register("ScrollBarBackground", typeof(Brush), typeof(ScrollViewer));
        public static readonly DependencyProperty ScrollBarCornerRadiusProperty
            = DependencyProperty.Register("ScrollBarCornerRadius", typeof(CornerRadius), typeof(ScrollViewer));
        public static readonly DependencyProperty ScrollBarThumbBackgroundProperty
            = DependencyProperty.Register("ScrollBarThumbBackground", typeof(Brush), typeof(ScrollViewer));
        public static readonly DependencyProperty HoverScrollBarThumbBackgroundProperty
            = DependencyProperty.Register("HoverScrollBarThumbBackground", typeof(Brush), typeof(ScrollViewer));
        public static readonly DependencyProperty ClickScrollBarThumbBackgroundProperty
            = DependencyProperty.Register("ClickScrollBarThumbBackground", typeof(Brush), typeof(ScrollViewer));
        public static readonly DependencyProperty ScrollBarThumbCornerRadiusProperty
            = DependencyProperty.Register("ScrollBarThumbCornerRadius", typeof(CornerRadius), typeof(ScrollViewer));
        public static readonly DependencyProperty ScrollBarThumbWidthProperty
            = DependencyProperty.Register("ScrollBarThumbWidth", typeof(double), typeof(ScrollViewer));

        public double ScrollBarWidth
        {
            get => (double)GetValue(ScrollBarWidthProperty);
            set => SetValue(ScrollBarWidthProperty, value);
        }

        public Brush ScrollBarBackground
        {
            get => (Brush)GetValue(ScrollBarBackgroundProperty);
            set => SetValue(ScrollBarBackgroundProperty, value);
        }

        public CornerRadius ScrollBarCornerRadius
        {
            get => (CornerRadius)GetValue(ScrollBarCornerRadiusProperty);
            set => SetValue(ScrollBarCornerRadiusProperty, value);
        }

        public Brush ScrollBarThumbBackground
        {
            get => (Brush)GetValue(ScrollBarThumbBackgroundProperty);
            set => SetValue(ScrollBarThumbBackgroundProperty, value);
        }

        public Brush HoverScrollBarThumbBackground
        {
            get => (Brush)GetValue(HoverScrollBarThumbBackgroundProperty);
            set => SetValue(HoverScrollBarThumbBackgroundProperty, value);
        }

        public Brush ClickScrollBarThumbBackground
        {
            get => (Brush)GetValue(ClickScrollBarThumbBackgroundProperty);
            set => SetValue(ClickScrollBarThumbBackgroundProperty, value);
        }

        public CornerRadius ScrollBarThumbCornerRadius
        {
            get => (CornerRadius)GetValue(ScrollBarThumbCornerRadiusProperty);
            set => SetValue(ScrollBarThumbCornerRadiusProperty, value);
        }

        public double ScrollBarThumbWidth
        {
            get => (double)GetValue(ScrollBarThumbWidthProperty);
            set => SetValue(ScrollBarThumbWidthProperty, value);
        }
        static ScrollViewer()
            => DefaultStyleKeyProperty.OverrideMetadata(typeof(ScrollViewer),
                new FrameworkPropertyMetadata(typeof(ScrollViewer)));
    }
}
