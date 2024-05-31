using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binance.Net;
using Binance.Net.Clients;
using Bybit.Net.Clients;
using Bybit.Net.Interfaces.Clients;
using TestProjectCrypto.Services;
namespace TestProjectCrypto.Binance
{
    public class BinanceLogic : ICryptoService
    {
        private readonly BinanceRestClient _binanceRestClient;

        public BinanceLogic()
        {
            _binanceRestClient = new BinanceRestClient();
        }
        public async Task<List<string>> GetSymbol()
        {
            var result = await _binanceRestClient.SpotApi.ExchangeData.GetTickersAsync();
            if (result.Success)
            {
                return result.Data.Select(s => s.Symbol).Where(symbol => symbol.EndsWith("USDT",StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return new List<string>();
        }
        public async Task<decimal?> GetPrice(string symbol)
        {
            var result = await _binanceRestClient.SpotApi.ExchangeData.GetPriceAsync(symbol);
            if (result.Success)
            {
                
                return Math.Round(result.Data.Price, 2);
            }
            return null;
        }

    }
}
