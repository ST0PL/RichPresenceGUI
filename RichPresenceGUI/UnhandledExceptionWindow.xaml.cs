using System.Media;
using System.Windows;

namespace RichPresenceGUI
{
    public partial class UnhandledExceptionWindow : Window
    {
        public object Exception { get; set; }
        public UnhandledExceptionWindow(object exception)
        {
            SystemSounds.Hand.Play();
            DataContext = this;
            Exception = exception;
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
            => Close();

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
                DragMove();
        }
    }
}
