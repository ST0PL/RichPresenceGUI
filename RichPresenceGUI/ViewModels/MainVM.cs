using RichPresenceGUI.Events;
using RichPresenceGUI.Models;
using RichPresenceGUI.Services.Interfaces;
using RichPresenceGUI.Views;
using System.Windows.Controls;
using System.Windows.Input;

namespace RichPresenceGUI.ViewModels
{
    public class MainVM : ObservableObject
    {
        private UserControl[] _views;
        private UserControl? _currentView;
        private IThemeService _themeService;
        private ISettingsService<Settings> _settingsService;
        private ILocalizationService _localizationService;
        private IEventAggregator _eventAggregator;
        private bool _themeToggled;
        private string? _currentLocale;
        private ICommand _toggleThemeCommand;
        private ICommand _changeLocaleCommand;
        private ICommand _changeViewCommand;

        public UserControl? CurrentView
        {
            get => _currentView;
            set
            {
                if (_currentView != value)
                {
                    _currentView = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool ThemeToggled
        {
            get => _themeToggled;
            set
            {
                _themeToggled = value;
                OnPropertyChanged();
            }
        }
        public IEnumerable<string>? Locales => _localizationService.GetLocaleNames();
        
        public string? CurrentLocale
        {
            get => _currentLocale;
            set
            {
                if (!string.IsNullOrEmpty(_currentLocale))
                {
                    _settingsService.GetInstance()!.Locale = value;
                    _settingsService.WriteAsync();
                }
                _currentLocale = value;
                OnPropertyChanged();
            }
        }

        public ICommand ToggleThemeCommand
            => _toggleThemeCommand ??= new RelayCommand(async _ => await ChangeTheme());
        public ICommand ChangeLocaleCommand
            => _changeLocaleCommand ??= new RelayCommand(param =>
            {
                if (param is string locale)
                {
                    _localizationService.SetLocale(locale);
                    _eventAggregator.Publish(new LocaleChangedEvent(locale));
                }
            });

        public ICommand ChangeViewCommand
            => _changeViewCommand ??= new RelayCommand(obj => CurrentView = _views[int.TryParse((string)obj, out var index) ? index : 0]);

        public MainVM(ILocalizationService localizationService,
            IWindowService windowService,
            IThemeService themeService,
            ISettingsService<Settings> settingsService,
            IEventAggregator eventAggregator,
            ITemplateService<Template> templateService)
            => Init(localizationService, windowService, themeService, settingsService, eventAggregator, templateService);

        async Task ChangeTheme()
        {
            _themeService.ToggleTheme();
            _settingsService.GetInstance()!.Theme = ThemeToggled ? Theme.Light : Theme.Dark;
            await _settingsService.WriteAsync();
        }
        async void Init(ILocalizationService localizationService,
            IWindowService windowService,
            IThemeService themeService,
            ISettingsService<Settings> settingsService,
            IEventAggregator eventAggregator,
            ITemplateService<Template> templateService)
        {
            _eventAggregator = eventAggregator;
            _localizationService = localizationService;
            _settingsService = settingsService;
            _themeService = themeService;
            await InitSettings();
            _views = [
                new FieldsView() { DataContext = new FieldsVM(localizationService,windowService, settingsService, eventAggregator,templateService) },
                new TemplatesView() { DataContext = new TemplatesVM(windowService, localizationService, settingsService, eventAggregator, templateService) },
                new DebugView() { DataContext = new DebugVM(windowService, localizationService) }
            ];
            CurrentView = _views[0];
        }
        async Task InitSettings()
        {
            await _settingsService.LoadAsync();
            ThemeToggled = _settingsService.GetInstance()!.Theme == Theme.Light;
            _themeService.SetTheme(_settingsService.GetInstance()!.Theme);
            CurrentLocale = _settingsService.GetInstance()!.Locale;
        }
    }
}
