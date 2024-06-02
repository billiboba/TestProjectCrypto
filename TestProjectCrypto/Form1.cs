using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProjectCrypto.Bybit;
using TestProjectCrypto.Services;

namespace TestProjectCrypto
{
    public partial class Form1 : Form
    {
        private readonly ICryptoService _bybitService;
        private readonly ICryptoService _binanceService;
        private readonly ICryptoService _bitgetService;
        private readonly ICryptoService _kucoinService;
        public Form1(ICryptoService bybitService, ICryptoService binanceService, ICryptoService bitgetService, ICryptoService kucoinService)
        {
            InitializeComponent();
            _bybitService = bybitService;
            _binanceService = binanceService;
            _bitgetService = bitgetService;
            _kucoinService = kucoinService;
            Load += async (sender, e) => await LoadSymbols();
            BybitListBox.SelectedIndexChanged += async (sender, e) => await BybitListBox_SelectedIndexChanged();
            BinanceListBox.SelectedIndexChanged += async (sender, e) => await BinanceListBox_SelectedIndexChanged();
            BitgetListBox.SelectedIndexChanged += async (sender, e) => await BitgetListBox_SelectedIndexChanged();
            KucoinListBox.SelectedIndexChanged += async (sender, e) => await KucoinListBox_SelectedIndexChanged();
            var timer = new Timer { Interval = 5000 };
            timer.Tick += async (sender, e) => await Timer_Tick();
            timer.Tick += async (sender, e) => await Timer_TickSearch();
            timer.Start();
            button1.Click += async (sender, e) => await SearchButton_Click();
        }
        private async Task Timer_TickSearch()
        {
            string searchQuery = textBox1.Text.Trim().ToUpper();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                string resultMessage = await SearchCrypto(searchQuery);
                label4.Text = resultMessage;
            }
        }
        private async Task LoadSymbols()
        {
            try
            {
                await LoadBybitSymbols();
                await LoadBinanceSymbols();
                await LoadKucoinSymbols();
                await LoadBitgetSymbols();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private async Task LoadBybitSymbols()
        {
            var cryptoNamesBybit = await _bybitService.GetSymbol();
            BybitListBox.Items.Clear();
            BybitListBox.Items.AddRange(cryptoNamesBybit.ToArray());
        }
        private async Task LoadBinanceSymbols()
        {
            var cryptoNamesBinance = await _binanceService.GetSymbol();
            BinanceListBox.Items.Clear();
            BinanceListBox.Items.AddRange(cryptoNamesBinance.ToArray());
        }
        private async Task LoadKucoinSymbols()
        {
            var cryptoNamesBitget = await _kucoinService.GetSymbol();
            KucoinListBox.Items.Clear();
            KucoinListBox.Items.AddRange(cryptoNamesBitget.ToArray());
        }
        private async Task LoadBitgetSymbols()
        {
            var cryptoNamesBitget = await _bitgetService.GetSymbol();
            BitgetListBox.Items.Clear();
            BitgetListBox.Items.AddRange(cryptoNamesBitget.ToArray());
        }
        

        private async Task BybitListBox_SelectedIndexChanged()
        {
            if (BybitListBox.SelectedItem != null)
            {
                var selectedCrypto = BybitListBox.SelectedItem.ToString();
                var price = await _bybitService.GetPrice(selectedCrypto);
                test.Text = price.HasValue ? $"Bybit Current {selectedCrypto} Price: {price} USDT" : "Failed to retrieve data";
            }
        }
        private async Task BinanceListBox_SelectedIndexChanged()
        {
            if (BinanceListBox.SelectedItem != null)
            {
                var selectedCrypto = BinanceListBox.SelectedItem.ToString();
                var price = await _binanceService.GetPrice(selectedCrypto);
                label1.Text = price.HasValue ? $"Binance Current {selectedCrypto} Price: {price} USDT" : "Failed to retrieve data";
            }
        }
        private async Task KucoinListBox_SelectedIndexChanged()
        {
            if (KucoinListBox.SelectedItem != null)
            {
                var selectedCrypto = KucoinListBox.SelectedItem.ToString();
                var price = await _kucoinService.GetPrice(selectedCrypto);
                label2.Text = price.HasValue ? $"Kucoin Current {selectedCrypto} Price: {price} USDT" : "Failed to retrieve data";
            }
        }
        private async Task BitgetListBox_SelectedIndexChanged()
        {
            if (BitgetListBox.SelectedItem != null)
            {
                var selectedCrypto = BitgetListBox.SelectedItem.ToString();
                var price = await _bitgetService.GetPrice(selectedCrypto);
                label3.Text = price.HasValue ? $"Bitget Current {selectedCrypto} Price: {price} USDT" : "Failed to retrieve data";
            }
        }
        private async Task Timer_Tick()
        {
            if (BybitListBox.SelectedItem != null)
            {
                await BybitListBox_SelectedIndexChanged();
            }
            if (BinanceListBox.SelectedItem != null)
            {
                await BinanceListBox_SelectedIndexChanged();
            }
            if (KucoinListBox.SelectedItem != null)
            {
                await KucoinListBox_SelectedIndexChanged();
            }
            if (BitgetListBox.SelectedItem != null)
            {
                await BitgetListBox_SelectedIndexChanged();
            }
        }

        private async Task SearchButton_Click()
        {
            string searchQuery = textBox1.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(searchQuery))
            {
                MessageBox.Show("Введите текст для поиска.", "Поиск");
                return;
            }

            string resultMessage = await SearchCrypto(searchQuery);
            label4.Text = resultMessage;
        }

        private async Task<string> SearchCrypto(string searchQuery)
        {
            string resultMessage = "";
            bool found = false;

            var searchQueries = new List<string> { searchQuery };

            if (searchQuery.Length > 4 && searchQuery.EndsWith("USDT", StringComparison.OrdinalIgnoreCase))
            {
                var baseCurrency = searchQuery.Substring(0, searchQuery.Length - 4);
                searchQueries.Add(baseCurrency);
            }

            foreach (var query in searchQueries)
            {
                var bybitPrice = await _bybitService.GetPrice(query);
                if (bybitPrice.HasValue)
                {
                    resultMessage += $"Bybit Current {query} Price: {bybitPrice} USDT\n";
                    found = true;
                }

                var binancePrice = await _binanceService.GetPrice(query);
                if (binancePrice.HasValue)
                {
                    resultMessage += $"Binance Current {query} Price: {binancePrice} USDT\n";
                    found = true;
                }

                var kucoinPrice = await _kucoinService.GetPrice(query);
                if (kucoinPrice.HasValue)
                {
                    resultMessage += $"Kucoin Current {query} Price: {kucoinPrice} USDT\n";
                    found = true;
                }

                var bitgetPrice = await _bitgetService.GetPrice(query);
                if (bitgetPrice.HasValue)
                {
                    resultMessage += $"Bitget Current {query} Price: {bitgetPrice} USDT\n";
                    found = true;
                }
            }

            if (!found)
            {
                resultMessage = "Криптовалюта не найдена.";
            }

            return resultMessage;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

