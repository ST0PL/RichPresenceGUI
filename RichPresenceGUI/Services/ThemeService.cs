using RichPresenceGUI.Models;
using RichPresenceGUI.Services.Interfaces;
using System.Windows;

namespace RichPresenceGUI.Services
{
    class ThemeService : IThemeService
    {

        private Dictionary<Theme, ResourceDictionary> _themes;
        public Theme CurrentTheme { get; private set; }

        public ThemeService()
        {
            _themes = new()
            {
                [Theme.Light] = new ResourceDictionary() { Source = new Uri("/Resources/Themes/Light.xaml", UriKind.Relative) },
                [Theme.Dark] = new ResourceDictionary() { Source = new Uri("/Resources/Themes/Dark.xaml", UriKind.Relative) }
            };
        }

        public void ToggleTheme()
            => SetTheme(CurrentTheme == Theme.Dark ? Theme.Light : Theme.Dark);
        public void SetTheme(Theme theme)
        {
            Application.Current.Resources.MergedDictionaries.Remove(_themes[CurrentTheme]);
            CurrentTheme = theme;
            Application.Current.Resources.MergedDictionaries.Add(_themes[theme]);
        }
    }
}
