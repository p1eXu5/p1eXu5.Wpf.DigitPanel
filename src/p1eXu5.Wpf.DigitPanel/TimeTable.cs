using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace p1eXu5.Wpf.DigitPanel;

public class TimerTable : DigitTableBase
{

    static TimerTable()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(TimerTable), new FrameworkPropertyMetadata(typeof(DigitTableBase)));
    }

    public TimeSpan Value
    {
        get { return (TimeSpan)GetValue(ValueProperty); }
        set { SetValue(ValueProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(
            "Value",
            typeof(TimeSpan),
            typeof(TimerTable),
            new FrameworkPropertyMetadata(
                defaultValue: TimeSpan.Zero,
                FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender,
                propertyChangedCallback: OnValueChanged
            )
        );

    private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        TimerTable table = (TimerTable)d;
        TimeSpan value = table.Value;

        var digits = new List<DigitParameters>();
        string s = value.ToString(table.Format);


        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == ':')
            {
                digits.Last().Colon = true;
                continue;
            }

            digits.Add(_dagitMap[s[i]]());
        }

        table.Digits = digits;
    }

    public string Format
    {
        get { return (string)GetValue(FormatProperty); }
        set { SetValue(FormatProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Format.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty FormatProperty =
        DependencyProperty.Register(
            "Format",
            typeof(string),
            typeof(TimerTable),
            new FrameworkPropertyMetadata(
                "",
                FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsParentMeasure,
                OnValueChanged));
}
