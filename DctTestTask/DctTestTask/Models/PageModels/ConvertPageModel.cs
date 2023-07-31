using AutoMapper;
using DctTestTask.Mappers;
using DctTestTask.Models.DTOs;

namespace DctTestTask.Models.PageModels;

public class ConvertPageModel : IMapFrom<CoinCapCurrency>
{
    public string Name { get; set; }
    
    public decimal PriceUsd { get; set; }

    public override string ToString()
    {
        return Name;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CoinCapCurrency, ConvertPageModel>()
            .ForMember(cpm => cpm.PriceUsd, 
                opt => 
                    opt.MapFrom(c => decimal.Parse(c.PriceUsd)));
    }
}