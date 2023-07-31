using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using AutoMapper;
using DctTestTask.Mappers;
using DctTestTask.Models.DTOs;
using DctTestTask.Models.Events;
using DctTestTask.Models.PageModels;
using DctTestTask.Repositories.Abstract;
using DctTestTask.Utilities;
using DctTestTask.ViewModels.Abstract;
using DctTestTask.Views;

namespace DctTestTask.ViewModels;

public class ConvertPageViewModel : PageViewModel
{
    private ConvertPageModel[] _assets;
    private ConvertPageModel? _convertFrom;
    private ConvertPageModel? _convertTo;
    private decimal _convertFromAmount;
    private decimal _convertToAmount;

    public ConvertPageModel[] Assets
    {
        get => _assets;
        set
        {
            _assets = value;
            OnPropertyChanged();
        }
    }
    
    public ConvertPageModel? ConvertFrom
    {
        get => _convertFrom;
        set
        {
            _convertFrom = value;
            OnPropertyChanged();
            Convert();
        }
    }
    
    public ConvertPageModel? ConvertTo
    {
        get => _convertTo;
        set
        {
            _convertTo = value;
            OnPropertyChanged();
            Convert();
        }
    }

    public decimal ConvertFromAmount
    {
        get => _convertFromAmount;
        set
        {
            _convertFromAmount = value;
            OnPropertyChanged();
            Convert();
        }
    }

    public decimal ConvertToAmount
    {
        get => _convertToAmount;
        set
        {
            _convertToAmount = value;
            OnPropertyChanged();
        }
    }

    public ICommand GoToMenuCommand => new RelayCommand(parameter =>
    {
        ChangePage(ViewType.Menu);
    });
    
    public ConvertPageViewModel(ICryptoService<CoinCapCurrency> cryptoService, IMapper mapper)
        :base(cryptoService,mapper)
    {
        InitializeAssets();
    }

    private async void InitializeAssets()
    {
        Assets = (await _cryptoService.GetAssets())
            .Select(a => a.ToConvertPageModel())
            .ToArray();
    }

    private void Convert()
    {
        if (ConvertFrom is null)
            return;
        
        if (ConvertTo is null)
            return;

        if (ConvertTo.PriceUsd.Equals(0))
            return;
        
        ConvertToAmount = ConvertFromAmount * (ConvertFrom.PriceUsd / ConvertTo.PriceUsd);
    }
}