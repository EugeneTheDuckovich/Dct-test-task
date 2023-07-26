

using System.Text.Json.Serialization;
using DctTestTask.Models.DTOs;

namespace DctTestTask.Models.Responses;

public class CurrencyResponse
{
    [JsonPropertyName("data")]
    public CoinCapCurrency Data { get; set; }
    
    [JsonPropertyName("timestamp")]
    public long Timestamp { get; set; }
}
