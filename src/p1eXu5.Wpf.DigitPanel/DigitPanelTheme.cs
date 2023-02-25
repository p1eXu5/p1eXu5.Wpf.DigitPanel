using System.Windows;
using System.Windows.Media;

namespace p1eXu5.Wpf.DigitPanel;

public class DigitPanelTheme : ResourceDictionary
{
    public DigitPanelTheme()
    {
        var bgDarkPanelColor = Color.FromRgb(0x11, 0x00, 0x00);
        var bgDarkPanelBrush = new SolidColorBrush(bgDarkPanelColor);
        bgDarkPanelBrush.Freeze();
        this[DigitPanelColors.DigitPanelBackgroundKey] = bgDarkPanelBrush;

        var bgDarkDigitInactiveColor = Color.FromRgb(0x45, 0x00, 0x00);
        var bgDarkDigitInactiveBrush = new SolidColorBrush(bgDarkDigitInactiveColor);
        bgDarkDigitInactiveBrush.Freeze();
        this[DigitPanelColors.InactiveDigitBackgroundKey] = bgDarkDigitInactiveBrush;

        var bgDarkDigitActiveColor = Color.FromRgb(0xFF, 0x00, 0x00);
        var bgDarkDigitActiveBrush = new SolidColorBrush(bgDarkDigitActiveColor);
        bgDarkDigitActiveBrush.Freeze();
        this[DigitPanelColors.ActiveDigitBackgroundKey] = bgDarkDigitActiveBrush;
    }
}
