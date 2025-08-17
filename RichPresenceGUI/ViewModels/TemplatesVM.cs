using Microsoft.Win32;
using RichPresenceGUI.Events;
using RichPresenceGUI.Models;
using RichPresenceGUI.Models.enums;
using RichPresenceGUI.Services.Interfaces;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

namespace RichPresenceGUI.ViewModels
{
    internal class TemplatesVM : ObservableObject
    {
        private IWindowService _windowService;
        private ILocalizationService _localizationService;
        private ISettingsService<Settings> _settingsService;
        private IEventAggregator _eventAggregator;
        private ITemplateService<Template> _templateService;
        private ICommand _selectPathCommand;
        private ICommand _refreshCommand;
        private ICommand _selectTemplateCommand;
        private ICommand _removeTemplateCommand;
        
        public ObservableCollection<Template> Templates { get; set; }

        public bool HasItems => Templates.Count > 0;

        public ICommand SelectPathCommand
            => _selectPathCommand ??= _selectPathCommand = new RelayCommand(async (arg) => await SelectFolderAsync());
        
        public ICommand RefreshCommand
            => _refreshCommand ??= new RelayCommand(async (arg) => await UpdateTemplatesAsync());

        public ICommand SelectTemplateCommand
            => _selectTemplateCommand ??= new RelayCommand((arg) => SelectTemplate(arg as Template));
        
        public ICommand RemoveTemplateCommand
            => _removeTemplateCommand ??= _removeTemplateCommand = new RelayCommand((arg) => RemoveTemplate((Template)arg));
        
        public TemplatesVM(IWindowService windowService, ILocalizationService localizationService, ISettingsService<Settings> settingsService,  IEventAggregator eventAggregator, ITemplateService<Template> templateService)
        {
            _windowService = windowService;
            _localizationService = localizationService;
            _settingsService = settingsService;
            _eventAggregator = eventAggregator;
            _templateService = templateService;
            Templates = new();
            Templates.CollectionChanged += (_, _) => OnPropertyChanged(nameof(HasItems));
            _eventAggregator.Subscribe<TemplateSavedEvent>(async (obj) => await OnTemplateSaved(obj));
            UpdateTemplatesAsync();
        }
        async Task SelectFolderAsync()
        {
            OpenFolderDialog openFolderDialog = new OpenFolderDialog();
            if (openFolderDialog.ShowDialog() ?? false)
            {
                _settingsService!.GetInstance()!.TemplatesPath = openFolderDialog.FolderName;
                await _settingsService.WriteAsync();
                await UpdateTemplatesAsync();
                _windowService.Show<NotificationWindow>(new NotificationWindow.NotificationContext(NotificationType.Information, string.Format(_localizationService.GetValue("nw_template_folderChanged"), openFolderDialog.FolderName)));
            }
        }
        void RemoveTemplate(Template template)
        {
            if(template is { FilePath: { } })
            {
                Templates.Remove(template);
                _templateService.DeleteTemplate(template.FilePath);
            }
        }
        void SelectTemplate(Template template)
        {
            _eventAggregator.Publish(new TemplateSelectedEvent(template));
            _windowService.Show<NotificationWindow>(new NotificationWindow.NotificationContext(NotificationType.Information, string.Format(_localizationService.GetValue("nw_template_selected"), template.FileNameWithoutExtension)));
        }

        async Task OnTemplateSaved(TemplateSavedEvent @event)
        {
            await UpdateTemplatesAsync();
            _windowService.Show<NotificationWindow>(new NotificationWindow.NotificationContext(NotificationType.Information, string.Format(_localizationService.GetValue("nw_template_saved"), @event.Args.FileNameWithoutExtension)));

        }
        async Task UpdateTemplatesAsync()
        {
            string path = _settingsService?.GetInstance()?.TemplatesPath ?? Directory.GetCurrentDirectory();
            var newTemplates = _templateService.LoadTemplatesAsync(path);
            bool isInit = Templates.Count == 0;
            Dictionary<Template, int> frequency = isInit ? new() : Templates.Select(t=>KeyValuePair.Create(t,0)).ToDictionary();
            await foreach (var newTemplate in newTemplates)
            {
                bool found = false; 
                for (int i = 0; i < Templates.Count && !found; i++)
                {

                    if (newTemplate.FilePath == Templates[i].FilePath)
                    {
                        found = true;
                        frequency[Templates[i]]++;
                        Templates[i] = newTemplate;
                    }
                }
                if (!found)
                    Templates.Add(newTemplate);
            }
            if (!isInit)
                foreach (var key in frequency.Where(kv => kv.Value == 0).Select(kv => kv.Key))
                    Templates.Remove(key);
        }
    }
}
