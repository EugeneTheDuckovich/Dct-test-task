using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_task_src.Models.DTOs;

namespace test_task_src.Models.Responses;

public class MarketResponse
{
    public CoinCapMarket[] data {  get; set; }
    public long timestamp { get; set; }
}
