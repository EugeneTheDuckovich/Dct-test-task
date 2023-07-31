using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using AutoMapper;
using DctTestTask.Models.DTOs;
using DctTestTask.Models.PageModels;
using DctTestTask.Repositories.Abstract;
using DctTestTask.Utilities;
using DctTestTask.ViewModels.Abstract;
using DctTestTask.Views;
using DctTestTask.Mappers;
using DctTestTask.Models.Events;

namespace DctTestTask.ViewModels;

public class AssetsPageViewModel : PageViewModel
{
    private object _lockObject = new object();

    private string _assetName;
    private string _assetSymbol;
    private AssetPageModel[] _assets;
    private ObservableCollection<AssetPageModel> _assetsView;

    public string AssetName
    {
        get => _assetName;
        set
        {
            _assetName = value;
            SortByName();
        }
    }

    public string AssetSymbol
    {
        get => _assetSymbol;
        set
        {
            _assetSymbol = value;
            SortBySymbol();
        }
    }

    private AssetPageModel[] Assets
    {
        get => _assets;
        set
        {
            _assets = value;
            InitializeAssetsView(Assets);
        }
    }

    public ObservableCollection<AssetPageModel> AssetsView
    {
        get => _assetsView;
        set
        {
            _assetsView = value;
            OnPropertyChanged(nameof(AssetsView));
        }
    }

    public ICommand GoToDetailsCommand => new RelayCommand(parameter =>
    {
        var currencyId = parameter as string;
        ChangePage(ViewType.Details,currencyId);
    }, parameter => parameter is string);

    public ICommand GoToMenuCommand => new RelayCommand(parameter =>
    {
        ChangePage(ViewType.Menu);
    });

    public AssetsPageViewModel(ICryptoService<CoinCapCurrency> cryptoService, IMapper mapper)
        :base(cryptoService,mapper)
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

        var assets = Assets.Where(
            a => a.Name
                .ToLower()
                .StartsWith(AssetName.ToLower().Trim())
            );
        InitializeAssetsView(assets);
    }

    private void SortBySymbol()
    {
        if (string.IsNullOrWhiteSpace(AssetSymbol))
        {
            InitializeAssetsView(Assets);
            return;
        }

        var assets = Assets.Where(
            a => a.Symbol.ToLower().StartsWith(AssetSymbol.ToLower().Trim())
            );
        InitializeAssetsView(assets);
    }

    private async void InitializeAssets()
    {
        var assets = (await _cryptoService.GetAssets())
            .Select(a => a.ToAssetPageModel())
            .Where(a => a is not null)
            //.Take(10)
            .ToArray();
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
}