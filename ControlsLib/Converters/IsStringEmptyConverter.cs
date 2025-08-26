using System.Globalization;
using System.Windows.Data;

namespace ControlsLib.Converters
{
    public class IsStringEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => value is not string str || string.IsNullOrEmpty(str);

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => null;
    }
}
