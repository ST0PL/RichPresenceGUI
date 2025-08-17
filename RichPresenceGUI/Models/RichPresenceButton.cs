using DiscordRPC;
using RichPresenceGUI.ViewModels;

namespace RichPresenceGUI.Models
{
    internal class RichPresenceButton : ObservableObject
    {
        private string? _label;
        private string? _url;

        public string? Label
        {
            get => _label;
            set
            {
                _label = value;
                OnPropertyChanged();
            }
        }
        public string? Url
        {
            get => _url;
            set
            {
                _url = value;
                OnPropertyChanged();
            }
        }
        public static explicit operator Button(RichPresenceButton button)
            => new Button() { Label = button.Label, Url = button.Url };
    }
}
