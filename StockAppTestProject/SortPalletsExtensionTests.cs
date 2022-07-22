using FluentAssertions;
using StockApp;
using StockApp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StockAppTestProject
{
    public class SortPalletsExtensionTests
    {
        List<PalletModel> palletsList;

        public SortPalletsExtensionTests()
        {
            palletsList = Warehouse.ReadFromFile("TestData.json").ToList();
        }

        [Fact]
        public void SortPalletsTest()
        {
            var expectedDate = palletsList.Min(a => a.ExpirationDate);
            palletsList.SortPalletsByExpirationDate().First().ExpirationDate.Should().Be(expectedDate);
        }
    }
}
