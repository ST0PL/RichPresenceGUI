using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace RichPresenceGUI.Views
{
    public partial class FieldsView : UserControl
    {
        public FieldsView()
        {
            InitializeComponent();
            var descriptor = DependencyPropertyDescriptor.FromProperty(ActualWidthProperty, typeof(Grid));
            descriptor.AddValueChanged(bottomGrid,
                (s,_) =>
                {
                    Grid? grid = s as Grid;
                    if(grid is not null)
                    {
                        switch (grid.ActualWidth)
                        {
                            case < 520:
                                if (grid.RowDefinitions.Count < 2)
                                {
                                    grid.ColumnDefinitions.RemoveAt(1);
                                    for (int i = 0; i < 2; i++)
                                        grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0, GridUnitType.Auto) });
                                }
                                break;
                            default:
                                if(grid.ColumnDefinitions.Count < 2)
                                {
                                    grid.RowDefinitions.Clear();
                                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0, GridUnitType.Auto) });
                                }
                                break;
                        }
                    }
                });
        }
    }
}
