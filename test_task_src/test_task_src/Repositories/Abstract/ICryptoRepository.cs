using System.Threading.Tasks;

namespace test_task_src.Repositories.Abstract;

public interface ICryptoRepository<TCUrrency>
{
    Task<TCUrrency[]> GetAssets();
    Task<TCUrrency> GetCurrencyById(string id);
    Task<string[]> GetExchanges(string currencyId);
}
