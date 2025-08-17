using System.Globalization;
using System.Windows.Data;

namespace ControlsLib.Converters
{
    public class LessThanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => value is double num && double.TryParse(parameter as string ?? "0", out var param) ? num < param : false;

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => null;
    }
}
