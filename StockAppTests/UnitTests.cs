using NUnit.Framework;
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
                    id = Guid.NewGuid(),
                    height = 1000,
                    width = 3,
                    depth = 4,
                    boxs = new List<BoxModel>
                    {
                        new BoxModel
                        {
                            id = Guid.NewGuid(),
                            height = 32,
                            width = 3,
                            depth = 4,
                            expirationDate = DateTime.Now,
                            weight = 12
                        },
                        new BoxModel
                        {
                            id = Guid.NewGuid(),
                            height = 22,
                            width = 3,
                            depth = 4,
                            expirationDate = DateTime.Now.AddDays(5),
                            weight = 12
                        }
                    }
                },
                new PalletModel
                {
                    id = Guid.NewGuid(),
                    height = 321,
                    width = 33,
                    depth = 43,
                    boxs = new List<BoxModel>
                    {
                        new BoxModel
                        {
                            id = Guid.NewGuid(),
                            height = 212,
                            width = 3,
                            depth = 4,
                            expirationDate = DateTime.Now,
                            weight = 32
                        },
                        new BoxModel
                        {
                            id = Guid.NewGuid(),
                            height = 22,
                            width = 3,
                            depth = 4,
                            expirationDate = DateTime.Now.AddDays(13),
                            weight = 13
                        }
                    }
                }
            };
        }

        [Test]
        public void Test1()
        {
            var newGuid = Guid.NewGuid();
            palletsList.FirstOrDefault().id = newGuid;
            PalletsHelper.WriteInFile(palletsList);

            var palletsFromFile = PalletsHelper.ReadFromFile("pallets/pallets1.json");

            PalletsHelper.PrintPalletOnConsole(palletsFromFile);

            Assert.IsTrue(palletsFromFile.Any(x=>x.id == newGuid), $"Не найдена паллета с id = {newGuid}");
        }

        [Test]
        public void Test2()
        {
            PalletsHelper.WriteInFile(palletsList);

            var palletsFromFile = PalletsHelper.ReadFromFile("pallets/pallets1.json");

            PalletsHelper.PrintPalletOnConsole(palletsFromFile);

            Assert.IsTrue(palletsFromFile.Count == 2);
        }
    }
}