using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ControlsLib.AttachedProperties
{
    public class ListBoxBehaviour
    {
        public static readonly DependencyProperty AllowCopyProperty
            = DependencyProperty.RegisterAttached("AllowCopy", typeof(bool), typeof(ListBoxBehaviour), new UIPropertyMetadata(OnAllowCopyChanged));

        public static bool GetAllowCopy(DependencyObject obj)
            => (bool)obj.GetValue(AllowCopyProperty);
        public static void SetAllowCopy(DependencyObject obj, bool value)
            => obj.SetValue(AllowCopyProperty, value);

        private static void OnAllowCopyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is ListBox listBox)
            {
                if ((bool)e.NewValue)
                {
                    ExecutedRoutedEventHandler handler = (_, _) => Clipboard.SetDataObject(listBox.SelectedItem.ToString());
                    var command = new RoutedCommand();
                    command.InputGestures.Add(new KeyGesture(Key.C, ModifierKeys.Control));
                    listBox.CommandBindings.Add(new CommandBinding(command, handler));
                }
                else
                    listBox.CommandBindings.Clear();
            }
        }
    }
}
