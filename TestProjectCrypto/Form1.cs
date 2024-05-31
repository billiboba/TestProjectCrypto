using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bybit.Net.Clients;
using Timer = System.Windows.Forms.Timer;

namespace TestProjectCrypto
{
    public partial class Form1 : Form
    {

        private BybitSocketClient _socketClient;
        private BybitRestClient _bybitClient;
        private Timer _timer;
        public Form1()
        {
            InitializeComponent();
            Load += new EventHandler(Form1_Load);
            _bybitClient = new BybitRestClient();
            _timer = new Timer();
            _timer.Interval = 5000;
            _timer.Tick += new EventHandler(Timer_Tick);
            _timer.Start();
            BybitListBox.SelectedIndexChanged += new EventHandler(ListBoxCryptos_SelectedIndexChanged);
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            string selectedCrypto = BybitListBox.SelectedItem.ToString();
            await GetPrice(selectedCrypto);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await GetSymbol();
        }

        protected async Task GetSymbol()
        {
            try
            {
                var result = await _bybitClient.SpotApiV3.ExchangeData.GetSymbolsAsync();
                if (result.Success)
                {
                    BybitListBox.Items.Clear();
                    List<string> cryptoNames = new List<string>();
                    foreach (var symbol in result.Data)
                    {
                        cryptoNames.Add(symbol.BaseAsset);
                    }
                    cryptoNames = cryptoNames.Distinct().ToList();
                    BybitListBox.Items.AddRange(cryptoNames.ToArray());
                }
                else
                {
                    MessageBox.Show("Failed to retrieve data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }


        private void ListBoxCryptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BybitListBox.SelectedItem != null)
            {
                string selectedCrypto = BybitListBox.SelectedItem.ToString();
                GetPrice(selectedCrypto);
            }
        }

        protected async Task GetPrice(string symbol)
        {
            try
            {
                string tradingPair = $"{symbol}USDT";
                var result = await _bybitClient.SpotApiV3.ExchangeData.GetTickerAsync(tradingPair);

                if (result.Success)
                {
                    var price = result.Data.LastPrice;
                    test.Text = $"Current {symbol} Price: {price} USDT";
                }
                else
                {
                    MessageBox.Show("Failed to retrieve data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
