using System.Collections.Generic;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace p1eXu5.Wpf.DigitPanel;

public class DigitTableBase : Control
{
    protected static DigitParameters _zero = new DigitParameters { Mask = "0", Dot = false };

    protected static Dictionary<char, Func<DigitParameters>> _dagitMap = new()
    {
        ['0'] = () => new DigitParameters { Mask = "1,1,1,0,1,1,1", Dot = false, Colon = false },
        ['1'] = () => new DigitParameters { Mask = "0,0,1,0,0,0,1", Dot = false, Colon = false },
        ['2'] = () => new DigitParameters { Mask = "0,1,1,1,1,1,0", Dot = false, Colon = false },
        ['3'] = () => new DigitParameters { Mask = "0,1,1,1,0,1,1", Dot = false, Colon = false },
        ['4'] = () => new DigitParameters { Mask = "1,0,1,1,0,0,1", Dot = false, Colon = false },
        ['5'] = () => new DigitParameters { Mask = "1,1,0,1,0,1,1", Dot = false, Colon = false },
        ['6'] = () => new DigitParameters { Mask = "1,1,0,1,1,1,1", Dot = false, Colon = false },
        ['7'] = () => new DigitParameters { Mask = "0,1,1,0,0,0,1", Dot = false, Colon = false },
        ['8'] = () => new DigitParameters { Mask = "1,1,1,1,1,1,1", Dot = false, Colon = false },
        ['9'] = () => new DigitParameters { Mask = "1,1,1,1,0,1,1", Dot = false, Colon = false },
        ['-'] = () => new DigitParameters { Mask = "0,0,0,1,0,0,0", Dot = false, Colon = false },
    };


    static DigitTableBase()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(DigitTableBase), new FrameworkPropertyMetadata(typeof(DigitTableBase)));
    }

    internal List<DigitParameters> Digits
    {
        get { return (List<DigitParameters>)GetValue(DigitsProperty); }
        set { SetValue(DigitsProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Digits.  This enables animation, styling, binding, etc...
    internal static readonly DependencyProperty DigitsProperty =
        DependencyProperty.Register(
            "Digits",
            typeof(List<DigitParameters>),
            typeof(DigitTableBase),
            new FrameworkPropertyMetadata(
                defaultValue: null,
                FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));



    public Brush DigitBackground
    {
        get { return (Brush)GetValue(DigitBackgroundProperty); }
        set { SetValue(DigitBackgroundProperty, value); }
    }

    // Using a DependencyProperty as the backing store for DigitBackground.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty DigitBackgroundProperty =
        DependencyProperty.Register(
            "DigitBackground",
            typeof(Brush),
            typeof(DigitTableBase),
            new FrameworkPropertyMetadata(Brushes.Black, FrameworkPropertyMetadataOptions.AffectsRender));



    public double DigitWidth
    {
        get { return (double)GetValue(DigitWidthProperty); }
        set { SetValue(DigitWidthProperty, value); }
    }

    // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty DigitWidthProperty =
        DependencyProperty.Register(
            "DigitWidth",
            typeof(double),
            typeof(DigitTableBase),
            new FrameworkPropertyMetadata(100.0, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));

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
            typeof(DigitTableBase),
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
            typeof(DigitTableBase),
            new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsRender));

    #endregion ───────────────────────────────────────────────────── InactiveRadius ─┘
}
