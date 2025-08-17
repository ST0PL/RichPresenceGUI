using DiscordRPC;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Button = DiscordRPC.Button;

namespace RichPresenceGUI.CustomControls
{
    class VisualTemplate : Control
    {
        public static DependencyProperty ActivityTypeProperty =
            DependencyProperty.Register("ActivityType", typeof(ActivityType), typeof(VisualTemplate));
        public static DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(string), typeof(VisualTemplate));
        public static DependencyProperty DetailsProperty =
            DependencyProperty.Register("Details", typeof(string), typeof(VisualTemplate));
        public static DependencyProperty ButtonsSourceProperty =
            DependencyProperty.Register("ButtonsSource", typeof(IEnumerable<Button>), typeof(VisualTemplate));
        public static DependencyProperty StartTimestampProperty =
            DependencyProperty.Register("StartTimestamp", typeof(ulong?), typeof(VisualTemplate));
        public static DependencyProperty EndTimestampProperty =
            DependencyProperty.Register("EndTimestamp", typeof(ulong?), typeof(VisualTemplate));
        public static DependencyProperty LargeImageKeyProperty =
            DependencyProperty.Register("LargeImageKey", typeof(string), typeof(VisualTemplate));
        public static DependencyProperty LargeImageTextProperty =
            DependencyProperty.Register("LargeImageText", typeof(string), typeof(VisualTemplate));
        public static DependencyProperty SmallImageKeyProperty =
            DependencyProperty.Register("SmallImageKey", typeof(string), typeof(VisualTemplate));
        public static DependencyProperty SmallImageTextProperty =
            DependencyProperty.Register("SmallImageText", typeof(string), typeof(VisualTemplate));
        public static DependencyProperty PartyProperty =
            DependencyProperty.Register("Party", typeof(Party), typeof(VisualTemplate));
        public static DependencyProperty SelectCommandProperty =
            DependencyProperty.Register("SelectCommand", typeof(ICommand), typeof(VisualTemplate));
        public static DependencyProperty RemoveCommandProperty =
            DependencyProperty.Register("RemoveCommand", typeof(ICommand), typeof(VisualTemplate));

        public ActivityType ActivityType
        {
            get => (ActivityType)GetValue(ActivityTypeProperty);
            set => SetValue(ActivityTypeProperty, value);
        }
        public string State
        {
            get => (string)GetValue(StateProperty);
            set => SetValue(StateProperty, value);
        }
        public string Details
        {
            get => (string)GetValue(DetailsProperty);
            set => SetValue(DetailsProperty, value);
        }
        public IEnumerable<Button> ButtonsSource
        {
            get => (IEnumerable<Button>)GetValue(ButtonsSourceProperty);
            set => SetValue(ButtonsSourceProperty, value);
        }
        public ulong? StartTimestamp
        {
            get => (ulong?)GetValue(StartTimestampProperty);
            set => SetValue(StartTimestampProperty, value);
        }
        public ulong? EndTimestamp
        {
            get => (ulong?)GetValue(EndTimestampProperty);
            set => SetValue(EndTimestampProperty, value);
        }
        public ICommand SelectCommand
        {
            get => (ICommand)GetValue(SelectCommandProperty);
            set => SetValue(SelectCommandProperty, value);
        }
        public ICommand RemoveCommand
        {
            get => (ICommand)GetValue(RemoveCommandProperty);
            set => SetValue(RemoveCommandProperty, value);
        }
        public string LargeImageKey
        {
            get => (string)GetValue(LargeImageKeyProperty);
            set => SetValue(LargeImageKeyProperty, value);
        }
        public string LargeImageText
        {
            get => (string)GetValue(LargeImageTextProperty);
            set => SetValue(LargeImageTextProperty, value);
        }
        public string SmallImageKey
        {
            get => (string)GetValue(SmallImageKeyProperty);
            set => SetValue(SmallImageKeyProperty, value);
        }
        public string SmallImageText
        {
            get => (string)GetValue(SmallImageTextProperty);
            set => SetValue(SmallImageTextProperty, value);
        }
        public Party Party
        {
            get => (Party)GetValue(PartyProperty);
            set => SetValue(PartyProperty, value);
        }
    }
}
