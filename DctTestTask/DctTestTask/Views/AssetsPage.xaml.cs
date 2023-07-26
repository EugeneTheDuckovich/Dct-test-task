using System.Windows.Controls;
using DctTestTask.Models.DTOs;
using DctTestTask.Repositories;
using DctTestTask.Repositories.Abstract;
using DctTestTask.ViewModels;
using DctTestTask.Models.PageModels;

namespace DctTestTask.Views;

/// <summary>
/// Interaction logic for AssetsPage.xaml
/// </summary>
public partial class AssetsPage : Page
{
    public AssetsPage(Frame mainframe)
    {
        InitializeComponent();
        DataContext = new AssetsViewModel(mainframe, new CoinCapService());
    }

    public AssetsPage(Frame mainframe, ICryptoService<CoinCapCurrency> cryptoService)
    {
        InitializeComponent();
        DataContext = new AssetsViewModel(mainframe, cryptoService);
    }
}
