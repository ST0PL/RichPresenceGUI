using System.Globalization;
using System.Windows.Data;

namespace RichPresenceGUI.Converters
{
    class IncreaseIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int num = (int)value;
            return ++num;
        }

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => null;
    }
}
