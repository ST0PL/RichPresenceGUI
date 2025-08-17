using RichPresenceGUI.Models.enums;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;


namespace RichPresenceGUI
{
    public partial class NotificationWindow : Window
    {
        public class NotificationContext(NotificationType type, string message)
        {
            public NotificationType? Type => type;
            public string? Message => message;
        }

        public NotificationWindow()
        {
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
