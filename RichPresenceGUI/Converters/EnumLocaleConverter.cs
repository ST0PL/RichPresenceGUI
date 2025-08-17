using DiscordRPC;
using RichPresenceGUI.Models.enums;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RichPresenceGUI.Converters
{
    class EnumLocaleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var resources = Application.Current.Resources;
            return value switch
            {
                ActivityType activityType => activityType switch
                {
                    ActivityType.Playing => resources["activity_type_playing"],
                    ActivityType.Listening => resources["activity_type_listening"],
                    ActivityType.Watching => resources["activity_type_watching"],
                    ActivityType.Competing => resources["activity_type_competing"],
                    _ => string.Empty
                },
                NotificationType notificationType => notificationType switch
                {
                    NotificationType.Information => resources["nw_type_information"],
                    NotificationType.Error => resources["nw_type_error"],
                    NotificationType.Exception => resources["nw_type_exception"],
                    _ => string.Empty
                },
                StatusDisplayType displayType => displayType switch
                {
                    StatusDisplayType.Name => resources["statusDisplay_type_name"],
                    StatusDisplayType.State => resources["statusDisplay_type_state"],
                    StatusDisplayType.Details => resources["statusDisplay_type_details"],
                    _ =>string.Empty
                },
                _ => string.Empty

            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => null;
    }
}
