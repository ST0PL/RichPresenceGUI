using System.Windows;
using System.Windows.Controls;
using DiscordRPC.Logging;
using Log = RichPresenceGUI.Services.Logger.Log;

namespace RichPresenceGUI.DataTemplateSelectors
{
    class LogTemplateSelector : DataTemplateSelector
    {
        public DataTemplate? TraceTemplate { get; set; }
        public DataTemplate? InfoTemplate { get; set; }
        public DataTemplate? WarningTemplate { get; set; }
        public DataTemplate? ErrorTemplate { get; set; }

        public override DataTemplate? SelectTemplate(object item, DependencyObject container)
            => item switch
            {
                Log log => log.Level switch
                {
                    LogLevel.Trace => TraceTemplate,
                    LogLevel.Info => InfoTemplate,
                    LogLevel.Warning => WarningTemplate,
                    LogLevel.Error => ErrorTemplate,
                    _=> TraceTemplate,
                },
                _ => TraceTemplate
            };
    }
}
