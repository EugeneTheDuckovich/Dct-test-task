using System.Windows.Controls;
using DctTestTask.Models.DTOs;
using DctTestTask.Repositories.Abstract;
using DctTestTask.Utilities;
using DctTestTask.Models.PageModels;

namespace DctTestTask.ViewModels.Abstract;

public class ViewModel : NotifyPropertyChanged
{
    protected readonly Frame _mainFrame;
    protected readonly ICryptoService<CoinCapCurrency> _cryptoService;

    public ViewModel(Frame mainframe, ICryptoService<CoinCapCurrency> cryptoService)
    {
        _cryptoService = cryptoService;
        _mainFrame = mainframe;
    }
}
