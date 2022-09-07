using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace p1eXu5.Wpf.DigitPanel;

internal class RadiusToOpacityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is double d)
        {
            return
                d == 0 ? 0.0 : 1.0;
        }

        return DependencyProperty.UnsetValue;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
