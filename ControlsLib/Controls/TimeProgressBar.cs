using ControlsLib.Controls.Interfaces;
using ControlsLib.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ControlsLib.Controls
{
    public class TimeProgressBar: Control, IRounded
    {
        public static readonly DependencyProperty TimeContextProperty
            = DependencyProperty.Register("TimeContext", typeof(TimeBarContext), typeof(TimeProgressBar));
        public static DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(TimeProgressBar));
        public static DependencyProperty ProgressBarForegroundProperty =
            DependencyProperty.Register("ProgressBarForeground", typeof(Brush), typeof(TimeProgressBar));
        public static DependencyProperty ProgressBarBackgroundProperty =
            DependencyProperty.Register("ProgressBarBackground", typeof(Brush), typeof(TimeProgressBar));
        public static DependencyProperty ProgressBarBorderBrushProperty =
            DependencyProperty.Register("ProgressBarBorderBrush", typeof(Brush), typeof(TimeProgressBar));
        public static DependencyProperty ProgressBarCornerRadiusProperty =
            DependencyProperty.Register("ProgressBarCornerRadius", typeof(CornerRadius), typeof(TimeProgressBar));
        public static DependencyProperty ProgressBarBorderThicknessProperty =
            DependencyProperty.Register("ProgressBarBorderThickness", typeof(Thickness), typeof(TimeProgressBar));
        public static DependencyProperty ProgressBarWidthProperty =
            DependencyProperty.Register("ProgressBarWidth", typeof(double), typeof(TimeProgressBar),
                new PropertyMetadata(double.NaN));
        public static DependencyProperty ProgressBarHeightProperty =
            DependencyProperty.Register("ProgressBarHeight", typeof(double), typeof(TimeProgressBar),
                new PropertyMetadata(double.NaN));

        public TimeBarContext? TimeContext
        {
            get => (TimeBarContext?)GetValue(TimeContextProperty);
            set => SetValue(TimeContextProperty, value);
        }
        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        public Brush ProgressBarBackground
        {
            get => (Brush)GetValue(ProgressBarBackgroundProperty);
            set => SetValue(ProgressBarBackgroundProperty, value);
        }
        public Brush ProgressBarBorderBrush
        {
            get => (Brush)GetValue(ProgressBarBorderBrushProperty);
            set => SetValue(ProgressBarBorderBrushProperty, value);
        }
        public Brush ProgressBarForeground
        {
            get => (Brush)GetValue(ProgressBarForegroundProperty);
            set => SetValue(ProgressBarForegroundProperty, value);
        }
        public CornerRadius ProgressBarCornerRadius
        {
            get => (CornerRadius)GetValue(ProgressBarCornerRadiusProperty);
            set => SetValue(ProgressBarCornerRadiusProperty, value);
        }
        public Thickness ProgressBarBorderThickness
        {
            get => (Thickness)GetValue(ProgressBarBorderThicknessProperty);
            set => SetValue(ProgressBarBorderThicknessProperty, value);
        }
        public double ProgressBarWidth
        {
            get => (double)GetValue(ProgressBarWidthProperty);
            set => SetValue(ProgressBarWidthProperty, value);
        }
        public double ProgressBarHeight
        {
            get => (double)GetValue(ProgressBarHeightProperty);
            set => SetValue(ProgressBarHeightProperty, value);
        }
        static TimeProgressBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(TimeProgressBar),
                new FrameworkPropertyMetadata(typeof(TimeProgressBar)));
        }
    }
}
