using ControlsLib.Controls.Interfaces;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace ControlsLib.Controls
{
    public class ComboBox : System.Windows.Controls.ComboBox, IRounded, IResponsive, ICommandSource
    {
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ComboBox));
        
        public static readonly DependencyProperty ItemsCornerRadiusProperty =
            DependencyProperty.Register("ItemsCornerRadius", typeof(CornerRadius), typeof(ComboBox));
        public static readonly DependencyProperty ItemsForegroundProperty =
            DependencyProperty.Register("ItemsForeground", typeof(Brush), typeof(ComboBox));

        public static readonly DependencyProperty PopupBackgroundProperty =
            DependencyProperty.Register("PopupBackground", typeof(Brush), typeof(ComboBox));
        public static readonly DependencyProperty PopupCornerRadiusProperty =
            DependencyProperty.Register("PopupCornerRadius", typeof(CornerRadius), typeof(ComboBox));
        public static readonly DependencyProperty PopupWidthProperty =
            DependencyProperty.Register("PopupWidth", typeof(double), typeof(ComboBox),
                new FrameworkPropertyMetadata(double.NaN));
        public static readonly DependencyProperty PopupHeightProperty =
            DependencyProperty.Register("PopupHeight", typeof(double), typeof(ComboBox),
                new FrameworkPropertyMetadata(double.NaN));
        public static readonly DependencyProperty PopupMaxWidthProperty =
            DependencyProperty.Register("PopupMaxWidth", typeof(double), typeof(ComboBox),
                new FrameworkPropertyMetadata(double.PositiveInfinity));
        public static readonly DependencyProperty PopupMaxHeightProperty =
            DependencyProperty.Register("PopupMaxHeight", typeof(double), typeof(ComboBox),
                new FrameworkPropertyMetadata(double.PositiveInfinity));

        public static readonly DependencyProperty HoverBackgroundColorProperty =
            DependencyProperty.Register("HoverBackgroundColor", typeof(Brush), typeof(ComboBox));
        public static readonly DependencyProperty ClickBackgroundColorProperty =
            DependencyProperty.Register("ClickBackgroundColor", typeof(Brush), typeof(ComboBox));
        public static readonly DependencyProperty HoverItemBackgroundProperty =
            DependencyProperty.Register("HoverItemBackground", typeof(Brush), typeof(ComboBox));
        public static readonly DependencyProperty SelectedItemBackgroundProperty =
            DependencyProperty.Register("SelectedItemBackground", typeof(Brush), typeof(ComboBox));
        
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(ComboBox));
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(ComboBox));
        public static readonly DependencyProperty CommandTargetProperty =
            DependencyProperty.Register("CommandTarget", typeof(IInputElement), typeof(ComboBox));
        
        public static readonly DependencyProperty PopupMarginProperty =
            DependencyProperty.Register("PopupMargin", typeof(Thickness), typeof(ComboBox));
        public static readonly DependencyProperty PopupPaddingProperty =
            DependencyProperty.Register("PopupPadding", typeof(Thickness), typeof(ComboBox));

        public static readonly DependencyProperty PopupEffectProperty =
            DependencyProperty.Register("PopupEffect", typeof(Effect), typeof(ComboBox));


        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        public CornerRadius ItemsCornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        public Brush ItemsForeground
        {
            get => (Brush)GetValue(ItemsForegroundProperty);
            set => SetValue(ItemsForegroundProperty, value);
        }
        public Brush HoverBackgroundColor
        {
            get => (Brush)GetValue(HoverBackgroundColorProperty);
            set => SetValue(HoverBackgroundColorProperty, value);
        }
        public Brush ClickBackgroundColor
        {
            get => (Brush)GetValue(ClickBackgroundColorProperty);
            set => SetValue(ClickBackgroundColorProperty, value);
        }
        public CornerRadius PopupCornerRadius
        {
            get => (CornerRadius)GetValue(PopupCornerRadiusProperty);
            set => SetValue(PopupCornerRadiusProperty, value);
        }
        public Brush PopupBackground
        {
            get => (Brush)GetValue(PopupBackgroundProperty);
            set => SetValue(PopupBackgroundProperty, value);
        }
        public double PopupWidth
        {
            get => (double)GetValue(PopupWidthProperty);
            set => SetValue(PopupWidthProperty, value);
        }
        public double PopupHeight
        {
            get => (double)GetValue(PopupHeightProperty);
            set => SetValue(PopupHeightProperty, value);
        }
        public double PopupMaxWidth
        {
            get => (double)GetValue(PopupMaxWidthProperty);
            set => SetValue(PopupMaxWidthProperty, value);
        }
        public double PopupMaxHeight
        {
            get => (double)GetValue(PopupMaxHeightProperty);
            set => SetValue(PopupMaxHeightProperty, value);
        }
        public Brush HoverItemBackground
        {
            get => (Brush)GetValue(HoverItemBackgroundProperty);
            set => SetValue(HoverItemBackgroundProperty, value);
        }
        public Brush SelectedItemBackground
        {
            get => (Brush)GetValue(SelectedItemBackgroundProperty);
            set => SetValue(SelectedItemBackgroundProperty, value);
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public IInputElement CommandTarget
        {
            get => (IInputElement)GetValue(CommandTargetProperty);
            set => SetValue(CommandTargetProperty, value);
        }

        public Thickness PopupMargin
        {
            get => (Thickness)GetValue(PopupMarginProperty);
            set => SetValue(PopupMarginProperty, value);
        }

        public Thickness PopupPadding
        {
            get => (Thickness)GetValue(PopupPaddingProperty);
            set => SetValue(PopupPaddingProperty, value);
        }

        public Effect PopupEffect
        {
            get => (Effect)GetValue(PopupEffectProperty);
            set => SetValue(PopupEffectProperty, value);
        }

        static ComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ComboBox),
                new FrameworkPropertyMetadata(typeof(ComboBox)));
        }

        public ComboBox()
        {
            SelectionChanged += (s, e) =>
            {
                if (Command?.CanExecute(CommandParameter) ?? false)
                    Command.Execute(CommandParameter);
            };
        }
    }
}
