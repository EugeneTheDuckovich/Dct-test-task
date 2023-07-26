using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using DctTestTask.Mappers;
using DctTestTask.Models.DTOs;
using DctTestTask.Models.PageModels;
using DctTestTask.Repositories.Abstract;
using DctTestTask.Utilities;
using DctTestTask.ViewModels.Abstract;
using DctTestTask.Views;

namespace DctTestTask.ViewModels;

public class ConvertCurrencyViewModel : ViewModel
{
    private ConvertionPageModel[] _assets;
    private ConvertionPageModel? _convertFrom;
    private ConvertionPageModel? _convertTo;
    private decimal _convertFromAmount;
    private decimal _convertToAmount;

    public ConvertionPageModel[] Assets
    {
        get => _assets;
        set
        {
            _assets = value;
            OnPropertyChanged();
        }
    }
    
    public ConvertionPageModel? ConvertFrom
    {
        get => _convertFrom;
        set
        {
            _convertFrom = value;
            OnPropertyChanged();
            Convert();
        }
    }
    
    public ConvertionPageModel? ConvertTo
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
        _mainFrame.Content = new MainMenuPage(_mainFrame, _cryptoService);
    });
    
    public ConvertCurrencyViewModel(Frame mainFrame, ICryptoService<CoinCapCurrency> cryptoService) 
        : base(mainFrame, cryptoService)
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

        if(!ConvertTo.PriceUsd.Equals(0))
            ConvertToAmount = ConvertFromAmount * (ConvertFrom.PriceUsd / ConvertTo.PriceUsd);
    }
}