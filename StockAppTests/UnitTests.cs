using StockApp;
using StockApp.models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockAppTests
{
    public class Tests
    {
        List<PalletModel> palletsList;

        [SetUp]
        public void Setup()
        {
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
                            ExpirationDate = DateTime.Now,
                            Weight = 12
                        },
                        new BoxModel
                        {
                            Id = Guid.NewGuid(),
                            Height = 22,
                            Width = 3,
                            Depth = 4,
                            ExpirationDate = DateTime.Now.AddDays(5),
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
                            ExpirationDate = DateTime.Now,
                            Weight = 32
                        },
                        new BoxModel
                        {
                            Id = Guid.NewGuid(),
                            Height = 22,
                            Width = 3,
                            Depth = 4,
                            ExpirationDate = DateTime.Now.AddDays(13),
                            Weight = 13
                        }
                    }
                }
            };
        }

        [Test]
        public void Test1()
        {
            var newGuid = Guid.NewGuid();
            palletsList.FirstOrDefault().Id = newGuid;
            Warehouse.WriteInFile(palletsList);

            var palletsFromFile = Warehouse.ReadFromFile("pallets/pallets1.json");

            Warehouse.PrintPalletOnConsole(palletsFromFile);

            Assert.IsTrue(palletsFromFile.Any(x=>x.Id == newGuid), $"�� ������� ������� � id = {newGuid}");
        }

        [Test]
        public void Test2()
        {
            Warehouse.WriteInFile(palletsList);

            var palletsFromFile = Warehouse.ReadFromFile("pallets/pallets1.json");

            Warehouse.PrintPalletOnConsole(palletsFromFile);

            Assert.IsTrue(palletsFromFile.Count == 2);
        }
    }
}