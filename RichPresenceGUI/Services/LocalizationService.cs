using RichPresenceGUI.Services.Interfaces;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows;

namespace RichPresenceGUI.Services
{
    public class LocalizationService : ILocalizationService
    {
        private Dictionary<string, ResourceDictionary> _locales;
        ResourceDictionary? _currentLocale;

        public LocalizationService()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var manager = new ResourceManager(assembly.GetName().Name + ".g", assembly);
            var resources = manager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            if (resources == null)
                throw new NullReferenceException(nameof(resources));
            var dictionaries = resources.OfType<DictionaryEntry>();
            _locales = dictionaries.Where(kv => kv.Key.ToString().StartsWith("resources/locale/"))
                .Select(kv =>
                {
                    ResourceDictionary resourceDict = new ResourceDictionary();
                    resourceDict.Source = new Uri("/" + kv.Key.ToString().Replace("baml", "xaml"), UriKind.RelativeOrAbsolute);
                    return KeyValuePair.Create(resourceDict["locale_name"].ToString() ?? Path.GetFileNameWithoutExtension(kv.Key as string), resourceDict);
                }).ToDictionary();
        }

        public string GetCurrentLocaleName()
            => _currentLocale?["localeName"] is string localeName ? localeName : string.Empty;

        public IEnumerable<string>? GetLocaleNames()
            => _locales?.Keys;

        public string? GetValue(string key)
        {
            string? value = null;
            if (_currentLocale?.Contains(key) ?? false)
                value = _currentLocale[key].ToString() ;
            return value;
        }

        public void SetLocale(string localeName)
        {
            Application.Current.Resources.MergedDictionaries.Remove(_currentLocale);
            _currentLocale = _locales[localeName];
            Application.Current.Resources.MergedDictionaries.Add(_currentLocale);
        }
    }
}
