using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    internal class Product
    {
        private string name;
        private double weight;
        private double price;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Name");
                name = value;
            }
        }
        public double Price
        {
            get => price;
            private set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Price");
                price = value;
            }
        }
        public double Weight
        {
            get => weight;
            private set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Weight");
                weight = value;
            }
        }
        public Product() : this("enmpty", 0.0, 0.0)
        { }
        public Product(string name, double price, double weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }
        public Product(string name, string priceStr, string weightStr)
        {
            Name = name;
            if (double.TryParse(priceStr, out double price))
            {
                Price = price;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Введiть коректрну цiну");
            }
            if (double.TryParse(weightStr, out double weight))
            {
                Weight = weight;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Введiть коректрну вагу");
            }
        }
        public override string ToString()
        {
            return String.Format("Назва товару - {0}, цiна - {1:F2}, вага - {2}", Name, Price, Weight);
        }
        public override bool Equals(object obj)
        {
            Product product = obj as Product;
            if (product == null) return false;
            return this.Name.Equals(product.Name) && this.Price == product.Price && this.Weight == product.Weight;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public virtual void IncreasePrice(int percent)
        {
            Price *= (((100 + (double)percent) / 100));
        }

    }
}
