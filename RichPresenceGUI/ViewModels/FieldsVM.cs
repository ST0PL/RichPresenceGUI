using DiscordRPC;
using RichPresenceGUI.Events;
using RichPresenceGUI.Models;
using RichPresenceGUI.Models.enums;
using RichPresenceGUI.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;
using NotificationContext = RichPresenceGUI.NotificationWindow.NotificationContext;
namespace RichPresenceGUI.ViewModels
{
    internal class FieldsVM : ObservableObject
    {
        private IEventAggregator _eventAggregator;
        private ITemplateService<Template> _templateService;
        private IWindowService _windowService;
        private ISettingsService<Settings> _settingsService;
        private ILocalizationService _localizationService;
        private DiscordRpcClient? _rpcClient;
        private bool _isClearPresenceButtonEnabled;
        private Guid _saveTemplateWindowGuid;


        private string? _applicationId;

        // General components

        private string? _state;
        private string? _details;

        // Timestamps

        private long? _startTimestamp;
        private long? _endTimestamp;
        private bool _isStartOffset;
        private bool _isNowOffset;

        private ObservableCollection<RichPresenceButton> _buttons;

        // Large image

        private string? _largeImageKey;
        private string? _largeImageText;

        // Small image

        private string? _smallImageKey;
        private string? _smallImageText;

        // Party

        private int? _size;
        private int? _max;


        private ActivityType _currentActivityType;
        private StatusDisplayType _currentStatusDisplayType;


