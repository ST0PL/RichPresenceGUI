namespace RichPresenceGUI.Models
{
    public class Settings
    {
        public const string DefaultTemplatesPath = "Templates";
        public string TemplatesPath { get; set; }
        public Theme Theme { get; set; }
        public string Locale { get; set; }
        public bool ShowTrayBalloon { get; set; }

        public Settings(string templatesPath, Theme theme, string locale, bool showTrayBalloon)
        {
            TemplatesPath = templatesPath;
            Theme = theme;
            Locale = locale;
            ShowTrayBalloon = showTrayBalloon;
        }
        public static Settings CreateDefault()
            => new Settings(DefaultTemplatesPath, Theme.Dark, "English", true);
    }
}
