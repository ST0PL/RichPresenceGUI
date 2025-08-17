using DiscordRPC.Logging;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace RichPresenceGUI.Services
{
    internal class Logger : ILogger
    {
        public class Log(LogLevel level, string message)
        {
            public LogLevel Level => level;
            public string Message => message;
            public override string ToString()
                => Message;
        }

        private ObservableCollection<Log> _loggerCollection;
        private Dispatcher _componentDispatcher;

        public LogLevel Level { get; set; }

        public Logger(ObservableCollection<Log> loggerCollection, LogLevel level, Dispatcher componentDispatcher)
        {
            _loggerCollection = loggerCollection;
            Level = level;
            _componentDispatcher = componentDispatcher;
        }

        public void Error(string message, params object[] args)
            => Add(LogLevel.Error, string.Format(message, args));

        public void Info(string message, params object[] args)
            => Add(LogLevel.Info, string.Format(message, args));

        public void Trace(string message, params object[] args)
            => Add(LogLevel.Trace, string.Format(message, args));

        public void Warning(string message, params object[] args)
            => Add(LogLevel.Warning, string.Format(message, args));

        private void Add(LogLevel level, string message)
            => _componentDispatcher.Invoke(() => _loggerCollection.Add(new Log(level, message)));
    }
}
