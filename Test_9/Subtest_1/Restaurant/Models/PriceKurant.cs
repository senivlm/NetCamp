using Restaurant.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    internal class PriceKurant
    {
        private Dictionary<string, double> _productPrice;
        public PriceKurant()
        {
            _productPrice = new();
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
    }
}
