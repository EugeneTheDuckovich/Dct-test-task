using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DctTestTask.Models.PageModels;

public class ExchangeInfo
{
    public string Id { get; set; }

    public decimal Price { get; set; }

    public override string ToString()
    {
        return $"{Id}: {Price.ToString("N")}$";
    }
}
