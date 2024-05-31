using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProjectCrypto.Binance;
using TestProjectCrypto.Bybit;
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
            Application.Run(new Form1(bybit,binance)); 

        }
    }
}
