using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DctTestTask.Models.DTOs;
using DctTestTask.Models.PageModels;
using DctTestTask.Models.Responses;
using DctTestTask.Repositories.Abstract;
using DctTestTask.Serializers;

namespace DctTestTask.Repositories;

public class CoinCapService : ICryptoService<CoinCapCurrency>
{
    private string ApiUrl
    {
        get => ConfigurationManager.AppSettings.Get("ApiUrl")?? string.Empty;
    }

    private HttpClient _httpClient;

    public CoinCapService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<CoinCapCurrency[]> GetAssets()
    {
        var requestUrl = $"{ApiUrl}/assets";
        var responseMessage = await _httpClient.GetAsync(requestUrl);
        var responseAssets = CoinCapDeserializer.DeserializeAssets(
           await responseMessage.Content.ReadAsStringAsync());

        return responseAssets.Data;
    }

    public async Task<CoinCapCurrency> GetCurrencyById(string id)
    {
        var responseMessage = await _httpClient.GetAsync($"{ApiUrl}/assets/{id}");
        var responseCurrency = CoinCapDeserializer.DeserializeCurrency(
            await responseMessage.Content.ReadAsStringAsync());

        return responseCurrency.Data;
    }

    public async Task<ExchangeInfo[]> GetExchanges(string currencyId)
    {
        HttpResponseMessage responseMessage = 
            await _httpClient.GetAsync($"{ApiUrl}/assets/{currencyId}/markets");
        MarketResponse responseMarkets = CoinCapDeserializer.DeserializeMarkets(
            await responseMessage.Content.ReadAsStringAsync());

        return responseMarkets.Data
            .DistinctBy(m => m.ExchangeId)
            .Select(m => new ExchangeInfo { 
                Id = m.ExchangeId, 
                Price = decimal.Parse(m.PriceUsd.Replace('.',',')),
            })
            .ToArray();
    }
}
