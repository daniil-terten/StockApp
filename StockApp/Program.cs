using StockApp.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace StockApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var s = PalletsHelper.ReadFromFile();
            s.FirstOrDefault().height = 100000;
            var sortedPallets = s.OrderByDescending(x => x.expirationDate).Take(3);
            PalletsHelper.PrintPalletOnConsole(sortedPallets);
            PalletsHelper.WriteInFile(s);
        }
    }
}
