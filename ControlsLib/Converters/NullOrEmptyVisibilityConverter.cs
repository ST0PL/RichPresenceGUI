using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ControlsLib.Converters
{
    public class NullOrEmptyVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str)
                return string.IsNullOrEmpty(str) ? Visibility.Collapsed : Visibility.Visible;
            return value is null ? Visibility.Collapsed : Visibility.Visible;
        }
 
        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => null;
    }
}
