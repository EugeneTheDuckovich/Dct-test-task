
using AutoMapper;
using DctTestTask.Mappers;
using DctTestTask.Models.DTOs;

namespace DctTestTask.Models.PageModels;

public class AssetPageModel : IMapFrom<CoinCapCurrency>
{
    public string Id { get; set; }

    public int Rank { get; set; }

    public string Symbol { get; set; }

    public string Name { get; set; }
}
