using System;
using System.Collections.Generic;
using AutoMapper;
using DctTestTask.Models.DTOs;
using DctTestTask.Models.Events;
using DctTestTask.Repositories.Abstract;
using DctTestTask.Utilities;
using DctTestTask.ViewModels.Abstract;

namespace DctTestTask.ViewModels;

public class MainWindowViewModel: NotifyPropertyChanged
{
    private readonly ICryptoService<CoinCapCurrency> _cryptoService;
    private readonly IMapper _mapper;
    private PageViewModel _currentPageViewModel;

    public PageViewModel CurrentPageViewModel
    {
        get => _currentPageViewModel;
        private set
        {
            _currentPageViewModel = value;
            OnPropertyChanged();
        }
    }

    public MainWindowViewModel(ICryptoService<CoinCapCurrency> cryptoService)
    {
        _cryptoService = cryptoService;
        ChangeView(this, new ViewChangedEventArgs
        {
            NextPage = ViewType.Menu
        });
    }

    private void ChangeView(object? sender, ViewChangedEventArgs eventArgs)
    {
        switch (eventArgs.NextPage)
        {
            case ViewType.Menu:
                CurrentPageViewModel = new MenuPageViewModel(_cryptoService,_mapper);
                break;
            case ViewType.Assets:
                CurrentPageViewModel = new AssetsPageViewModel(_cryptoService,_mapper);
                break;
            case ViewType.Details:
                string currencyId = eventArgs.Data as string ?? 
                                    throw new ArgumentException("currency id must be string");
                CurrentPageViewModel = new DetailsPageViewModel(_cryptoService,_mapper,currencyId);
                break;
            case ViewType.Convert:
                CurrentPageViewModel = new ConvertPageViewModel(_cryptoService,_mapper);
                break;
            default:
                throw new ArgumentException("invalid page type!");
        }

        CurrentPageViewModel.ViewChanged += ChangeView;
    }
}