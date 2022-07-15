using StockApp.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StockApp
{
    public class PalletsHelper
    {
        public static void WriteInFile(ICollection<PalletModel> palletModelsList, string fileName = "pallets/pallets1.json")
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(palletModelsList, options);
            File.WriteAllText(fileName, jsonString);
        }

        public static ICollection<PalletModel> ReadFromFile(string fileName = "pallets/pallets.json")
        {
            var str = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<PalletModel>>(str);
        }

        public static void PrintPalletOnConsole(IEnumerable<PalletModel> palletModelsList)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(palletModelsList, options);
            Console.WriteLine(jsonString);
        }
    }
}
