using DctTestTask.Models.DTOs;
using DctTestTask.Models.PageModels;

namespace DctTestTask.Mappers;

public static class PageModelMapper
{
    public static AssetPageModel ToAssetPageModel(this CoinCapCurrency coinCapCurrency)
    {
        return new AssetPageModel
        {
            Id = coinCapCurrency.Id,
            Name = coinCapCurrency.Name,
            Symbol = coinCapCurrency.Symbol,
            Rank = int.Parse(coinCapCurrency.Rank),
        };
    }

    public static DetailsPageModel ToDetailsPageModel(this CoinCapCurrency coinCapCurrency, 
        ExchangeInfo[] exchanges)
    {
        return new DetailsPageModel
        {
            Name = coinCapCurrency.Name,
            Symbol = coinCapCurrency.Symbol,
            Id = coinCapCurrency.Id,
            Supply = coinCapCurrency.Supply,
            PriceUsd = decimal.Parse(coinCapCurrency.PriceUsd.Replace('.',',')).ToString("N") + "$",
            MarketCapUsd = decimal.Parse(coinCapCurrency.MarketCapUsd.Replace('.', ',')).ToString("N") + "$",
            VolumeUsd24Hr = coinCapCurrency.VolumeUsd24Hr,
            ChangePercent24Hr = coinCapCurrency.ChangePercent24Hr + "%",
            ExchangeInfos = exchanges
        };
    }

    public static ConvertionPageModel ToConvertPageModel(this CoinCapCurrency coinCapCurrency)
    {
        return new ConvertionPageModel
        {
            Name = coinCapCurrency.Name,
            PriceUsd = decimal.Parse(coinCapCurrency.PriceUsd.Replace('.',',')),
        };
    }
}