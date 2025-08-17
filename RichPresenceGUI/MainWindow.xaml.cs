using DiscordRPC;
using RichPresenceGUI.Events;
using RichPresenceGUI.Models;
using RichPresenceGUI.Services.Interfaces;
using RichPresenceGUI.Views;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace RichPresenceGUI
{
    public partial class MainWindow : Window
    {
        private bool _loaded;
        private readonly BalloonView? _balloon;
        private readonly ISettingsService<Settings>? _settingsService;
        public MainWindow(MainView view,
            ISettingsService<Settings> settingsService,
            IUpdaterService updaterService,
            ILocalizationService localizationService,
            IEventAggregator eventAggregator)
        {
            _settingsService = settingsService;
            _balloon = new BalloonView(settingsService, localizationService.GetValue("balloon_minimized"));
            _balloon.Click += (_, _) => { notifyIcon.CloseBalloon(); };
            IsVisibleChanged += (s, e) =>
            {
                _loaded = (bool)e.NewValue;
                topButton.Content = _loaded ? localizationService.GetValue("tb_hide") : localizationService.GetValue("tb_show");
            };
            Closed += (_, _) => notifyIcon.Visibility = Visibility.Collapsed;
            Unloaded += (_, _) => RunOutAnimation();
            eventAggregator.Subscribe<LocaleChangedEvent>(_ =>
            {
                _balloon.SetText(localizationService.GetValue("balloon_minimized"));
                topButton.Content = _loaded ? localizationService.GetValue("tb_hide") : localizationService.GetValue("tb_show");
            });
            eventAggregator.Subscribe<CurrentUserUpdatedEvent>(UpdateUserData);
            InitializeComponent();
            CheckUpdates(updaterService);
            contentControl.Content = view;
        }

        private void UpdateUserData(CurrentUserUpdatedEvent currentUserUpdatedEvent)
        {
            if (currentUserUpdatedEvent.Args is { DisplayName: { Length: > 0 } })
                App.Current.Dispatcher.Invoke(() =>
                {
                    User user = currentUserUpdatedEvent.Args;
                    string avatarPath = user.Avatar == null ?
                        "pack://application:,,,/Resources/Icons/default_avatar.png" :
                        $"https://{user.CdnEndpoint}/avatars/{user.ID}/{user.Avatar}.png";

                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(avatarPath, UriKind.Absolute);
                    bitmap.EndInit();
                    ((ImageBrush)avatar.Background).ImageSource = bitmap;
                    displayName.Content = user.DisplayName;
                });
            else
            {
                ((ImageBrush)avatar.Background).ImageSource = null;
                displayName.Content = string.Empty;
            }

        }
        private async void CheckUpdates(IUpdaterService updaterService)
        {
            var prodVersion = updaterService.GetProductVersion();
            var lastUpdate = await updaterService.GetLastUpdateAsync();
            if (lastUpdate is null || DateTime.UtcNow - lastUpdate.LastCheck > TimeSpan.FromHours(1))
            {
                GithubRelease latest = await updaterService.GetLatestAsync();
                await updaterService.WriteLastUpdateAsync(latest);
                lastUpdate = await updaterService.GetLastUpdateAsync();
            }
            if (!lastUpdate?.Release?.TagName?.Equals(prodVersion) ?? false)
                ShowUpdateButton(lastUpdate!.Release);


        }
        private void ShowUpdateButton(GithubRelease release)
        {
            updateInteraction.Path = release.DownloadUrl;
            updateButton.Visibility = Visibility.Visible;
        }

        #region window appearance

        private void RunInAnimation(Action? startAction = null)
        {
            startAction?.Invoke();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            doubleAnimation.Duration = TimeSpan.FromSeconds(0.15);
            mainBorder.BeginAnimation(OpacityProperty, doubleAnimation);
        }
        private void RunOutAnimation(Action? endAction = null)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 1;
            doubleAnimation.To = 0;
            doubleAnimation.Duration = TimeSpan.FromSeconds(0.15);
            doubleAnimation.Completed += (s, e) => endAction?.Invoke();
            mainBorder.BeginAnimation(OpacityProperty, doubleAnimation);
        }


        private void ShowBalloon()
        {
            if (_settingsService?.GetInstance()?.ShowTrayBalloon ?? true)
                notifyIcon.ShowCustomBalloon(_balloon, System.Windows.Controls.Primitives.PopupAnimation.Fade, null);
        }

        private void ShowWindow()
        {
            Show();
            WindowState = WindowState.Maximized;
            Topmost = true;
            Topmost = false;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            ShowBalloon();
            RunOutAnimation(Hide);
        }
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
            => WindowState = WindowState.Minimized;

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
        private void TrayDoubleClick(object sender, RoutedEventArgs e)
        {
            if (!_loaded)
                RunInAnimation(ShowWindow);
        }

        private void TrayTopButton_Clicked(object sender, RoutedEventArgs e)
        {
            notifyIcon.CloseTrayPopup();
            if (_loaded)
                RunOutAnimation(Hide);
            else
                RunInAnimation(ShowWindow);

        }
        private void TrayCloseButton_Clicked(object sender, RoutedEventArgs e)
            => App.Current.Shutdown();

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else if (WindowState == WindowState.Normal)
                RunInAnimation();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            ShowBalloon();
            RunOutAnimation(Hide);
        }

        #endregion
    }
}