using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Models
{
    internal class Buy
    {
        private Product product;
        private int count;

        public Product Product
        {
            get => product;
            private set
            {
                if (value == null) throw new ArgumentNullException();
                product = value;
            }
        }
        public int Count
        {
            get => count;
            private set
            {
                if (value < 0) throw new ArgumentOutOfRangeException();
                count = value;
            }
        }
        public double Summ
        {
            get
            { return product.Price * count; }
        }
        public double FullWeight
        {
            get
            { return product.Weight * count; }
        }
        public Buy() : this(new Product(), 0)
        { }
        public Buy(Product product, int count)
        {
            Product = product;
            Count = count;
        }
        public override string ToString()
        {
            return $"Назва товару - {Product.Name}, кiлькiсть - {Count}, сума - {Summ:F2}, загальна вага - {FullWeight}";
        }
        public override bool Equals(object obj)
        {
            Buy buy = obj as Buy;
            if (buy == null) return false;
            return Product.Equals(buy.Product) && Count == buy.Count;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
