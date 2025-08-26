using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace ControlsLib.Controls
{
    public class NavigationRadioButton : ImageRadioButton
    {
        public static readonly DependencyProperty FlagXProperty =
            DependencyProperty.Register("FlagX", typeof(double), typeof(NavigationRadioButton));
        public static readonly DependencyProperty FlagYProperty =
            DependencyProperty.Register("FlagY", typeof(double), typeof(NavigationRadioButton));
        public static readonly DependencyProperty FlagEndXProperty =
            DependencyProperty.Register("FlagEndX", typeof(double), typeof(NavigationRadioButton));
        public static readonly DependencyProperty FlagEndYProperty =
            DependencyProperty.Register("FlagEndY", typeof(double), typeof(NavigationRadioButton));
        public static readonly DependencyProperty FlagAnimationDurationProperty =
            DependencyProperty.Register("FlagAnimationDuration", typeof(Duration), typeof(NavigationRadioButton));
        public static readonly DependencyProperty FlagCornerRadiusProperty =
            DependencyProperty.Register("FlagCornerRadius", typeof(CornerRadius), typeof(NavigationRadioButton));
        public static readonly DependencyProperty FlagBackgroundProperty =
            DependencyProperty.Register("FlagBackground", typeof(Brush), typeof(NavigationRadioButton));
        public static readonly DependencyProperty FlagPaddingProperty =
            DependencyProperty.Register("FlagPadding", typeof(Thickness), typeof(NavigationRadioButton));
        public static readonly DependencyProperty FlagMarginProperty =
            DependencyProperty.Register("FlagMargin", typeof(Thickness), typeof(NavigationRadioButton));
        public static readonly DependencyProperty FlagPositionProperty =
            DependencyProperty.Register("FlagPosition", typeof(FlagPosition), typeof(NavigationRadioButton));

        public double FlagX
        {
            get => (double)GetValue(FlagXProperty);
            set => SetValue(FlagXProperty, value);
        }
        public double FlagY
        {
            get => (double)GetValue(FlagYProperty);
            set => SetValue(FlagYProperty, value);
        }
        public double FlagEndX
        {
            get => (double)GetValue(FlagEndXProperty);
            set => SetValue(FlagEndXProperty, value);
        }
        public double FlagEndY
        {
            get => (double)GetValue(FlagEndYProperty);
            set => SetValue(FlagEndYProperty, value);
        }
        public Duration FlagAnimationDuration
        {
            get => (Duration)GetValue(FlagAnimationDurationProperty);
            set => SetValue(FlagAnimationDurationProperty, value);
        }
        public CornerRadius FlagCornerRadius
        {
            get => (CornerRadius)GetValue(FlagCornerRadiusProperty);
            set => SetValue(FlagCornerRadiusProperty, value);
        }
        public Brush FlagBackground
        {
            get => (Brush)GetValue(FlagBackgroundProperty);
            set => SetValue(FlagBackgroundProperty, value);
        }
        public Thickness FlagPadding
        {
            get => (Thickness)GetValue(FlagPaddingProperty);
            set => SetValue(FlagPaddingProperty, value);
        }
        public Thickness FlagMargin
        {
            get => (Thickness)GetValue(FlagMarginProperty);
            set => SetValue(FlagCornerRadiusProperty, value);
        }
        public FlagPosition FlagPosition
        {
            get => (FlagPosition)GetValue(FlagPositionProperty);
            set => SetValue(FlagPositionProperty, value);
        }
        static NavigationRadioButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(NavigationRadioButton),
                new FrameworkPropertyMetadata(typeof(NavigationRadioButton)));
        }
        public NavigationRadioButton()
        {
            DependencyPropertyDescriptor.FromProperty(IsCheckedProperty,
                typeof(NavigationRadioButton)).AddValueChanged(this, CheckedChanged);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            CheckedChanged(this, EventArgs.Empty);
        }

        private static void CheckedChanged(object? sender, EventArgs args)
        {
            var d = (DependencyObject)sender;
            var IsChecked = (bool)d.GetValue(IsCheckedProperty);
            double flagX = (double)d.GetValue(FlagXProperty);
            double flagEndX = (double)d.GetValue(FlagEndXProperty);
            double flagY = (double)d.GetValue(FlagYProperty);
            double flagEndY = (double)d.GetValue(FlagEndYProperty);
            Duration duration = (Duration)d.GetValue(FlagAnimationDurationProperty);
            var flagBorder = TreeTools.GetVisualChild(d, "flag");
            if (flagBorder?.RenderTransform is TranslateTransform transform)
            {
                (DoubleAnimation, DoubleAnimation) animations
                    = IsChecked ? GetFlagAnimations(flagX, flagEndX, flagY, flagEndY, duration)
                                  : GetFlagAnimations(flagEndX, flagX, flagEndY, flagY, duration);

                transform.BeginAnimation(TranslateTransform.XProperty, animations.Item1);
                transform.BeginAnimation(TranslateTransform.YProperty, animations.Item2);
            }
        }
        private static (DoubleAnimation, DoubleAnimation) GetFlagAnimations(
            double xFrom,
            double xTo,
            double yFrom,
            double yTo,
            Duration duration)
        {
            var xAnimation = new DoubleAnimation()
            {
                From = xFrom,
                To = xTo,
                Duration = duration
            };
            var yAnimation = new DoubleAnimation()
            {
                From = yFrom,
                To = yTo,
                Duration = duration
            };
            return (xAnimation, yAnimation);
        }
        private static void FlagChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                var button = (NavigationRadioButton)d;
                var storyboards = GetBeginStoryboards(button);
                var InBeginStoryboard = storyboards["flagInAnimation"];
                var OutBeginStoryboard = storyboards["flagOutAnimation"];
                double flagX = (double)d.GetValue(FlagXProperty);
                double flagEndX = (double)d.GetValue(FlagEndXProperty);
                double flagY = (double)d.GetValue(FlagYProperty);
                double flagEndY = (double)d.GetValue(FlagEndYProperty);
                Duration duration = (Duration)d.GetValue(FlagAnimationDurationProperty);

                ChangeAnimation(InBeginStoryboard, flagX, flagEndX, flagY, flagEndY, duration);
                ChangeAnimation(OutBeginStoryboard, flagEndX, flagX, flagEndY, flagY, duration);
            }
            catch (Exception ex) { }
        }

        private static void ChangeAnimation(
            BeginStoryboard beginStoryboard,
            double xFrom,
            double xTo,
            double yFrom,
            double yTo,
            Duration duration)
        {
            var xAnimation = new DoubleAnimation()
            {
                From = xFrom,
                To = xTo,
            };
            var yAnimation = new DoubleAnimation()
            {
                From = yFrom,
                To = yTo,
                Duration = duration
            };
            var storyboard = new Storyboard();
            Storyboard.SetTargetName(xAnimation, "flag");
            Storyboard.SetTargetName(yAnimation, "flag");
            Storyboard.SetTargetProperty(yAnimation, new PropertyPath("(RenderTransform).(TranslateTransform.X)"));
            Storyboard.SetTargetProperty(yAnimation, new PropertyPath("(RenderTransform).(TranslateTransform.Y)"));
            storyboard.Children.Add(xAnimation);
            storyboard.Children.Add(yAnimation);
            beginStoryboard.Storyboard = storyboard;
        }
        private static Dictionary<string, BeginStoryboard> GetBeginStoryboards(NavigationRadioButton btn)
            => btn.Template.Triggers.SelectMany(t => t.EnterActions.Where(a => a is BeginStoryboard bs)
                .Select(a => { var sb = a as BeginStoryboard; return KeyValuePair.Create(sb.Name, sb); })).ToDictionary();

    }
}
