using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace ControlsLib.Controls
{
    public class ListView : ListBox
    {
        public static readonly DependencyProperty ScrollViewerStyleProperty
            = DependencyProperty.Register("ScrollViewerStyle", typeof(Style), typeof(ListView));
        public static readonly DependencyProperty HoverItemBorderBrushProperty
            = DependencyProperty.Register("HoverItemBorderBrush", typeof(Brush), typeof(ListView));
        public static readonly DependencyProperty HoverItemBackgroundProperty
            = DependencyProperty.Register("HoverItemBackground", typeof(Brush), typeof(ListView));
        public static readonly DependencyProperty SelectedItemBorderBrushProperty
            = DependencyProperty.Register("SelectedItemBorderBrush", typeof(Brush), typeof(ListView));
        public static readonly DependencyProperty SelectedItemBackgroundProperty
            = DependencyProperty.Register("SelectedItemBackground", typeof(Brush), typeof(ListView));
        public static readonly DependencyProperty ItemBorderThicknessProperty
            = DependencyProperty.Register("ItemBorderThickness", typeof(Thickness), typeof(ListView));
        public static readonly DependencyProperty ItemBorderRadiusProperty
            = DependencyProperty.Register("ItemBorderRadius", typeof(CornerRadius), typeof(ListView));
        public static readonly DependencyProperty ScrollBarWidthProperty
            = DependencyProperty.Register("ScrollBarWidth", typeof(double), typeof(ListView));
        public static readonly DependencyProperty ScrollBarBackgroundProperty
            = DependencyProperty.Register("ScrollBarBackground", typeof(Brush), typeof(ListView));
        public static readonly DependencyProperty ScrollBarCornerRadiusProperty
            = DependencyProperty.Register("ScrollBarCornerRadius", typeof(CornerRadius), typeof(ListView));
        public static readonly DependencyProperty ScrollBarThumbBackgroundProperty
            = DependencyProperty.Register("ScrollBarThumbBackground", typeof(Brush), typeof(ListView));
        public static readonly DependencyProperty HoverScrollBarThumbBackgroundProperty
            = DependencyProperty.Register("HoverScrollBarThumbBackground", typeof(Brush), typeof(ListView));
        public static readonly DependencyProperty ClickScrollBarThumbBackgroundProperty
            = DependencyProperty.Register("ClickScrollBarThumbBackground", typeof(Brush), typeof(ListView));
        public static readonly DependencyProperty ScrollBarThumbCornerRadiusProperty
            = DependencyProperty.Register("ScrollBarThumbCornerRadius", typeof(CornerRadius), typeof(ListView));
        public static readonly DependencyProperty ScrollBarThumbWidthProperty
            = DependencyProperty.Register("ScrollBarThumbWidth", typeof(double), typeof(ListView));
        public static readonly DependencyProperty CanSelectProperty
            = DependencyProperty.Register("CanSelect", typeof(bool), typeof(ListView));

        public Style ScrollViewerStyle
        {
            get => (Style)GetValue(ScrollViewerStyleProperty);
            set => SetValue(ScrollViewerStyleProperty, value);
        }

        public Brush HoverItemBorderBrush
        {
            get => (Brush)GetValue(HoverItemBorderBrushProperty);
            set => SetValue(HoverItemBorderBrushProperty, value);
        }

        public Brush HoverItemBackground
        {
            get => (Brush)GetValue(HoverItemBackgroundProperty);
            set => SetValue(HoverItemBackgroundProperty, value);
        }

        public Brush SelectedItemBorderBrush
        {
            get => (Brush)GetValue(SelectedItemBorderBrushProperty);
            set => SetValue(SelectedItemBorderBrushProperty, value);
        }
        public Brush SelectedItemBackground
        {
            get => (Brush)GetValue(SelectedItemBackgroundProperty);
            set => SetValue(SelectedItemBackgroundProperty, value);
        }

        public Thickness ItemBorderThickness
        {
            get => (Thickness)GetValue(ItemBorderThicknessProperty);
            set => SetValue(ItemBorderThicknessProperty, value);
        }

        public CornerRadius ItemBorderRadius
        {
            get => (CornerRadius)GetValue(ItemBorderRadiusProperty);
            set => SetValue(ItemBorderRadiusProperty, value);
        }

        public double ScrollBarWidth
        {
            get => (double)GetValue(ScrollBarWidthProperty);
            set => SetValue(ScrollBarWidthProperty, value);
        }

        public Brush ScrollBarBackground
        {
            get => (Brush)GetValue(ScrollBarBackgroundProperty);
            set => SetValue(ScrollBarBackgroundProperty, value);
        }

        public CornerRadius ScrollBarCornerRadius
        {
            get => (CornerRadius)GetValue(ScrollBarCornerRadiusProperty);
            set => SetValue(ScrollBarCornerRadiusProperty, value);
        }

        public Brush ScrollBarThumbBackground
        {
            get => (Brush)GetValue(ScrollBarThumbBackgroundProperty);
            set => SetValue(ScrollBarThumbBackgroundProperty, value);
        }

        public Brush HoverScrollBarThumbBackground
        {
            get => (Brush)GetValue(HoverScrollBarThumbBackgroundProperty);
            set => SetValue(HoverScrollBarThumbBackgroundProperty, value);
        }

        public Brush ClickScrollBarThumbBackground
        {
            get => (Brush)GetValue(ClickScrollBarThumbBackgroundProperty);
            set => SetValue(ClickScrollBarThumbBackgroundProperty, value);
        }

        public CornerRadius ScrollBarThumbCornerRadius
        {
            get => (CornerRadius)GetValue(ScrollBarThumbCornerRadiusProperty);
            set => SetValue(ScrollBarThumbCornerRadiusProperty, value);
        }

        public double ScrollBarThumbWidth
        {
            get => (double)GetValue(ScrollBarThumbWidthProperty);
            set => SetValue(ScrollBarThumbWidthProperty, value);
        }

        public bool CanSelect
        {
            get => (bool)GetValue(CanSelectProperty);
            set => SetValue(CanSelectProperty, value);
        }

        static ListView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(ListView),
                new FrameworkPropertyMetadata(typeof(ListView)));
        }

    }
}
