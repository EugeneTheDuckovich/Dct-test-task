using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using test_task_src.Mappers;
using test_task_src.Models.DTOs;
using test_task_src.Models.PageModels;
using test_task_src.Repositories.Abstract;
using test_task_src.Utilities;
using test_task_src.ViewModels.Abstract;
using test_task_src.Views;

namespace test_task_src.ViewModels;

public class AssetsViewModel : ViewModel
{

    private object _lockObject = new object();

    private string _assetName;
    public string AssetName 
    {
        get => _assetName;
        set
        {
            _assetName = value;
            SortByName();
        }
    }

    private string _assetSymbol;
    public string AssetSymbol
    {
        get => _assetSymbol;
        set
        {
            _assetSymbol = value;
            SortBySymbol();
        }
    }

    private AssetPageModel[] _assets;
    private AssetPageModel[] Assets
    {
        get => _assets;
        set
        {
            _assets = value;
            InitializeAssetsView(Assets);
        }
    }

    private ObservableCollection<AssetPageModel> _assetsView;
    public ObservableCollection<AssetPageModel> AssetsView 
    {
        get => _assetsView;
        set
        {
            _assetsView = value;
            OnPropertyChanged(nameof(AssetsView));
        }
    }

    public AssetsViewModel(Frame mainframe,ICryptoRepository<CoinCapCurrency> cryptoRepository)
        :base(mainframe,cryptoRepository)
    {
        _lockObject = new object();
        AssetsView = new ObservableCollection<AssetPageModel>();
        BindingOperations.EnableCollectionSynchronization(AssetsView,_lockObject);
        InitializeAssets();
    }

    private void SortByName()
    {
        if (string.IsNullOrWhiteSpace(AssetName))
        {
            InitializeAssetsView(Assets);
            return;
        }

        var assets = Assets.Where(a => a.Name.ToLower().StartsWith(AssetName.ToLower()));
        InitializeAssetsView(assets);
    }

    private void SortBySymbol()
    {
        if (string.IsNullOrWhiteSpace(AssetSymbol))
        {
            InitializeAssetsView(Assets);
            return;
        }

        var assets = Assets.Where(a => a.Symbol.ToLower().StartsWith(AssetSymbol.ToLower()));
        InitializeAssetsView(assets);
    }

    private async void InitializeAssets()
    {
        var assets = (await _cryptoRepository.GetAssets())
            .Select(a => a.ToAssetPageModel())
            .Where(a => a is not null)
            .Take(10)
            .ToArray()!;
        Assets = assets;

        AssetName = string.Empty;
        AssetSymbol = string.Empty;
    }

    private void InitializeAssetsView(IEnumerable<AssetPageModel> assetsView)
    {
        lock(_lockObject)
        {
            AssetsView.Clear();
            foreach (var asset in assetsView)
            {
                AssetsView.Add(asset);
            }
        }
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