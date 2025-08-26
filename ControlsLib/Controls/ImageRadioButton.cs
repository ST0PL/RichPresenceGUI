using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ControlsLib.Controls.Interfaces;

namespace ControlsLib.Controls
{
    public class ImageRadioButton : RadioButton, IImageControl
    {
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ImageRadioButton));
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(ImageRadioButton));
        public static readonly DependencyProperty CheckedImageSourceProperty =
            DependencyProperty.Register("CheckedImageSource", typeof(ImageSource), typeof(ImageRadioButton));
        public static readonly DependencyProperty HoverBackgroundColorProperty =
            DependencyProperty.Register("HoverBackgroundColor", typeof(Brush), typeof(ImageRadioButton));
        public static readonly DependencyProperty ClickBackgroundColorProperty =
            DependencyProperty.Register("ClickBackgroundColor", typeof(Brush), typeof(ImageRadioButton));
        public static readonly DependencyProperty CheckedBackgroundColorProperty =
            DependencyProperty.Register("CheckedBackgroundColor", typeof(Brush), typeof(ImageRadioButton));
        public static readonly DependencyProperty CheckedForegroundColorProperty =
            DependencyProperty.Register("CheckedForegroundColor", typeof(Brush), typeof(ImageRadioButton));
        public static readonly DependencyProperty CheckedBorderBrushProperty =
            DependencyProperty.Register("CheckedBorderBrush", typeof(Brush), typeof(ImageRadioButton));
        public static readonly DependencyProperty ImageWidthProperty =
            DependencyProperty.Register("ImageWidth", typeof(double), typeof(ImageRadioButton),
                new UIPropertyMetadata(double.NaN));
        public static readonly DependencyProperty ImageHeightProperty =
            DependencyProperty.Register("ImageHeight", typeof(double), typeof(ImageRadioButton),
                new UIPropertyMetadata(double.NaN));
        public static readonly DependencyProperty ImageMarginProperty =
            DependencyProperty.Register("ImageMargin", typeof(Thickness), typeof(ImageRadioButton));
        public static readonly DependencyProperty ContentMarginProperty =
            DependencyProperty.Register("ContentMargin", typeof(Thickness), typeof(ImageRadioButton));

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        public ImageSource ImageSource
        {
            get => (ImageSource)GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }
        public ImageSource CheckedImageSource
        {
            get => (ImageSource)GetValue(CheckedImageSourceProperty);
            set => SetValue(CheckedImageSourceProperty, value);
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
        public Brush CheckedBackgroundColor
        {
            get => (Brush)GetValue(CheckedBackgroundColorProperty);
            set => SetValue(CheckedBackgroundColorProperty, value);
        }
        public Brush CheckedForegroundColor
        {
            get => (Brush)GetValue(CheckedForegroundColorProperty);
            set => SetValue(CheckedForegroundColorProperty, value);
        }
        public Brush CheckedBorderBrush
        {
            get => (Brush)GetValue(CheckedBorderBrushProperty);
            set => SetValue(CheckedBorderBrushProperty, value);
        }
        public double ImageWidth
        {
            get => (double)GetValue(ImageWidthProperty);
            set => SetValue(ImageWidthProperty, value);
        }
        public double ImageHeight
        {
            get => (double)GetValue(ImageHeightProperty);
            set => SetValue(ImageHeightProperty, value);
        }
        public Thickness ImageMargin
        {
            get => (Thickness)GetValue(ImageMarginProperty);
            set => SetValue(ImageMarginProperty, value);
        }
        public Thickness ContentMargin
        {
            get => (Thickness)GetValue(ContentMarginProperty);
            set => SetValue(ContentMarginProperty, value);
        }

        static ImageRadioButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(ImageRadioButton),
                new FrameworkPropertyMetadata(typeof(ImageRadioButton)));
        }
    }
}
