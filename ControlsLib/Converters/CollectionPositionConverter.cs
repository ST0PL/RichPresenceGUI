using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Collections;
using System.Windows;

namespace ControlsLib.Converters
{
    public class CollectionPositionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            FrameworkElement control = (FrameworkElement)value;
            ListBox? listBox = TreeTools.GetVisualParent<ListBox>(control);
            return (((listBox?.ItemsSource as IList)?.IndexOf(control.DataContext) ?? 0)+1).ToString();
        }
        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => null;
    }
}
