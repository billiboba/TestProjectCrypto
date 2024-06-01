using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProjectCrypto.Binance;
using TestProjectCrypto.Bitget;
using TestProjectCrypto.Bybit;
using TestProjectCrypto.Kucoin;
using TestProjectCrypto.Services;

namespace TestProjectCrypto
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ICryptoService bybit = new BybitLogic();
            ICryptoService binance = new BinanceLogic();
            ICryptoService bitget = new BitgetLogic();
            ICryptoService kucoin = new KucoinLogic();
            Application.Run(new Form1(bybit,binance,bitget,kucoin)); 

        }
    }
}
