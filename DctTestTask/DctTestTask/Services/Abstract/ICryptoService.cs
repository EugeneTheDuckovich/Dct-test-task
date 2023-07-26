using DctTestTask.Models.PageModels;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace DctTestTask.Repositories.Abstract;

public interface ICryptoService<TCurrency>
{
    Task<TCurrency[]> GetAssets();
    
    Task<TCurrency> GetCurrencyById(string id);
    
    Task<ExchangeInfo[]> GetExchanges(string currencyId);
}
