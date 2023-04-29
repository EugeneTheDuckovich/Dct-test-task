using System.Windows.Controls;
using test_task_src.Models.DTOs;
using test_task_src.Models.PageModels;
using test_task_src.Repositories;
using test_task_src.Repositories.Abstract;
using test_task_src.ViewModels;

namespace test_task_src.Views;

/// <summary>
/// Interaction logic for AssetsPage.xaml
/// </summary>
public partial class AssetsPage : Page
{
    public AssetsPage(Frame mainframe)
    {
        InitializeComponent();
        DataContext = new AssetsViewModel(mainframe,new CoinCapRepository());
    }

    public AssetsPage(Frame mainframe, ICryptoRepository<CoinCapCurrency> cryptoRepository)
    {
        InitializeComponent();
        DataContext = new AssetsViewModel(mainframe, cryptoRepository);
    }
}
