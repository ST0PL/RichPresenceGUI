using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace ControlsLib.AttachedProperties
{
    public class PanelChildrenProperties
    {
        private static Dictionary<string, PropertyInfo> Properties
            = typeof(Panel).GetProperties().ToDictionary(p => p.Name);

        public static readonly DependencyProperty MarginProperty
            = DependencyProperty.RegisterAttached("Margin", typeof(Thickness), typeof(PanelChildrenProperties),
                new PropertyMetadata(OnMarginChanged));

        public static readonly DependencyProperty WidthProperty
            = DependencyProperty.RegisterAttached("Width", typeof(double), typeof(PanelChildrenProperties),
                new PropertyMetadata(OnWidthChanged));

        public static Thickness GetMargin(DependencyObject obj)
            => (Thickness)obj.GetValue(MarginProperty);

        public static void SetMargin(DependencyObject obj, Thickness value)
            => obj.SetValue(MarginProperty, value);

        public static double GetWidth(DependencyObject obj)
            => (double)obj.GetValue(WidthProperty);

        public static void SetWidth(DependencyObject obj, Thickness value)
            => obj.SetValue(WidthProperty, value);

        public static void OnMarginChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
            => OnValueChanged(obj, e, "Margin");

        public static void OnWidthChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
            => OnValueChanged(obj,e, "Width");

        private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e, string propertyName)
        {
            if (obj is Panel panel)
            {
                if (panel.IsLoaded)
                    ApplyValue(panel, Properties[propertyName], e.NewValue);
                else
                {
                    RoutedEventHandler onLoad = null;
                    onLoad = (object sender, RoutedEventArgs args)
                        => { ApplyValue(panel, Properties[propertyName], e.NewValue); panel.Loaded -= onLoad; };
                    panel.Loaded += onLoad;
                }
            }
        }
        public void OnLoad(object sender, RoutedEventArgs args, Action action)
            => action();
        static void ApplyValue(Panel panel, PropertyInfo property, object newValue)
        {
            foreach (FrameworkElement item in panel.Children)
                property.SetValue(item, newValue);
        }
    }
}
