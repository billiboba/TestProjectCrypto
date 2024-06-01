using Binance.Net.Clients;
using Kucoin.Net.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectCrypto.Services;

namespace TestProjectCrypto.Kucoin
{
    public class KucoinLogic : ICryptoService
    {
        private readonly KucoinRestClient _kucoinRestClient;

        public KucoinLogic()
        {
            _kucoinRestClient = new KucoinRestClient();
        }
        public async Task<List<string>> GetSymbol()
        {
            var result = await _kucoinRestClient.SpotApi.ExchangeData.GetSymbolsAsync();
            if (result.Success)
            {
                return result.Data
                             .Where(s => s.QuoteAsset == "USDT")
                     .Select(s => s.BaseAsset)
                     .Distinct()
                     .ToList();
            }
            return new List<string>();
        }
        public async Task<decimal?> GetPrice(string symbol)
        {
            var result = await _kucoinRestClient.SpotApi.ExchangeData.GetTickerAsync($"{symbol}-USDT");
            if (result.Success)
            {
                return result.Data.LastPrice;
            }
            return null;
        }

    }
}
