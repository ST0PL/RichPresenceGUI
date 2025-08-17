using RichPresenceGUI.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RichPresenceGUI.Views
{
    public partial class DebugView : UserControl
    {
        public DebugView()
        {
            Loaded += OnInitialize;
            InitializeComponent();
        }

        private void OnInitialize(object sender, EventArgs e)
        {
            Loaded -= OnInitialize;
            var logsViewer = FindVisualChild<ScrollViewer>(logsList);
            var itemsSource = logsList.ItemsSource as ObservableCollection<Logger.Log>;
            if (logsViewer is { } && itemsSource is { })
                itemsSource.CollectionChanged += (_, e) =>
                {
                    if (logsViewer.ScrollableHeight <= logsViewer.VerticalOffset)
                        logsViewer.ScrollToEnd();
                };

        }

        private void Scrollviewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var sv = (ScrollViewer)sender;

            if (sv.ScrollableHeight <= sv.VerticalOffset)
                sv.ScrollToEnd();

        }

        private T? FindVisualChild<T>(DependencyObject control) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(control); i++)
            {
                var child = VisualTreeHelper.GetChild(control, i);
                if (child is T t)
                    return t;

                var childOfChild = FindVisualChild<T>(child);
                if (childOfChild != null)
                    return childOfChild;
            }
            return null;
        }
    }
}