        public string? ApplicationId
        {
            get => _applicationId;
            set
            {
                if(string.IsNullOrEmpty(value) || value.All(c => c >= '0' && c <= '9'))
                {
                    _applicationId = value;
                    OnPropertyChanged();
                }
                
            }
        }
        public string? State
        {
            get => _state;
            set
            {
                if(_state != value)
                {
                    _state = value;
                    OnPropertyChanged();
                }
            }
        }
        public string? Details
        {
            get => _details;
            set
            {
                if (_details != value)
                {
                    _details = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsAddButtonEnabled => Buttons.Count < 2;

        public string? StartTimestamp
        {
            get => _startTimestamp.ToString();
            set
            {
                if (long.TryParse(value, out var newValue) && newValue > 0)
                    _startTimestamp = newValue;
                else if (string.IsNullOrEmpty(value))
                    _startTimestamp = null;
                OnPropertyChanged();
            }
        }
        public string? EndTimestamp
        {
            get => _endTimestamp.ToString();
            set
            {
                if (long.TryParse(value, out var newValue) && newValue>0)
                    _endTimestamp = newValue;
                else if (string.IsNullOrEmpty(value))
                    _endTimestamp = null;
                OnPropertyChanged();
            }
        }
        public bool IsNowOffset
        {
            get => _isNowOffset;
            set
            {
                _isNowOffset = value;
                OnPropertyChanged();
            }
        }
        public bool IsStartOffset
        {
            get => _isStartOffset;
            set
            {
                _isStartOffset = value;
                OnPropertyChanged();
            }
        }

        public string? LargeImageKey
        {
            get => _largeImageKey;
            set
            {
                if (_largeImageKey != value)
                {
                    _largeImageKey = value;
                    OnPropertyChanged();
                }
            }
        }
        public string? LargeImageText
        {
            get => _largeImageText;
            set
            {
                if (_largeImageText != value)
                {
                    _largeImageText = value;
                    OnPropertyChanged();
                }
            }
        }
        public string? SmallImageKey
        {
            get => _smallImageKey;
            set
            {
                if (_smallImageKey != value)
                {
                    _smallImageKey = value;
                    OnPropertyChanged();
                }
            }
        }
        public string? SmallImageText
        {
            get => _smallImageText;
            set
            {
                if (_smallImageText != value)
                {
                    _smallImageText = value;
                    OnPropertyChanged();
                }
            }
        }
        public string? Size
        {
            get => _size.ToString();
            set 
            {

                if (int.TryParse(value, out var newValue) && newValue > 0)
                    _size = newValue;
                else if (string.IsNullOrEmpty(value))
                    _size = null;
                OnPropertyChanged();
            }
        }
        public string? Max
        {
            get => _max.ToString();
            set
            {

                if(int.TryParse(value, out var newValue) && newValue > 0)
                    _max = newValue;
                else if(string.IsNullOrEmpty(value))
                    _max = null;
                OnPropertyChanged();
            }
        }
        public bool IsClearPresenceButtonEnabled
        {
            get => _isClearPresenceButtonEnabled;
            set
            {
                if(_isClearPresenceButtonEnabled != value)
                {
                    _isClearPresenceButtonEnabled = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsConnected => _rpcClient?.IsInitialized ?? false;

        public ObservableCollection<RichPresenceButton> Buttons
        {
            get => _buttons;
            set
            {
                _buttons = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsAddButtonEnabled));
            }
        }
        public ActivityType CurrentActivityType
        {
            get => _currentActivityType;
            set
            {
                _currentActivityType  = value;
                OnPropertyChanged();
            }
        }
        public StatusDisplayType CurrentStatusDisplayType
        {
            get => _currentStatusDisplayType;
            set
            {
                _currentStatusDisplayType = value;
                OnPropertyChanged();
            }
        }
        public ActivityType[]? ActivityTypes { get; set; }
        public StatusDisplayType[]? StatusDisplayTypes { get; set; }
        public ICommand? AddButtonCommand { get; set; }
        public ICommand? RemoveButtonCommand { get; set; }
        public ICommand? DisconnectCommand { get; set; }
        public ICommand? ConnectCommand { get; set; }
        public ICommand? SaveTemplateCommand { get; set; }
        public ICommand? ClearPresenceCommand { get; set; }
        public ICommand? UpdatePresenceCommand { get; set; }

        public FieldsVM(ILocalizationService localizationService,
            IWindowService windowService,
            ISettingsService<Settings> settingsService,
            IEventAggregator eventAggregator,
            ITemplateService<Template> templateService)
        {
            _localizationService = localizationService;
            _settingsService = settingsService;
            _windowService = windowService;
            _eventAggregator = eventAggregator;
            _templateService = templateService;
            Buttons = new();
            Buttons.CollectionChanged += (_, _) => OnPropertyChanged(nameof(IsAddButtonEnabled));
            _eventAggregator.Subscribe<LocaleChangedEvent>(_ => UpdateEnums());
            _eventAggregator.Subscribe<TemplateSelectedEvent>((obj)=>SetFields(obj.Args));
            _eventAggregator.Subscribe<TemplateSavedEvent>(OnTemplateSaved);
            UpdateEnums();
            InitCommands();
        }
        void InitCommands()
        {
            AddButtonCommand = new RelayCommand((arg) => Buttons.Add(new()));
            RemoveButtonCommand = new RelayCommand((arg) => Buttons.Remove((RichPresenceButton)arg));

            DisconnectCommand = new RelayCommand((arg) => RpcDisconnect(), (arg) => IsConnected);
            ConnectCommand = new RelayCommand((arg) => RpcConnect(), (arg) =>!IsConnected && !string.IsNullOrEmpty(ApplicationId));

            SaveTemplateCommand = new RelayCommand((arg) => OpenSaveTemplateWindow());
            ClearPresenceCommand = new RelayCommand((arg) => _rpcClient?.ClearPresence(), (arg)=> IsConnected);
            UpdatePresenceCommand = new RelayCommand((arg) => SetRichPresence(),
                (obj) => IsConnected && IsTimestampsInputValid() && IsButtonsValid());
        }
        void UpdateEnums()
        {
            ActivityTypes = null;
            StatusDisplayTypes = null;

            OnPropertiesChanged(nameof(ActivityTypes), nameof(StatusDisplayTypes));

            ActivityTypes = Enum.GetValues<ActivityType>();
            StatusDisplayTypes = Enum.GetValues<StatusDisplayType>();

            OnPropertiesChanged(nameof(ActivityTypes), nameof(CurrentActivityType));

            OnPropertiesChanged(nameof(StatusDisplayTypes), nameof(CurrentStatusDisplayType));
        }
        void SetFields(Template template)
        {

            ApplicationId = template.ApplicationId;
            Details = template.RichPresence?.Details;
            State = template.RichPresence?.State;
            StartTimestamp = template.RichPresence?.Timestamps?.StartUnixMilliseconds.ToString();
            EndTimestamp = template.RichPresence?.Timestamps?.EndUnixMilliseconds.ToString();
            IsNowOffset = false;
            IsStartOffset = false;

            if (Buttons.Count > 0)
                Buttons.Clear();

            foreach (var button in template.RichPresence?.Buttons ?? Array.Empty<Button>())
                Buttons.Add(new RichPresenceButton() { Label = button.Label, Url = button.Url });

            LargeImageKey = template.RichPresence?.Assets?.LargeImageKey;
            LargeImageText = template.RichPresence?.Assets?.LargeImageText;
            SmallImageKey = template.RichPresence?.Assets?.SmallImageKey;
            SmallImageText = template.RichPresence?.Assets?.SmallImageText;
            Size = template.RichPresence?.Party?.Size.ToString();
            Max = template.RichPresence?.Party?.Max.ToString();
            CurrentActivityType = template?.RichPresence?.Type ?? default;
            CurrentStatusDisplayType = template?.RichPresence?.StatusDisplay ?? default;
        }
        void RpcConnect()
        {
            _rpcClient = new DiscordRpcClient(ApplicationId, logger: DebugVM.Logger);
            _rpcClient.OnPresenceUpdate += (s, e) =>
            {
                if (!IsClearPresenceButtonEnabled)
                    IsClearPresenceButtonEnabled = true;
                App.Current.Dispatcher.Invoke(() => 
                    _windowService.Show<NotificationWindow>(new NotificationContext(NotificationType.Information, _localizationService.GetValue("nw_rpUpdated"))));
            };
            _rpcClient.OnReady += (_, e) => _eventAggregator.Publish(new CurrentUserUpdatedEvent(e.User));
            _rpcClient.OnError += (_, e) => App.Current.Dispatcher.Invoke(() => _windowService.Show<NotificationWindow>(new NotificationWindow.NotificationContext(NotificationType.Error, e.Message)));
            _rpcClient.Initialize();
            OnPropertyChanged(nameof(IsConnected));
        }
        void RpcDisconnect()
        {
            _rpcClient?.Dispose();
            _eventAggregator.Publish(new CurrentUserUpdatedEvent(null));
            OnPropertyChanged(nameof(IsConnected));
        }
        void SetRichPresence()
            => _rpcClient!.Update(SetRichPresenceProperties);

        void OpenSaveTemplateWindow()
        {
            Template template = new(ApplicationId, new RichPresence());
            SetRichPresenceProperties(template.RichPresence);

            _saveTemplateWindowGuid = _windowService.Show(
                new SaveTemplateWindow(_settingsService, _eventAggregator, _templateService, template));
        }
        void OnTemplateSaved(TemplateSavedEvent @event)
            => _windowService.Close(_saveTemplateWindowGuid);

        void SetRichPresenceProperties(RichPresence richPresence)
        {
            richPresence.State = State;
            richPresence.Details = Details;
            richPresence.Assets = new Assets()
            {
                LargeImageKey = LargeImageKey,
                LargeImageText = LargeImageText,
                SmallImageKey = SmallImageKey,
                SmallImageText = SmallImageText,
            };
            richPresence.Party = _max is not null && (_max >= (_size ?? _max)) ? new Party()
            {
                ID = Guid.NewGuid().ToString(),
                Size = _size.GetValueOrDefault(),
                Max = _max.GetValueOrDefault(),
            } : null;

            long nowStamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            long startStamp = _startTimestamp ?? nowStamp;

            richPresence.Timestamps = new Timestamps()
            {
                StartUnixMilliseconds = (ulong?)(IsNowOffset && _startTimestamp.HasValue ? nowStamp - startStamp : startStamp),
                EndUnixMilliseconds = (ulong?)(IsStartOffset && _endTimestamp.HasValue ? startStamp + _endTimestamp : _endTimestamp)
            };
            richPresence.Type = CurrentActivityType;
            richPresence.StatusDisplay = CurrentStatusDisplayType;
            richPresence.Buttons = [.. Buttons.Select(b => (Button)b)];
        }
        private bool IsTimestampsInputValid()
        {
            long nowMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            long maxUnixMs = DateTimeOffset.MaxValue.ToUnixTimeMilliseconds();
            long minUnixMs = DateTimeOffset.MinValue.ToUnixTimeMilliseconds();

            // if user entered one of timestamps
            if(_startTimestamp.HasValue || _endTimestamp.HasValue)
            {
                var startMs = _startTimestamp.GetValueOrDefault();
                var endMs = _endTimestamp.GetValueOrDefault();

                // if "Use as offset before now" or "Use as offset after start" is checked
                if (IsNowOffset || IsStartOffset)
                    // Checks all conditions:
                    // 1. subtraction of now milliseconds from start milliseconds is more or equals minimum unix epoch milliseconds
                    // 2. sum of start and end milliseconds is less or equals maximum unix epoch milliseconds
                    return (nowMs - startMs >= minUnixMs) && (startMs + endMs) <= maxUnixMs;
                else
                    // Checks all conditions:
                    // 1. start milliseconds is less or equals end milliseconds or end milliseconds not entered 
                    // 2. start milliseconds is less or equals maximum
                    // 3. end milliseconds is less or equals maximum
                    return (endMs == 0 || startMs <= endMs) && startMs <= maxUnixMs && endMs <= maxUnixMs;
            }
            // true if timestamps is empty
            return true;
        }
        private bool IsButtonsValid()
        {
            foreach (var button in Buttons)
            {
                if (string.IsNullOrEmpty(button.Label) || string.IsNullOrWhiteSpace(button.Url) || !Uri.TryCreate(button.Url, UriKind.Absolute, out _))
                    return false;
            }
            return true;
        }
    }
}
