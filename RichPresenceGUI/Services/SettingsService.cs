using RichPresenceGUI.Models;
using RichPresenceGUI.Services.Interfaces;
using System.IO;
using System.Text.Json;

namespace RichPresenceGUI.Services
{
    class SettingsService : ISettingsService<Settings>
    {
        private Settings? _currentSettings;

        public string Path { get; set; }

        public SettingsService(string path)
            => Path = path;

        public async Task WriteAsync()
        {
            if (_currentSettings == null)
                throw new NullReferenceException();

            using FileStream fs = new FileStream(Path, FileMode.Create);
            await JsonSerializer.SerializeAsync(fs, _currentSettings);
        }
        public async Task LoadAsync()
        {
            if (string.IsNullOrWhiteSpace(Path))
                throw new ArgumentNullException();
            using FileStream fs = new FileStream(Path, FileMode.OpenOrCreate);
            Settings? deserialized = null;
            try
            {
                deserialized = await JsonSerializer.DeserializeAsync<Settings>(fs);
            }
            catch (JsonException) { }
            _currentSettings = deserialized ?? Settings.CreateDefault();
        }
        public Settings? GetInstance()
            => _currentSettings;
    }
}
