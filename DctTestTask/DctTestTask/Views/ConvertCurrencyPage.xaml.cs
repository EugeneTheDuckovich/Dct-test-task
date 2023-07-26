using System.Windows.Controls;
using DctTestTask.Models.DTOs;
using DctTestTask.Repositories.Abstract;
using DctTestTask.ViewModels;

namespace DctTestTask.Views;

public partial class ConvertCurrencyPage : Page
{
    public ConvertCurrencyPage(Frame mainFrame,ICryptoService<CoinCapCurrency> cryptoService)
    {
        InitializeComponent();
        DataContext = new ConvertCurrencyViewModel(mainFrame,cryptoService);
    }
}