using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace p1eXu5.Wpf.DigitPanel.DemoApp;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void m_TopLeft_Checked(object sender, RoutedEventArgs e)
    {
        string mask =
            (m_TopLeft is not null && m_TopLeft.IsChecked.HasValue && m_TopLeft.IsChecked.Value ? "1," : "0,")
            + (m_TopMiddle is not null && m_TopMiddle.IsChecked.HasValue && m_TopMiddle.IsChecked.Value ? "1," : "0,")
            + "0,0,0,0,0";

        m_Digit.Mask = mask;
    }

    private void SeedDigitTable(object sender, RoutedEventArgs e)
    {
        m_DigitTable.Value = Random.Shared.NextDouble() * 1000;
    }

    private void SeedTimerTable(object sender, RoutedEventArgs e)
    {
        int hours = (int)Random.Shared.NextInt64(1, 23);
        int min = (int)Random.Shared.NextInt64(0, 59);
        int sec = (int)Random.Shared.NextInt64(0, 59);
        m_TimerTable.Value = new TimeSpan(hours, min, sec);
    }
}