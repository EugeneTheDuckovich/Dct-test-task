using System.Windows.Controls;
using System.Windows.Input;
using test_task_src.Mappers;
using test_task_src.Models.DTOs;
using test_task_src.Models.PageModels;
using test_task_src.Repositories.Abstract;
using test_task_src.Utilities;
using test_task_src.ViewModels.Abstract;
using test_task_src.Views;

namespace test_task_src.ViewModels;

public class CurrencyDetailsViewModel : ViewModel
{
    private DetailsPageModel _currency;
    public DetailsPageModel Currency 
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
        InitializeCurrency(currencyId);
    }

    private async void InitializeCurrency(string currencyId)
    {
        var dto = await _cryptoRepository.GetCurrencyById(currencyId);
        var exchanges = await _cryptoRepository.GetExchanges(currencyId);
        Currency = dto
            .ToDetailsPageModel(exchanges);
        if(Currency is null)
        {
            Currency = new DetailsPageModel();
        }
    }

    public ICommand GoToAssetsCommand => new RelayCommand(parameter =>
    {
        _mainFrame.Content = new AssetsPage(_mainFrame,_cryptoRepository);
    });
}
