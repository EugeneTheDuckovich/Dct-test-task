using System.Windows;
using DctTestTask.Repositories;
using DctTestTask.Views;

namespace DctTestTask;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MainFrame.Content = new MainMenuPage(MainFrame,new CoinCapService());
    }
}
