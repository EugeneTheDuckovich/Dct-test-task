using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DctTestTask.Mappers;
using DctTestTask.Models.DTOs;

namespace DctTestTask.Models.PageModels;

public class ExchangeInfo : IMapFrom<CoinCapMarket>
{
    public string Id { get; set; }

    public decimal Price { get; set; }

    public override string ToString()
    {
        return $"{Id}: {Price.ToString("N")}$";
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CoinCapMarket, ExchangeInfo>()
            .ForMember(e => e.Id, opt =>
                opt.MapFrom(m => m.ExchangeId))
            .ForMember(e => e.Price, opt =>
                opt.MapFrom(m => decimal.Parse(m.PriceUsd)));
    }
}
