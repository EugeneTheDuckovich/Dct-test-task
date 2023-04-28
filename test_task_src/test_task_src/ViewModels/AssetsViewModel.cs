using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using test_task_src.Models.DTOs;
using test_task_src.Repositories.Abstract;
using test_task_src.Utilities;
using test_task_src.ViewModels.Abstract;
using test_task_src.Views;

namespace test_task_src.ViewModels;

public class AssetsViewModel : ViewModel
{
    private ObservableCollection<CoinCapCurrency> _assets;
    public ObservableCollection<CoinCapCurrency> Assets 
    {
        get => _assets;
        set
        {
            _assets = value;
            OnPropertyChanged(nameof(Assets));
        }
    }

    public AssetsViewModel(Frame mainframe,ICryptoRepository<CoinCapCurrency> cryptoRepository)
        :base(mainframe,cryptoRepository)
    {
        _assets = new ObservableCollection<CoinCapCurrency>(_cryptoRepository.GetAssetsAsync().Result);
    }

    public ICommand GoToDetailsCommand => new RelayCommand(parameter =>
    {
        var currencyId = parameter as string;
        if(currencyId is null)
        {
            return;
        }

        _mainFrame.Content = new CurrencyDetailsPage(_mainFrame, _cryptoRepository, currencyId);
    }, parameter => parameter is string);
}
