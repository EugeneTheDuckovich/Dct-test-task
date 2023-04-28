using System.Threading.Tasks;

namespace test_task_src.Repositories.Abstract;

public interface ICryptoRepository<TCUrrency>
{
    Task<TCUrrency[]> GetAssetsAsync();
    Task<TCUrrency> GetCurrencyByIdAsync(string id);
    Task<string[]> GetExchangesAsync(string currencyId);
}
