using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ControlsLib.Converters
{
    public class InverseNullOrEmptyVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str)
                return !string.IsNullOrEmpty(str) ? Visibility.Collapsed : Visibility.Visible;
            return value is null ? Visibility.Visible : Visibility.Collapsed;
        }
 
        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => null;
    }
}
