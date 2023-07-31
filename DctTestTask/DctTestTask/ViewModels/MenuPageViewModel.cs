using System.Windows.Controls;
using System.Windows.Input;
using AutoMapper;
using DctTestTask.Models.DTOs;
using DctTestTask.Models.Events;
using DctTestTask.Repositories.Abstract;
using DctTestTask.Utilities;
using DctTestTask.ViewModels.Abstract;
using DctTestTask.Views;

namespace DctTestTask.ViewModels;

public class MenuPageViewModel : PageViewModel
{
    public ICommand GoToAssetsPageCommand => new RelayCommand(p =>
    {
        ChangePage(ViewType.Assets);
    });
    
    public ICommand GoToConvertPageCommand => new RelayCommand(p =>
    {
        ChangePage(ViewType.Convert);
    });
    
    public MenuPageViewModel(ICryptoService<CoinCapCurrency> cryptoService, IMapper mapper)
        :base(cryptoService,mapper) 
    {}
}