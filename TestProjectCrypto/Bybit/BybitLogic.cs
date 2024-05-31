using Bybit.Net.Clients;
using Bybit.Net.Interfaces.Clients;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectCrypto.Services;

namespace TestProjectCrypto.Bybit
{
    public class BybitLogic : ICryptoService
    {
        private readonly BybitRestClient _bybitRestClient;

        public BybitLogic()
        {
            _bybitRestClient = new BybitRestClient();
        }

        public async Task<List<string>> GetSymbol()
        {
            var result = await _bybitRestClient.SpotApiV3.ExchangeData.GetSymbolsAsync();
            if (result.Success)
            {
                return result.Data.Select(s => s.BaseAsset).ToList();
            }
            return new List<string>();
        }

        public async Task<decimal?> GetPrice(string symbol)
        {
            string tradingPair = $"{symbol}USDT";
            var result = await _bybitRestClient.SpotApiV3.ExchangeData.GetTickerAsync(tradingPair);
            if (result.Success)
            {
                return (decimal?)result.Data.LastPrice;
            }
            return null;
        }
    }
}

