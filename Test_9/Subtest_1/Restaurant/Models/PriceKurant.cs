using Restaurant.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Restaurant.Services.PriceService;

namespace Restaurant.Models
{
    internal class PriceKurant
    {
        private event AddPriceToFile SaveToFile;
        private Dictionary<string, double> _productPrice;
        public PriceKurant()
        {
            _productPrice = new();
            SaveToFile += PriceService.SavePriceToFile;
        }
        public PriceKurant(Dictionary<string, double> productPrice) : this()
        {
            _productPrice = productPrice;
        }
        public PriceKurant(string fileName) : this()
        {
            _productPrice = PriceService.Load(fileName);
        }
        public bool TryGetProductPrice(string productName, out double price)
        {
            return _productPrice.TryGetValue(productName, out price);
        }
        public bool TryAddProductPrice(string productName, double price)
        {
            bool res= _productPrice.TryAdd(productName, price);
            if (res)
            {
                SaveToFile(productName, price, Settings.pricesFileName);
            }
            return res;
        }
    }
}
