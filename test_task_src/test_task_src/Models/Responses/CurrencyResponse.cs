

using test_task_src.Models.DTOs;

namespace test_task_src.Models.Responses;

public class CurrencyResponse
{
    public CoinCapCurrency data { get; set; }
    public long timestamp { get; set; }
}
