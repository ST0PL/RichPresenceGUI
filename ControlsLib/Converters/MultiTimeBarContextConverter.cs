using ControlsLib.Models;
using System.Globalization;
using System.Windows.Data;

namespace ControlsLib.Converters
{
    public class MultiTimeBarContextConverter : IMultiValueConverter
    {
        public object? Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            TimeBarContext? timeBarContext = null;
            if (values is [ulong startStamp, ulong endStamp])
            {
                long startDelta = DateTimeOffset.Now.ToUnixTimeMilliseconds() - (long)startStamp;
                long endDelta = (long)(endStamp - startStamp);
                startDelta = startDelta > endDelta ? endDelta : startDelta;
                var percents = Math.Min(1, (double)startDelta / endDelta)*100;
                var startSpan = TimeSpan.FromMilliseconds(startDelta);
                var endSpan = TimeSpan.FromMilliseconds(endDelta);
                long[] hoursWithDays = [startSpan.Days * 24 + startSpan.Hours, endSpan.Days * 24 + endSpan.Hours];
                timeBarContext = new TimeBarContext()
                {
                    StartSpan = $"{(hoursWithDays[0] > 0 ? $"{hoursWithDays[0]:00}:" : "")}{startSpan.Minutes:00}:{startSpan.Seconds:00}",
                    Percents = percents,
                    EndSpan = $"{(hoursWithDays[1] > 0 ? $"{hoursWithDays[1]:00}:" : "")}{endSpan.Minutes:00}:{endSpan.Seconds:00}"
                };

            }
            return timeBarContext;
        }

        public object[]? ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
            => null;
    }
}
