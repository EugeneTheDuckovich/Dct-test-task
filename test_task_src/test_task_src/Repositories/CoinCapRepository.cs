using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using test_task_src.Models.DTOs;
using test_task_src.Repositories.Abstract;
using test_task_src.Serializers;

namespace test_task_src.Repositories;

public class CoinCapRepository : ICryptoRepository<CoinCapCurrency>
{
    private const string ApiURL = "https://api.coincap.io/v2";

    private HttpClient _httpClient;

    public CoinCapRepository()
    {
        _httpClient = new HttpClient();
    }

    public async Task<CoinCapCurrency[]> GetAssets()
    {
        var requestUrl = $"{ApiURL}/assets";
        var responseMessage = await _httpClient.GetAsync(requestUrl);
        var responseAssets = CoinCapDeserializer.DeserializeAssets(
           await responseMessage.Content.ReadAsStringAsync());

        return responseAssets.data;
    }

    public async Task<CoinCapCurrency> GetCurrencyById(string id)
    {
        var responseMessage = await _httpClient.GetAsync($"{ApiURL}/assets/{id}");
        var responseCurrency = CoinCapDeserializer.DeserializeCurrency(
            await responseMessage.Content.ReadAsStringAsync());

        return responseCurrency.data;
    }

    public async Task<string[]> GetExchanges(string currencyId)
    {
        var responseMessage = await _httpClient.GetAsync($"{ApiURL}/assets/{currencyId}/markets");
        var responseMarkets = CoinCapDeserializer.DeserializeMarkets(
            await responseMessage.Content.ReadAsStringAsync());

        return responseMarkets.data
            .DistinctBy(m => m.exchangeId)
            .Select(m => $"{m.exchangeId}: {m.priceUsd}$")
            .ToArray();
    }
}
