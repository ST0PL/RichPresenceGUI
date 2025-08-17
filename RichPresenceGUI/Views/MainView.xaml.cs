using RichPresenceGUI.ViewModels;
using System.Windows.Controls;

namespace RichPresenceGUI.Views
{
    public partial class MainView : UserControl
    {
        public MainView(MainVM viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
