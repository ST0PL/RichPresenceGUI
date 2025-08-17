using System.Globalization;
using System.Windows.Data;

namespace RichPresenceGUI.Converters
{
    class TimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not ulong startTimestamp)
                return string.Empty;
            TimeSpan? timeSpan = TimeSpan.FromMilliseconds(DateTimeOffset.Now.ToUnixTimeMilliseconds() - (long)startTimestamp);
            int hoursWithDays = timeSpan.Value.Days * 24 + timeSpan.Value.Hours;
            return $"{(hoursWithDays > 0 ? $"{hoursWithDays:00}:":null)}{timeSpan.Value.Minutes:00}:{timeSpan.Value.Seconds:00}";
        }
        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => null;
    }
}
