using RichPresenceGUI.Services;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Forms;
using System.Windows.Threading;
using RichPresenceGUI.Models.enums;
using System.Windows.Input;
using RichPresenceGUI.Services.Interfaces;
using NotificationContext = RichPresenceGUI.NotificationWindow.NotificationContext;

namespace RichPresenceGUI.ViewModels
{
    internal class DebugVM : ObservableObject
    {
        private readonly IWindowService _windowService;
        private readonly ILocalizationService _localizationService;
        private ICommand? _clearCommand;
        private ICommand? _saveToFileCommand;
        public static Logger? Logger { get; private set; }
        public ObservableCollection<Logger.Log>? Messages { get; set; }

        public ICommand ClearCommand =>
            _clearCommand ??= _clearCommand = new RelayCommand((_) => Messages?.Clear(), (_)=> IsButtonsEnabled);

        public ICommand SaveToFileCommand
            => _saveToFileCommand ??= new RelayCommand((_) => SaveToFile(), (_) => IsButtonsEnabled);

        public bool IsButtonsEnabled => Messages?.Count > 0;

        public DebugVM(IWindowService windowService, ILocalizationService localizationService)
        {
            _windowService = windowService;
            _localizationService = localizationService;
            Messages = new ObservableCollection<Logger.Log>();
            Messages.CollectionChanged += (sender, args) => OnPropertyChanged(nameof(IsButtonsEnabled));
            Logger = new Logger(Messages, DiscordRPC.Logging.LogLevel.Info, Dispatcher.CurrentDispatcher);
        }
        void SaveToFile()
        {
            try
            {
                SaveFileDialog openFileDialog = new SaveFileDialog()
                {
                    Filter = "All files|*.*"
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(openFileDialog.FileName, string.Join("\n", Messages ?? []));
                    _windowService.Show<NotificationWindow>(new NotificationContext(NotificationType.Information,
                        string.Format(_localizationService.GetValue("nw_rpUpdated"), openFileDialog.FileName)));
                }
            }
            catch(Exception ex) { _windowService.Show<NotificationWindow>(new NotificationContext(NotificationType.Exception, ex.ToString())); }
        }
    }
}
