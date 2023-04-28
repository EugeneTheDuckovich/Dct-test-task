using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using test_task_src.Models.DTOs;
using test_task_src.Repositories.Abstract;
using test_task_src.Utilities;

namespace test_task_src.ViewModels.Abstract;

public class ViewModel : NotifyPropertyChanged
{
    protected readonly Frame _mainFrame;
    protected readonly ICryptoRepository<CoinCapCurrency> _cryptoRepository;

    public ViewModel(Frame mainframe, ICryptoRepository<CoinCapCurrency> cryptoRepository)
    {
        _cryptoRepository = cryptoRepository;
        _mainFrame = mainframe;
    }
}
