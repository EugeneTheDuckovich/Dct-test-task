using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DctTestTask.Models.DTOs;

namespace DctTestTask.Models.Responses;

public class MarketResponse
{
    [JsonPropertyName("data")]
    public CoinCapMarket[] Data { get; set; }
    
    
    [JsonPropertyName("timestamp")]
    public long Timestamp { get; set; }
}
