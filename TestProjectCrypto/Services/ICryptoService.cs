using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectCrypto.Services
{
    public interface ICryptoService
    {
        Task<List<string>> GetSymbol();
        Task<decimal?> GetPrice(string symbol);
    }
}
