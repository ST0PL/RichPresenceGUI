using System.Windows;
using System.Windows.Controls;

namespace RichPresenceGUI.Views
{
    public partial class TemplatesView : UserControl
    {
        public TemplatesView()
        {
            InitializeComponent();
            Task.Run(() =>
            {
                while (true)
                {
                    App.Current?.Dispatcher?.Invoke(() =>
                    {
                        listBox.Items.Refresh();
                    });
                    Thread.Sleep(1000);
                }
            });
        }

    }
}
