using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace p1eXu5.Wpf.DigitPanel;
/// <summary>
/// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
///
/// Step 1a) Using this custom control in a XAML file that exists in the current project.
/// Add this XmlNamespace attribute to the root element of the markup file where it is 
/// to be used:
///
///     xmlns:MyNamespace="clr-namespace:Petroleum.WpfCustomControls"
///
///
/// Step 1b) Using this custom control in a XAML file that exists in a different project.
/// Add this XmlNamespace attribute to the root element of the markup file where it is 
/// to be used:
///
///     xmlns:MyNamespace="clr-namespace:Petroleum.WpfCustomControls;assembly=Petroleum.WpfCustomControls"
///
/// You will also need to add a project reference from the project where the XAML file lives
/// to this project and Rebuild to avoid compilation errors:
///
///     Right click on the target project in the Solution Explorer and
///     "Add Reference"->"Projects"->[Select this project]
///
///
/// Step 2)
/// Go ahead and use your control in the XAML file.
///
///     <MyNamespace:CustomControl1/>
///
/// </summary>
public class DigitTable : DigitTableBase
{
    static DigitTable()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(DigitTable), new FrameworkPropertyMetadata(typeof(DigitTableBase)));
    }

    public double? Value
    {
        get { return (double?)GetValue(ValueProperty); }
        set { SetValue(ValueProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(
            "Value",
            typeof(double?),
            typeof(DigitTable),
            new FrameworkPropertyMetadata(
                defaultValue: null,
                FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender,
                propertyChangedCallback: OnValueChanged
            )
        );

    private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        DigitTable table = (DigitTable)d;
        double value = table.Value.HasValue ? table.Value.Value : 0;

        var digits = new List<DigitParameters>();

        string format = table.Format;
        string s = value.ToString(table.Format);

        if (format.Length > s.Length)
        {
            for (int i = 0; i < table.Format.Length - s.Length; i++)
            {
                digits.Add(_zero);
            }
        }

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '.')
            {
                digits.Last().Dot = true;
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
            typeof(DigitTable),
            new FrameworkPropertyMetadata(
                "",
                FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsParentMeasure,
                OnValueChanged));
}
