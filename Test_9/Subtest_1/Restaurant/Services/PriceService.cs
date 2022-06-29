using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    internal static class PriceService
    {
        public delegate void AddPriceToFile(string name, double price, string fileName);
        public static Dictionary<string, double> Load(string fileName)
        {
            Dictionary<string, double> priceKurants = new Dictionary<string, double>();
            string[] strings = FileService.LoadStrings(fileName);
            foreach (string s in strings)
            {
                if (string.IsNullOrWhiteSpace(s)) continue;
                if (!TryParsePrice(s, out string name, out double price))
                    throw new Exception("wrong format in price file");
                priceKurants.Add(name, price);
            }
            return priceKurants;
        }
        private static bool TryParsePrice(string data, out string name, out double price)
        {
            name = String.Empty;
            price = default;
            if (string.IsNullOrWhiteSpace(data)) return false;
            int position = data.IndexOf('-');
            if (position <= 0) return false;
            name = data.Substring(0, position).Trim();
            Regex regex = new Regex(@"\d+\.\d+|\d+\,\d+|\d+");
            string priceStr = regex.Match(data.Substring(position + 1)).Value.Replace(',', '.');
            return double.TryParse(priceStr, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out price);
        }
        public static void SavePriceToFile(string name, double price, string fileName)
        {
            List<string> str = new() { $"{name} - {price}" };
            FileService.SaveStrings(fileName, str, true);
        }
    }
}
