using RichPresenceGUI.Models;

namespace RichPresenceGUI.Services.Interfaces
{
    public interface IThemeService
    {
        public Theme CurrentTheme { get; }

        void ToggleTheme();
        void SetTheme(Theme theme);
    }
}
