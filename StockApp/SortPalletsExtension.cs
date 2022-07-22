using StockApp.models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockApp
{
    public static class SortPalletsExtension
    {
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
