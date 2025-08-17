using ControlsLib.Controls.Interfaces;
using System.Windows;
using System.Windows.Media;

namespace ControlsLib.Controls
{
    public class CheckBox : System.Windows.Controls.CheckBox, ISigned, IRounded
    {
        public static DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(CheckBox));
        public static DependencyProperty TitleFontSizeProperty =
            DependencyProperty.Register("TitleFontSize", typeof(double), typeof(CheckBox));
        public static DependencyProperty TitleFontWeightProperty =
            DependencyProperty.Register("TitleFontWeight", typeof(FontWeight), typeof(CheckBox));
        public static DependencyProperty TitleFontStyleProperty =
            DependencyProperty.Register("TitleFontStyle", typeof(FontStyle), typeof(CheckBox));
        public static DependencyProperty TitleFontFamilyProperty =
            DependencyProperty.Register("TitleFontFamily", typeof(FontFamily), typeof(CheckBox));
        public static DependencyProperty TitleFontStretchProperty =
            DependencyProperty.Register("TitleFontStretch", typeof(FontStretch), typeof(CheckBox));
        public static DependencyProperty TitleForegroundProperty =
            DependencyProperty.Register("TitleForeground", typeof(Brush), typeof(CheckBox));
        public static DependencyProperty TitleOpacityProperty =
            DependencyProperty.Register("TitleOpacity", typeof(double), typeof(CheckBox));
        public static DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(CheckBox));
        public static DependencyProperty CheckWidthProperty =
            DependencyProperty.Register("CheckWidth", typeof(double), typeof(CheckBox));
        public static DependencyProperty CheckHeightProperty =
            DependencyProperty.Register("CheckHeight", typeof(double), typeof(CheckBox));
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
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
        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        public double CheckWidth
        {
            get => (double)GetValue(CheckWidthProperty);
            set => SetValue(CheckWidthProperty, value);
        }
        public double CheckHeight
        {
            get => (double)GetValue(CheckHeightProperty);
            set => SetValue(CheckHeightProperty, value);
        }
        static CheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(CheckBox),
                new FrameworkPropertyMetadata(typeof(CheckBox)));
        }
    }
}
