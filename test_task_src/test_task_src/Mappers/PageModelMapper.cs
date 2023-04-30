using test_task_src.Models.DTOs;
using test_task_src.Models.PageModels;

namespace test_task_src.Mappers;

public static class PageModelMapper
{
    public static AssetPageModel? ToAssetPageModel(this CoinCapCurrency coinCapCurrency)
    {
        int rank;
        if(!int.TryParse(coinCapCurrency.rank, out rank)) return null;
        return new AssetPageModel
        {
            Id = coinCapCurrency.id,
            Name = coinCapCurrency.name,
            Symbol = coinCapCurrency.symbol,
            Rank = rank,
        };
    }

    public static DetailsPageModel? ToDetailsPageModel(this CoinCapCurrency coinCapCurrency, 
        string[] exchanges)
    {
        return new DetailsPageModel
        {
            Name = coinCapCurrency.name,
            Symbol = coinCapCurrency.symbol,
            Id = coinCapCurrency.id,
            Supply = coinCapCurrency.supply,
            PriceUsd = coinCapCurrency.priceUsd + "$",
            MarketCapUsd = coinCapCurrency.marketCapUsd + "$",
            VolumeUsd24Hr = coinCapCurrency.volumeUsd24Hr,
            ChangePercent24Hr = coinCapCurrency.changePercent24Hr,
            ExchangeInfos = exchanges
        };
    }
}