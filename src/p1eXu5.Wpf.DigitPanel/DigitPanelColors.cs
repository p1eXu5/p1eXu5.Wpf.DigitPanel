using System.Windows;

namespace p1eXu5.Wpf.DigitPanel;

public static class DigitPanelColors
{
    public static ComponentResourceKey DigitPanelBackgroundKey => new ComponentResourceKey(
            typeof(DigitPanelColors), "DigitPanelBackground");

    public static ComponentResourceKey InactiveDigitBackgroundKey => new ComponentResourceKey(
            typeof(DigitPanelColors), "InactiveDigitBackground");

    public static ComponentResourceKey ActiveDigitBackgroundKey => new ComponentResourceKey(
            typeof(DigitPanelColors), "ActiveDigitBackground");
}
