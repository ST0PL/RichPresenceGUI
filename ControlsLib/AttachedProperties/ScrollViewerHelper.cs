using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ControlsLib.AttachedProperties
{
    public static class ScrollViewerHelper
    {
        private static Dictionary<string, PropertyInfo> properties =
            typeof(Controls.ScrollViewer).GetProperties().ToDictionary(p => p.Name);

        public static readonly DependencyProperty ScrollBarWidthProperty
            = DependencyProperty.RegisterAttached("ScrollBarWidth", typeof(double), typeof(ScrollViewerHelper),
                new PropertyMetadata(SystemParameters.VerticalScrollBarWidth, OnPropertyChanged));
        public static readonly DependencyProperty ScrollBarBackgroundProperty
            = DependencyProperty.RegisterAttached("ScrollBarBackground", typeof(Brush), typeof(ScrollViewerHelper),
                new PropertyMetadata(OnPropertyChanged));
        public static readonly DependencyProperty ScrollBarCornerRadiusProperty
            = DependencyProperty.RegisterAttached("ScrollBarCornerRadius", typeof(CornerRadius?), typeof(ScrollViewerHelper),
                new PropertyMetadata(OnPropertyChanged));
        public static readonly DependencyProperty ScrollBarThumbBackgroundProperty
            = DependencyProperty.RegisterAttached("ScrollBarThumbBackground", typeof(Brush), typeof(ScrollViewerHelper),
                new PropertyMetadata(OnPropertyChanged));
        public static readonly DependencyProperty HoverScrollBarThumbBackgroundProperty
            = DependencyProperty.RegisterAttached("HoverScrollBarThumbBackground", typeof(Brush), typeof(ScrollViewerHelper),
                new PropertyMetadata(OnPropertyChanged));
        public static readonly DependencyProperty ClickScrollBarThumbBackgroundProperty
            = DependencyProperty.RegisterAttached("ClickScrollBarThumbBackground", typeof(Brush), typeof(ScrollViewerHelper),
                new PropertyMetadata(OnPropertyChanged));
        public static readonly DependencyProperty ScrollBarThumbCornerRadiusProperty
            = DependencyProperty.RegisterAttached("ScrollBarThumbCornerRadius", typeof(CornerRadius?), typeof(ScrollViewerHelper),
                new PropertyMetadata(OnPropertyChanged));
        public static readonly DependencyProperty ScrollBarThumbWidthProperty
            = DependencyProperty.RegisterAttached("ScrollBarThumbWidth", typeof(double), typeof(ScrollViewerHelper),
                new PropertyMetadata(SystemParameters.VerticalScrollBarWidth, OnPropertyChanged));

        public static double GetScrollBarWidth(DependencyObject obj)
            => (double)obj.GetValue(ScrollBarWidthProperty);
        public static void SetScrollBarWidth(DependencyObject obj, double value)
            => obj.SetValue(ScrollBarWidthProperty, value);

        public static Brush GetScrollBarBackground(DependencyObject obj)
            => (Brush)obj.GetValue(ScrollBarBackgroundProperty);
        public static void SetScrollBarBackground(DependencyObject obj, Brush value)
            => obj.SetValue(ScrollBarBackgroundProperty, value);

        public static CornerRadius? GetScrollBarCornerRadius(DependencyObject obj)
            => obj.GetValue(ScrollBarCornerRadiusProperty) as CornerRadius?;
        public static void SetScrollBarCornerRadius(DependencyObject obj, CornerRadius value)
            => obj.SetValue(ScrollBarCornerRadiusProperty, value);

        public static Brush GetScrollBarThumbBackground(DependencyObject obj)
            => (Brush)obj.GetValue(ScrollBarThumbBackgroundProperty);
        public static void SetScrollBarThumbBackground(DependencyObject obj, Brush value)
            => obj.SetValue(ScrollBarThumbBackgroundProperty, value);

        public static Brush GetHoverScrollBarThumbBackground(DependencyObject obj)
            => (Brush)obj.GetValue(HoverScrollBarThumbBackgroundProperty);
        public static void SetHoverThumbBackground(DependencyObject obj, Brush value)
            => obj.SetValue(HoverScrollBarThumbBackgroundProperty, value);

        public static Brush GetClickScrollBarThumbBackground(DependencyObject obj)
            => (Brush)obj.GetValue(ClickScrollBarThumbBackgroundProperty);
        public static void SetClickScrollBarThumbBackground(DependencyObject obj, Brush value)
            => obj.SetValue(ClickScrollBarThumbBackgroundProperty, value);

        public static CornerRadius? GetScrollBarThumbCornerRadius(DependencyObject obj)
            => obj.GetValue(ScrollBarThumbCornerRadiusProperty) as CornerRadius?;
        public static void SetScrollBarThumbCornerRadius(DependencyObject obj, CornerRadius value)
            => obj.SetValue(ScrollBarThumbCornerRadiusProperty, value);

        public static double GetScrollBarThumbWidth(DependencyObject obj)
            => (double)obj.GetValue(ScrollBarThumbWidthProperty);
        public static void SetScrollBarThumbWidth(DependencyObject obj, double value)
            => obj.SetValue(ScrollBarThumbWidthProperty, value);


        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is Control control)
            {
                RoutedEventHandler? handler = null;
                if(control.IsLoaded)
                    SetScrollViewerValue(d, e.Property, e.NewValue);
                else
                {
                    handler = (_, _) =>
                    {
                        SetScrollViewerValue(d, e.Property, e.NewValue);
                        control.Loaded -= handler;
                    };
                    control.Loaded += handler;
                }
            }
        }
        private static void SetScrollViewerValue(DependencyObject d, DependencyProperty property, object value)
        {
            var scrollViewer = TreeTools.GetChild<Controls.ScrollViewer>(d);
            if (scrollViewer is null)
                return;
            properties[property.Name]?.SetValue(scrollViewer, value);
        }
    }
}
