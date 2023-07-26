using System.Windows.Controls;
using DctTestTask.Models.DTOs;
using DctTestTask.Repositories.Abstract;
using DctTestTask.ViewModels;

namespace DctTestTask.Views;

public partial class MainMenuPage : Page
{
    public MainMenuPage(Frame mainFrame, ICryptoService<CoinCapCurrency> cryptoService)
    {
        InitializeComponent();
        DataContext = new MainMenuViewModel(mainFrame, cryptoService);
    }
}