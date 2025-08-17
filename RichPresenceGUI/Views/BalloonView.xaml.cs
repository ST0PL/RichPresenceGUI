using RichPresenceGUI.Models;
using RichPresenceGUI.Services.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace RichPresenceGUI.Views
{
    public partial class BalloonView : UserControl
    {
        public string? Text { get; }
        public event RoutedEventHandler? Click;
        private readonly ISettingsService<Settings> _settingsService;

        public BalloonView(ISettingsService<Settings> settingsService, string? text)
        {
            _settingsService = settingsService;
            InitializeComponent();
            SetText(text);
        }
        public void SetText(string? text)
            => textBlock.Text = text;

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
            => Click?.Invoke(sender,e);

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if(_settingsService.GetInstance() is { } settings)
            {
                settings.ShowTrayBalloon = false;
                await _settingsService.WriteAsync();
                Click?.Invoke(sender, e);
            }
        }
    }
}
