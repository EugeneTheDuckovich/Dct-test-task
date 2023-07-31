using System.Windows.Input;
using AutoMapper;
using DctTestTask.Models.DTOs;
using DctTestTask.Models.PageModels;
using DctTestTask.Repositories.Abstract;
using DctTestTask.Utilities;
using DctTestTask.ViewModels.Abstract;
using DctTestTask.Mappers;

namespace DctTestTask.ViewModels;

public class DetailsPageViewModel : PageViewModel
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

    public ICommand GoToAssetsCommand => new RelayCommand(parameter =>
    {
        ChangePage(ViewType.Assets);
    });

    public DetailsPageViewModel(ICryptoService<CoinCapCurrency> cryptoService, IMapper mapper, string currencyId)
        :base(cryptoService,mapper)
    {
        InitializeCurrency(currencyId);
    }

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
