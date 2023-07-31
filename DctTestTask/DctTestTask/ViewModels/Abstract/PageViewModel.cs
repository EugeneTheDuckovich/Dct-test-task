using System;
using System.Windows.Controls;
using AutoMapper;
using DctTestTask.Models.DTOs;
using DctTestTask.Models.Events;
using DctTestTask.Repositories.Abstract;
using DctTestTask.Utilities;
using DctTestTask.Models.PageModels;

namespace DctTestTask.ViewModels.Abstract;

public class PageViewModel : NotifyPropertyChanged
{
    protected readonly ICryptoService<CoinCapCurrency> _cryptoService;
    protected readonly IMapper _mapper;
    protected EventHandler<ViewChangedEventArgs> _viewChanged;
    public event EventHandler<ViewChangedEventArgs> ViewChanged
    {
        add => _viewChanged += value;
        remove => _viewChanged -= value;
    }

    public PageViewModel(ICryptoService<CoinCapCurrency> cryptoService, IMapper mapper)
    {
        _cryptoService = cryptoService;
        _mapper = mapper;
    }

    protected void ChangePage(ViewType nextPage, object? data)
    {
        var eventArgs = new ViewChangedEventArgs
        {
            NextPage = nextPage,
            Data = data
        };
        
        _viewChanged.Invoke(this,eventArgs);
    }

    protected void ChangePage(ViewType nextPage)
    {
        ChangePage(nextPage,null);
    }
}

public enum ViewType
{
    Menu,
    Assets,
    Details,
    Convert,
}
