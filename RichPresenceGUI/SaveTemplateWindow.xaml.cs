using RichPresenceGUI.Models;
using RichPresenceGUI.Services.Interfaces;
using RichPresenceGUI.ViewModels;
using System.Windows;
using System.Windows.Media.Animation;

namespace RichPresenceGUI
{
    public partial class SaveTemplateWindow : Window
    {
        public SaveTemplateWindow(ISettingsService<Settings> settingsService, IEventAggregator eventAggregator, ITemplateService<Template> templateService, Template template)
        {
            DataContext = new SaveTemplateVM(settingsService, eventAggregator, templateService, template);
            Loaded += (s, e) => RunInAnimation();
            InitializeComponent();
        }

        void RunInAnimation()
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            doubleAnimation.Duration = TimeSpan.FromSeconds(0.15);
            mainBorder.BeginAnimation(OpacityProperty, doubleAnimation);
        }

        void RunOutAnimation()
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 1;
            doubleAnimation.To = 0;
            doubleAnimation.Duration = TimeSpan.FromSeconds(0.15);
            doubleAnimation.Completed += (s, e) => Close();
            mainBorder.BeginAnimation(OpacityProperty, doubleAnimation);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
            => RunOutAnimation();

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
                DragMove();
        }
    }
}
