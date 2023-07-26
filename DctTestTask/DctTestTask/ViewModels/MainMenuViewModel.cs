using System.Windows.Controls;
using System.Windows.Input;
using DctTestTask.Models.DTOs;
using DctTestTask.Repositories.Abstract;
using DctTestTask.Utilities;
using DctTestTask.ViewModels.Abstract;
using DctTestTask.Views;

namespace DctTestTask.ViewModels;

public class MainMenuViewModel : ViewModel
{
    public ICommand GoToAssetsPageCommand => new RelayCommand(p =>
    {
        _mainFrame.Content = new AssetsPage(_mainFrame, _cryptoService);
    });
    
    public ICommand GoToConvertPageCommand => new RelayCommand(p =>
    {
        _mainFrame.Content = new ConvertCurrencyPage(_mainFrame, _cryptoService);
    });
    
    public MainMenuViewModel(Frame mainFrame, ICryptoService<CoinCapCurrency> cryptoService)
        : base(mainFrame,cryptoService) 
    {}
}