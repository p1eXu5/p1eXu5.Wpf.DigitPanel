using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Effects;
using System.Windows.Shapes;

#pragma warning disable IDE1006 // Naming Styles

namespace p1eXu5.Wpf.DigitPanel;

[TemplatePart(Name = "PART_1", Type = typeof(Path))]
[TemplatePart(Name = "PART_2", Type = typeof(Path))]
[TemplatePart(Name = "PART_3", Type = typeof(Path))]
[TemplatePart(Name = "PART_4", Type = typeof(Path))]
[TemplatePart(Name = "PART_5", Type = typeof(Path))]
[TemplatePart(Name = "PART_6", Type = typeof(Path))]
[TemplatePart(Name = "PART_7", Type = typeof(Path))]
[TemplatePart(Name = "PART_Dot", Type = typeof(Path))]
[TemplatePart(Name = "PART_Colon", Type = typeof(Path))]
public class Digit : Control
{
    static Digit()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(Digit), new FrameworkPropertyMetadata(typeof(Digit)));
    }


    public string? Mask
    {
        get { return (string)GetValue(MaskProperty); }
        set { SetValue(MaskProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Mask.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty MaskProperty =
        DependencyProperty.Register(
            "Mask",
            typeof(string),
            typeof(Digit),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, OnMaskChanged));

    private static void OnMaskChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        Digit digit = (Digit)d;
        string? mask = digit.Mask;

        if (string.IsNullOrWhiteSpace(mask))
        {
            digit.IsTopLeftOn = digit.IsTopMiddleOn = digit.IsTopRightOn = digit.IsMiddleOn = digit.IsBottomLeftOn = digit.IsBottomMiddleOn = digit.IsBottomRightOn = false;
            return;
        }

        int[] m = mask.Split(",").Select(ch => int.Parse(ch)).Where(n => n == 0 || n == 1).ToArray();
        if (m.Length == 1)
        {
            digit.IsTopLeftOn = digit.IsTopMiddleOn = digit.IsTopRightOn = digit.IsMiddleOn = digit.IsBottomLeftOn = digit.IsBottomMiddleOn = digit.IsBottomRightOn = m[0] == 1;
            return;
        }

        if (m.Length == 7)
        {
            digit.IsTopLeftOn = m[0] == 1;
            digit.IsTopMiddleOn = m[1] == 1;
            digit.IsTopRightOn = m[2] == 1;
            digit.IsMiddleOn = m[3] == 1;
            digit.IsBottomLeftOn = m[4] == 1;
            digit.IsBottomMiddleOn = m[5] == 1;
            digit.IsBottomRightOn = m[6] == 1;
        }
    }


    #region DropShadowRadius

    internal static double GetDropShadowRadius(UIElement target) =>
        (double)target.GetValue(DropShadowRadiusProperty);

    // Declare a set accessor method.
    internal static void SetDropShadowRadius(UIElement target, double value) =>
        target.SetValue(DropShadowRadiusProperty, value);

    // Using a DependencyProperty as the backing store for ActiveRadius.  This enables animation, styling, binding, etc...
    internal static readonly DependencyProperty DropShadowRadiusProperty =
        DependencyProperty.RegisterAttached(
            "DropShadowRadius",
            typeof(double),
            typeof(Digit),
            new FrameworkPropertyMetadata(8.0, FrameworkPropertyMetadataOptions.AffectsRender));

    #endregion ───────────────────────────────────────────────────── DropShadowRadius ─┘

    #region DropShadowOpacity

    internal static double GetDropShadowOpacity(UIElement target) =>
        (double)target.GetValue(DropShadowOpacityProperty);

    // Declare a set accessor method.
    internal static void SetDropShadowOpacity(UIElement target, double value) =>
        target.SetValue(DropShadowOpacityProperty, value);

    // Using a DependencyProperty as the backing store for ActiveRadius.  This enables animation, styling, binding, etc...
    internal static readonly DependencyProperty DropShadowOpacityProperty =
        DependencyProperty.RegisterAttached(
            "DropShadowOpacity",
            typeof(double),
            typeof(Digit),
            new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsRender));

    #endregion ───────────────────────────────────────────────────── DropShadowRadius ─┘


    #region ActiveRadius

    public double ActiveRadius
    {
        get { return (double)GetValue(ActiveRadiusProperty); }
        set { SetValue(ActiveRadiusProperty, value); }
    }

    // Using a DependencyProperty as the backing store for ActiveRadius.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ActiveRadiusProperty =
        DependencyProperty.Register(
            "ActiveRadius",
            typeof(double),
            typeof(Digit),
            new FrameworkPropertyMetadata(8.0, FrameworkPropertyMetadataOptions.AffectsRender));

    #endregion ───────────────────────────────────────────────────── ActiveRadius ─┘


        #region InactiveRadius

    public double InactiveRadius
    {
        get { return (double)GetValue(InactiveRadiusProperty); }
        set { SetValue(InactiveRadiusProperty, value); }
    }

    // Using a DependencyProperty as the backing store for ActiveRadius.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty InactiveRadiusProperty =
        DependencyProperty.Register(
            "InactiveRadius",
            typeof(double),
            typeof(Digit),
            new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsRender));

    #endregion ───────────────────────────────────────────────────── InactiveRadius ─┘


    internal bool IsTopLeftOn
    {
        get { return (bool)GetValue(IsTopLeftOnProperty); }
        set { SetValue(IsTopLeftOnProperty, value); }
    }

    // Using a DependencyProperty as the backing store for IsTopLeftOn.  This enables animation, styling, binding, etc...
    internal static readonly DependencyProperty IsTopLeftOnProperty =
        DependencyProperty.Register(
            "IsTopLeftOn",
            typeof(bool),
            typeof(Digit),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));

    internal bool IsTopMiddleOn
    {
        get { return (bool)GetValue(IsTopMiddleOnProperty); }
        set { SetValue(IsTopMiddleOnProperty, value); }
    }

    // Using a DependencyProperty as the backing store for IsTopLeftOn.  This enables animation, styling, binding, etc...
    internal static readonly DependencyProperty IsTopMiddleOnProperty =
        DependencyProperty.Register(
            "IsTopMiddleOn",
            typeof(bool),
            typeof(Digit),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));

    internal bool IsTopRightOn
    {
        get { return (bool)GetValue(IsTopRightOnProperty); }
        set { SetValue(IsTopRightOnProperty, value); }
    }

    // Using a DependencyProperty as the backing store for IsTopLeftOn.  This enables animation, styling, binding, etc...
    internal static readonly DependencyProperty IsTopRightOnProperty =
        DependencyProperty.Register(
            "IsTopRightOn",
            typeof(bool),
            typeof(Digit),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));

    internal bool IsMiddleOn
    {
        get { return (bool)GetValue(IsMiddleOnProperty); }
        set { SetValue(IsMiddleOnProperty, value); }
    }

    // Using a DependencyProperty as the backing store for IsTopLeftOn.  This enables animation, styling, binding, etc...
    internal static readonly DependencyProperty IsMiddleOnProperty =
        DependencyProperty.Register(
            "IsMiddleOn",
            typeof(bool),
            typeof(Digit),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));

    internal bool IsBottomLeftOn
    {
        get { return (bool)GetValue(IsBottomLeftOnProperty); }
        set { SetValue(IsBottomLeftOnProperty, value); }
    }

    // Using a DependencyProperty as the backing store for IsTopLeftOn.  This enables animation, styling, binding, etc...
    internal static readonly DependencyProperty IsBottomLeftOnProperty =
        DependencyProperty.Register(
            "IsBottomLeftOn",
            typeof(bool),
            typeof(Digit),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));

    internal bool IsBottomMiddleOn
    {
        get { return (bool)GetValue(IsBottomMiddleOnProperty); }
        set { SetValue(IsBottomMiddleOnProperty, value); }
    }

    // Using a DependencyProperty as the backing store for IsTopLeftOn.  This enables animation, styling, binding, etc...
    internal static readonly DependencyProperty IsBottomMiddleOnProperty =
        DependencyProperty.Register(
            "IsBottomMiddleOn",
            typeof(bool),
            typeof(Digit),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));

    internal bool IsBottomRightOn
    {
        get { return (bool)GetValue(IsBottomRightOnProperty); }
        set { SetValue(IsBottomRightOnProperty, value); }
    }

    // Using a DependencyProperty as the backing store for IsTopLeftOn.  This enables animation, styling, binding, etc...
    internal static readonly DependencyProperty IsBottomRightOnProperty =
        DependencyProperty.Register(
            "IsBottomRightOn",
            typeof(bool),
            typeof(Digit),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));

    public bool IsDotOn
    {
        get { return (bool)GetValue(IsDotOnProperty); }
        set { SetValue(IsDotOnProperty, value); }
    }

    // Using a DependencyProperty as the backing store for IsTopLeftOn.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty IsDotOnProperty =
        DependencyProperty.Register(
            "IsDotOn",
            typeof(bool),
            typeof(Digit),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));

    public Visibility DotVisibility
    {
        get { return (Visibility)GetValue(DotVisibilityProperty); }
        set { SetValue(DotVisibilityProperty, value); }
    }

    // Using a DependencyProperty as the backing store for IsTopLeftOn.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty DotVisibilityProperty =
        DependencyProperty.Register(
            "DotVisibility",
            typeof(Visibility),
            typeof(Digit),
            new FrameworkPropertyMetadata(Visibility.Visible, FrameworkPropertyMetadataOptions.AffectsRender));

    public bool IsColonOn
    {
        get { return (bool)GetValue(IsColonOnProperty); }
        set { SetValue(IsColonOnProperty, value); }
    }

    // Using a DependencyProperty as the backing store for IsTopLeftOn.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty IsColonOnProperty =
        DependencyProperty.Register(
            "IsColonOn",
            typeof(bool),
            typeof(Digit),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));

    public Visibility ColonVisibility
    {
        get { return (Visibility)GetValue(ColonVisibilityProperty); }
        set { SetValue(ColonVisibilityProperty, value); }
    }

    // Using a DependencyProperty as the backing store for IsTopLeftOn.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ColonVisibilityProperty =
        DependencyProperty.Register(
            "ColonVisibility",
            typeof(Visibility),
            typeof(Digit),
            new FrameworkPropertyMetadata(Visibility.Visible, FrameworkPropertyMetadataOptions.AffectsRender));
}
