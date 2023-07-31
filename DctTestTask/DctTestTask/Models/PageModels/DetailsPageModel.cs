
using System.Globalization;
using AutoMapper;
using DctTestTask.Mappers;
using DctTestTask.Models.DTOs;

namespace DctTestTask.Models.PageModels;

public class DetailsPageModel : IMapFrom<CoinCapCurrency>
{
    public string Id { get; set; }

    public string Symbol { get; set; }

    public string Name { get; set; }

    public string Supply { get; set; }

    public string MarketCapUsd { get; set; }

    public string VolumeUsd24Hr { get; set; }

    public string PriceUsd { get; set; }

    public string ChangePercent24Hr { get; set; }

    public ExchangeInfo[] ExchangeInfos { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CoinCapCurrency, DetailsPageModel>()
            .ForMember(d => d.PriceUsd, 
                opt => 
                    opt.MapFrom(c => 
                        decimal.Parse(c.PriceUsd, CultureInfo.InvariantCulture).ToString("N") + "$"))
            .ForMember(d => d.MarketCapUsd, 
                opt => 
                opt.MapFrom(c => decimal.Parse(c.MarketCapUsd, CultureInfo.InvariantCulture)
                    .ToString("N") + "$"))
            .ForMember(d => d.ChangePercent24Hr, 
                opt => 
                    opt.MapFrom(c => c.ChangePercent24Hr + "$"));
    }
}
