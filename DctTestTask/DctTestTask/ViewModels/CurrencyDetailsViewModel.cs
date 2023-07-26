using System.Windows.Controls;
using System.Windows.Input;
using DctTestTask.Models.DTOs;
using DctTestTask.Models.PageModels;
using DctTestTask.Repositories.Abstract;
using DctTestTask.Utilities;
using DctTestTask.ViewModels.Abstract;
using DctTestTask.Views;
using DctTestTask.Mappers;

namespace DctTestTask.ViewModels;

public class CurrencyDetailsViewModel : ViewModel
{
    private DetailsPageModel _currency;

    public CurrencyDetailsViewModel(Frame mainframe, ICryptoService<CoinCapCurrency> cryptoService,
        string currencyId) 
        : base(mainframe, cryptoService)
    {
        InitializeCurrency(currencyId);
    }

    public DetailsPageModel Currency
    {
        get => _currency;
        private set
        {
            _currency = value;
            OnPropertyChanged(nameof(Currency));
        }
    }

    public ICommand GoToAssetsCommand => new RelayCommand(parameter =>
    {
        _mainFrame.Content = new AssetsPage(_mainFrame, _cryptoService);
    });

    private async void InitializeCurrency(string currencyId)
    {
        CoinCapCurrency dto = await _cryptoService.GetCurrencyById(currencyId);
        ExchangeInfo[] exchanges = await _cryptoService.GetExchanges(currencyId);
        Currency = dto.ToDetailsPageModel(exchanges);
        if(Currency is null)
        {
            Currency = new DetailsPageModel();
        }
    }
}
