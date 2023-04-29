using System.Windows.Controls;
using System.Windows.Input;
using test_task_src.Models.DTOs;
using test_task_src.Repositories.Abstract;
using test_task_src.Utilities;
using test_task_src.ViewModels;

namespace test_task_src.Views;

/// <summary>
/// Interaction logic for CurrencyDetailsPage.xaml
/// </summary>
public partial class CurrencyDetailsPage : Page
{
    public CurrencyDetailsPage(Frame mainframe, 
        ICryptoRepository<CoinCapCurrency> cryptoRepository, string currencyId)
    {
        InitializeComponent();
        DataContext = new CurrencyDetailsViewModel(mainframe,cryptoRepository,currencyId);
    }
}
