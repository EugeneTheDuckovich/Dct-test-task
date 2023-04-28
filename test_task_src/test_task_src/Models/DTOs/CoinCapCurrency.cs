using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_task_src.Models.DTOs;

public class CoinCapCurrency
{
    public string id { get; set; }
    public int rank { get; set; }
    public string symbol { get; set; }
    public string name { get; set; }
    public decimal supply { get; set; }
    public decimal maxSupply { get; set; }
    public decimal marketCapUsd { get; set; }
    public decimal volumeUsd24Hr { get; set; }
    public decimal priceUsd { get; set; }
    public decimal changePercent24Hr { get; set; }
    public decimal vwap24Hr { get; set; }
}
