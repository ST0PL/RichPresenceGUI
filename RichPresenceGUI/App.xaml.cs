using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RichPresenceGUI.Models;
using RichPresenceGUI.Services;
using RichPresenceGUI.Services.Interfaces;
using RichPresenceGUI.ViewModels;
using RichPresenceGUI.Views;
namespace RichPresenceGUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost? _host;

        private IHost GetHost()
            => Host.CreateDefaultBuilder()
                .ConfigureServices(s =>
                {
                    s.AddSingleton<MainWindow>();
                    s.AddSingleton<MainView>();
                    s.AddSingleton<MainVM>();
                    s.AddSingleton<ISettingsService<Settings>, SettingsService>(_ => new SettingsService("settings.json"));
                    s.AddSingleton<ITemplateService<Template>, TemplateService>();
                    s.AddSingleton<IEventAggregator, EventAggregator>();
                    s.AddSingleton<IThemeService, ThemeService>();
                    s.AddSingleton<IWindowService, WindowService>();
                    s.AddSingleton<ILocalizationService, LocalizationService>();
                    s.AddSingleton<IUpdaterService, UpdaterService>(_=>new UpdaterService("ST0PL", "RichPresenceGUI"));
                })
                .Build();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Current.DispatcherUnhandledException += (s, e)
                => { e.Handled = true; new UnhandledExceptionWindow(e.Exception).Show(); };
            _host = GetHost();
            MainWindow = _host?.Services?.GetService<MainWindow>();
            MainWindow?.Show();
        }
    }

}
