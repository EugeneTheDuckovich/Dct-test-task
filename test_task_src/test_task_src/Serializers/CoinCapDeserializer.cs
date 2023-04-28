using System;
using System.Text.Json;
using test_task_src.Models.Responses;

namespace test_task_src.Serializers;

public static class CoinCapDeserializer
{
    public static AssetsResponse DeserializeAssets(string response)
    {
        var result = JsonSerializer.Deserialize<AssetsResponse>(response);
        if(result is null)
        {
            throw new Exception("invalid currency json string!");
        }
        return result;
    }

    public static CurrencyResponse DeserializeCurrency(string response)
    {
        var result = JsonSerializer.Deserialize<CurrencyResponse>(response);
        if (result is null)
        {
            throw new Exception("invalid assets json string!");
        }
        return result;
    }

    public static MarketResponse DeserializeMarkets(string response)
    {
        var result = JsonSerializer.Deserialize<MarketResponse>(response);
        if (result is null)
        {
            throw new Exception("invalid markets json string!");
        }
        return result;
    }
}
