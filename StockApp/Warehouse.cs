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
    public class Warehouse
    {
        private const string outputPath = "pallets/output.json";
        private const string inputPath = "pallets/input.json";

        public static void WriteInFile(IEnumerable<PalletModel> palletModelsList, string fileName = outputPath)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(palletModelsList, options);
            File.WriteAllText(fileName, jsonString);
        }

        public static IEnumerable<PalletModel> ReadFromFile(string fileName = inputPath)
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
