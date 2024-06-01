using Bitget.Net.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectCrypto.Services;

namespace TestProjectCrypto.Bitget
{
    public class BitgetLogic : ICryptoService
    {
        public readonly BitgetRestClient _bitgetRestClient;
        public BitgetLogic()
        {
            _bitgetRestClient = new BitgetRestClient();
        }
        public async Task<List<string>> GetSymbol()
        {
            var result = await _bitgetRestClient.SpotApi.ExchangeData.GetSymbolsAsync();
            if (result.Success)
            {
                return result.Data
                             .Select(s => s.Name)
                             .Where(symbol => symbol.EndsWith("USDT", StringComparison.OrdinalIgnoreCase))
                             .Distinct()
                             .ToList();
            }
            return new List<string>();
        }
        public async Task<decimal?> GetPrice(string symbol)
        {
            string tradingPair = $"{symbol}_SPBL";
            var result = await _bitgetRestClient.SpotApi.ExchangeData.GetTickerAsync(tradingPair);
            if (result.Success)
            {
                return result.Data.ClosePrice;
            }
            else
            {
                return null;
            }
        }

        
    }
}
