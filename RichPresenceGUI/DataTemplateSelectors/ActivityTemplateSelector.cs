using System.Windows;
using System.Windows.Controls;
using DiscordRPC;
using RichPresenceGUI.CustomControls;

namespace RichPresenceGUI.DataTemplateSelectors
{
    class ActivityTemplateSelector : DataTemplateSelector
    {
        public DataTemplate? DefaultTemplate { get; set; }
        public DataTemplate? PlayingWithPartyTemplate { get; set; }
        public DataTemplate? ListeningTimeBarTemplate { get; set; }
        public DataTemplate? ListeningTemplate { get; set; }
        public DataTemplate? WatchingTimeBarTemplate { get; set; }
        public DataTemplate? WatchingTemplate { get; set; }
        public DataTemplate? CompetingTemplate { get; set; }

        public override DataTemplate? SelectTemplate(object item, DependencyObject container)
            => item switch
            {
                VisualTemplate template when template is { ActivityType: ActivityType.Playing }
                    => DefaultTemplate,
                VisualTemplate template when template is { ActivityType: ActivityType.Playing, Party: { } }
                    => PlayingWithPartyTemplate,
                VisualTemplate template when template is { ActivityType: ActivityType.Listening } && ValidateTimestamps(template.StartTimestamp, template.EndTimestamp)
                    => ListeningTimeBarTemplate,
                VisualTemplate template when template is { ActivityType: ActivityType.Listening }
                    => ListeningTemplate,
                VisualTemplate template when template is { ActivityType: ActivityType.Watching } && ValidateTimestamps(template.StartTimestamp, template.EndTimestamp)
                    => WatchingTimeBarTemplate,
                VisualTemplate template when template is { ActivityType: ActivityType.Watching }
                    => WatchingTemplate,
                VisualTemplate template when template is { ActivityType: ActivityType.Competing }
                    => CompetingTemplate,
                _ => DefaultTemplate
            };
        private static bool ValidateTimestamps(ulong? startStamp, ulong? endStamp)
        {
            ulong nowTimestamp = (ulong)DateTimeOffset.Now.ToUnixTimeMilliseconds();
            return startStamp <= nowTimestamp && startStamp < endStamp;
        }
    }
}
