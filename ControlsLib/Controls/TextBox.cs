using ControlsLib.Controls.Interfaces;
using System.Windows;
using System.Windows.Media;

namespace ControlsLib.Controls
{
    public class TextBox : System.Windows.Controls.TextBox, IRounded, ISigned
    {
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(TextBox));
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(TextBox));
        public static readonly DependencyProperty TitleFontSizeProperty =
            DependencyProperty.Register("TitleFontSize", typeof(double), typeof(TextBox));
        public static readonly DependencyProperty TitleFontWeightProperty =
            DependencyProperty.Register("TitleFontWeight", typeof(FontWeight), typeof(TextBox));
        public static readonly DependencyProperty TitleFontStyleProperty =
            DependencyProperty.Register("TitleFontStyle", typeof(FontStyle), typeof(TextBox));
        public static readonly DependencyProperty TitleFontFamilyProperty =
            DependencyProperty.Register("TitleFontFamily", typeof(FontFamily), typeof(TextBox));
        public static readonly DependencyProperty TitleFontStretchProperty =
            DependencyProperty.Register("TitleFontStretch", typeof(FontStretch), typeof(TextBox));
        public static readonly DependencyProperty TitleForegroundProperty =
            DependencyProperty.Register("TitleForeground", typeof(Brush), typeof(TextBox));
        public static readonly DependencyProperty TitleOpacityProperty =
            DependencyProperty.Register("TitleOpacity", typeof(double), typeof(TextBox));
        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register("Placeholder", typeof(string), typeof(TextBox));
        public static readonly DependencyProperty PlaceholderFontSizeProperty =
            DependencyProperty.Register("PlaceholderFontSize", typeof(double), typeof(TextBox));
        public static readonly DependencyProperty PlaceholderFontWeightProperty =
            DependencyProperty.Register("PlaceholderFontWeight", typeof(FontWeight), typeof(TextBox));
        public static readonly DependencyProperty PlaceholderFontStyleProperty =
            DependencyProperty.Register("PlaceholderFontStyle", typeof(FontStyle), typeof(TextBox));
        public static readonly DependencyProperty PlaceholderFontFamilyProperty =
            DependencyProperty.Register("PlaceholderFontFamily", typeof(FontFamily), typeof(TextBox));
        public static readonly DependencyProperty PlaceholderFontStretchProperty =
            DependencyProperty.Register("PlaceholderFontStretch", typeof(FontStretch), typeof(TextBox));
        public static readonly DependencyProperty PlaceholderForegroundProperty =
            DependencyProperty.Register("PlaceholderForeground", typeof(Brush), typeof(TextBox));
        public static readonly DependencyProperty PlaceholderOpacityProperty =
            DependencyProperty.Register("PlaceholderOpacity", typeof(double), typeof(TextBox));

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set=> SetValue(TitleProperty, value);
        }
        public double TitleFontSize
        {
            get => (double)GetValue(TitleFontSizeProperty);
            set => SetValue(TitleFontSizeProperty, value);
        }
        public FontWeight TitleFontWeight
        {
            get => (FontWeight)GetValue(TitleFontWeightProperty);
            set => SetValue(TitleFontWeightProperty, FontWeight);
        }
        public FontStyle TitleFontStyle
        {
            get => (FontStyle)GetValue(TitleFontStyleProperty);
            set => SetValue(TitleFontStyleProperty, value);
        }
        public FontFamily TitleFontFamily
        {
            get => (FontFamily)GetValue(TitleFontFamilyProperty);
            set => SetValue(TitleFontFamilyProperty, value);
        }
        public FontStretch TitleFontStretch
        {
            get => (FontStretch)GetValue(TitleFontStretchProperty);
            set => SetValue(TitleFontStretchProperty, value);
        }
        public Brush TitleForeground
        {
            get => (Brush)GetValue(TitleForegroundProperty);
            set => SetValue(TitleForegroundProperty, value);
        }
        public double TitleOpacity
        {
            get => (double)GetValue(TitleOpacityProperty);
            set => SetValue(TitleOpacityProperty, value);
        }
        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }
        public double PlaceholderFontSize
        {
            get => (double)GetValue(PlaceholderFontSizeProperty);
            set => SetValue(PlaceholderFontSizeProperty, value);
        }
        public FontWeight PlaceholderFontWeight
        {
            get => (FontWeight)GetValue(PlaceholderFontWeightProperty);
            set => SetValue(PlaceholderFontWeightProperty, FontWeight);
        }
        public FontStyle PlaceholderFontStyle
        {
            get => (FontStyle)GetValue(PlaceholderFontStyleProperty);
            set => SetValue(PlaceholderFontStyleProperty, value);
        }
        public FontFamily PlaceholderFontFamily
        {
            get => (FontFamily)GetValue(PlaceholderFontFamilyProperty);
            set => SetValue(PlaceholderFontFamilyProperty, value);
        }
        public FontStretch PlaceholderFontStretch
        {
            get => (FontStretch)GetValue(PlaceholderFontStretchProperty);
            set => SetValue(PlaceholderFontStretchProperty, value);
        }
        public Brush PlaceholderForeground
        {
            get => (Brush)GetValue(PlaceholderForegroundProperty);
            set => SetValue(PlaceholderForegroundProperty, value);
        }
        public double PlaceholderOpacity
        {
            get => (double)GetValue(PlaceholderOpacityProperty);
            set => SetValue(PlaceholderOpacityProperty, value);
        }
        static TextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(TextBox),
                new FrameworkPropertyMetadata(typeof(TextBox)));
        }
    }
}
