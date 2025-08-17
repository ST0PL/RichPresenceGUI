using RichPresenceGUI.Events;
using RichPresenceGUI.Models;
using RichPresenceGUI.Services.Interfaces;
using System.IO;
using System.Windows.Input;

namespace RichPresenceGUI.ViewModels
{
    public class SaveTemplateVM : ObservableObject
    {

        private readonly char[] _restrictedChars = ['\\','/', ':', '*', '?', '"', '<', '>', '|'];
        private ISettingsService<Settings> _settingsService;
        private ITemplateService<Template> _templateService;
        private IEventAggregator _eventAggregator;
        private ICommand? _saveTemplateCommand;
        private string? _templateName;
        private Template _template;

        public string? TemplateName
        {
            get => _templateName;
            set
            {
                if (!value?.Any(c => _restrictedChars.Contains(c)) ?? true)
                    _templateName = value;
                OnPropertyChanged();
            }
        }
        public ICommand? SaveTemplateCommand
            => _saveTemplateCommand is null ? _saveTemplateCommand =
                new RelayCommand(_ => SaveTemplate(), _=> !string.IsNullOrWhiteSpace(TemplateName)) : _saveTemplateCommand;

        public SaveTemplateVM(ISettingsService<Settings> settingsService, IEventAggregator eventAggregator, ITemplateService<Template> templateService, Template template)
        {
            _settingsService = settingsService;
            _eventAggregator = eventAggregator;
            _templateService = templateService;
            _template = template;
        }


        public async Task SaveTemplate()
        {
            if (_settingsService.GetInstance() == null)
                await _settingsService.LoadAsync();
            string dir = _settingsService?.GetInstance()?.TemplatesPath ?? Settings.DefaultTemplatesPath;
            _template.FilePath = Path.Combine(dir, TemplateName + ".json");
            Directory.CreateDirectory(dir);
            using (FileStream fs = new FileStream(_template.FilePath, FileMode.Create, FileAccess.Write))
                await _templateService.SaveTemplateAsync(fs, _template);

            _eventAggregator.Publish(new TemplateSavedEvent(_template));
        }
    }
}
