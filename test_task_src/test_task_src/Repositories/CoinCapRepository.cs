using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using test_task_src.Models.DTOs;
using test_task_src.Repositories.Abstract;
using test_task_src.Serializers;

namespace test_task_src.Repositories;

public class CoinCapRepository : ICryptoRepository<CoinCapCurrency>
{
    private HttpClient _httpClient;

    public CoinCapRepository()
    {
        _httpClient = new HttpClient();
    }

    public async Task<CoinCapCurrency[]> GetAssetsAsync()
    {
        var responseMessage = await _httpClient.GetAsync("api.coincap.io/v2/assets");
        var responseAssets = CoinCapDeserializer.DeserializeAssets(
            await responseMessage.Content.ReadAsStringAsync());

        return responseAssets.data;
    }

    public async Task<CoinCapCurrency> GetCurrencyByIdAsync(string id)
    {
        var responseMessage = await _httpClient.GetAsync($"api.coincap.io/v2/assets/{id}");
        var responseCurrency = CoinCapDeserializer.DeserializeCurrency(
            await responseMessage.Content.ReadAsStringAsync());

        return responseCurrency.data;
    }

    public async Task<string[]> GetExchangesAsync(string currencyId)
    {
        var responseMessage = await _httpClient.GetAsync($"api.coincap.io/v2/assets/{currencyId}/markets");
        var responseCurrency = CoinCapDeserializer.DeserializeMarkets(
            await responseMessage.Content.ReadAsStringAsync());

        return responseCurrency.data.Select(m => m.exchangeId).Distinct().ToArray();
    }
}
