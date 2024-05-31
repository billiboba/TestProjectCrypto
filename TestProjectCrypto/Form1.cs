using System;
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

        public Form1(ICryptoService bybitService, ICryptoService binanceService)
        {
            InitializeComponent();
            _bybitService = bybitService;
            _binanceService = binanceService;
            Load += async (sender, e) => await LoadSymbols();
            BybitListBox.SelectedIndexChanged += async (sender, e) => await BybitListBox_SelectedIndexChanged();
            BinanceListBox.SelectedIndexChanged += async (sender, e) => await BinanceListBox_SelectedIndexChanged();
            var timer = new Timer { Interval = 5000 };
            timer.Tick += async (sender, e) => await Timer_Tick();
            timer.Start();
        }

        private async Task LoadSymbols()
        {
            try
            {
                await LoadBybitSymbols();
                await LoadBinanceSymbols();
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
        }
    }
}

