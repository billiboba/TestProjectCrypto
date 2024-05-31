using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestProjectCrypto
{
    public interface ICryptoService
    {
        Task<List<string>> GetSymbolAsync();
        Task<decimal?> GetPriceAsync(string symbol);
    }
}