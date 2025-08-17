namespace RichPresenceGUI.Services.Interfaces
{
    public interface ILocalizationService
    {
        public string? GetValue(string key);
        public void SetLocale(string localeName);
        public IEnumerable<string>? GetLocaleNames();
        public string GetCurrentLocaleName();
    }
}
