using FluentAssertions;
using StockApp;
using StockApp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StockAppTestProject
{
    public class WarehouseTests
    {
        private List<PalletModel> palletsList;
        private DateTime dateTime;
        private string outputPath = "pallets/output.json";

        public WarehouseTests()
        {
            dateTime = DateTime.Now;
            palletsList = new List<PalletModel>
            {
                new PalletModel
                {
                    Id = Guid.NewGuid(),
                    Height = 1000,
                    Width = 3,
                    Depth = 4,
                    Boxes = new List<BoxModel>
                    {
                        new BoxModel
                        {
                            Id = Guid.NewGuid(),
                            Height = 32,
                            Width = 3,
                            Depth = 4,
                            ExpirationDate = dateTime,
                            Weight = 12
                        },
                        new BoxModel
                        {
                            Id = Guid.NewGuid(),
                            Height = 22,
                            Width = 3,
                            Depth = 4,
                            ExpirationDate = dateTime.AddDays(5),
                            Weight = 12
                        }
                    }
                },
                new PalletModel
                {
                    Id = Guid.NewGuid(),
                    Height = 321,
                    Width = 33,
                    Depth = 43,
                    Boxes = new List<BoxModel>
                    {
                        new BoxModel
                        {
                            Id = Guid.NewGuid(),
                            Height = 212,
                            Width = 3,
                            Depth = 4,
                            ExpirationDate = dateTime,
                            Weight = 32
                        },
                        new BoxModel
                        {
                            Id = Guid.NewGuid(),
                            Height = 22,
                            Width = 3,
                            Depth = 4,
                            ExpirationDate = dateTime.AddDays(13),
                            Weight = 13
                        }
                    }
                }
            };
        }

        [Fact]
        public void EditPalletsTest()
        {
            var newGuid = Guid.NewGuid();
            palletsList.FirstOrDefault().Id = newGuid;
            Warehouse.WriteInFile(palletsList, outputPath);

            var palletsFromFile = Warehouse.ReadFromFile(outputPath);

            palletsFromFile.Any(x => x.Id == newGuid).Should().BeTrue();
        }

        [Fact]
        public void PalletsCountTest()
        {
            Warehouse.WriteInFile(palletsList, outputPath);

            var palletsFromFile = Warehouse.ReadFromFile(outputPath).ToList();

            palletsFromFile.Count.Should().Be(2);
        }
    }
}