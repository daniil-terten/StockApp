using StockApp.models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockApp
{
    public static class SortPalletsExtension
    {
        //static void Main(string[] args)
        //{
        //    var s = Warehouse.ReadFromFile();
        //    s.FirstOrDefault().Height = 100000;
        //    var sortedPallets = s.OrderByDescending(x => x.ExpirationDate).Take(3);
        //    Warehouse.PrintPalletOnConsole(sortedPallets);
        //    Warehouse.WriteInFile(s);
        //}

        public static List<IGrouping<DateTime?, PalletModel>> GroupPalletsByExpirationDate(this List<PalletModel> palletModels)
        {
            return palletModels.GroupBy(x => x.ExpirationDate).ToList();
        }

        public static List<PalletModel> SortPalletsByExpirationDate(this List<PalletModel> palletModels)
        {
            return palletModels.OrderBy(x => x.ExpirationDate).ToList();
        }
    }
}
