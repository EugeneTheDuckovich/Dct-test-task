using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_task_src.Models.DTOs;

public class CoinCapMarket
{
    public string exchangeId {get; set;}
    public int rank { get; set; }
    public string baseSymbol { get; set; }
    public string baseId { get; set; }
    public string quoteSymbol { get; set; }
    public string quoteId { get; set; }
    public decimal priceQuote { get; set; }
    public decimal priceUsd { get; set; }
    public decimal volumeUsd24Hr { get; set; }
    public decimal percentExchangeVolume { get; set; }
    public int tradesCount24Hr { get; set; }
    public decimal updated { get; set; }
}
