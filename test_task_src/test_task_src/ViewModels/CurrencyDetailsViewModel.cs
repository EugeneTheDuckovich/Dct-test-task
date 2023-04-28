using System.Windows.Controls;
using System.Windows.Input;
using test_task_src.Models.DTOs;
using test_task_src.Repositories.Abstract;
using test_task_src.Utilities;
using test_task_src.ViewModels.Abstract;
using test_task_src.Views;

namespace test_task_src.ViewModels;

public class CurrencyDetailsViewModel : ViewModel
{
    private CoinCapCurrency _currency;
    public CoinCapCurrency Currency 
    {
        get => _currency;
        private set
        {
            _currency = value;
            OnPropertyChanged(nameof(Currency));
        }
    }

    public CurrencyDetailsViewModel(Frame mainframe, ICryptoRepository<CoinCapCurrency> cryptoRepository,
        string currencyId) 
        : base(mainframe, cryptoRepository)
    {
        _currency = _cryptoRepository.GetCurrencyByIdAsync(currencyId).Result;
    }

    public ICommand GoToAssetsCommand => new RelayCommand(parameter =>
    {
        _mainFrame.Content = new AssetsPage(_mainFrame,_cryptoRepository);
    });
}
