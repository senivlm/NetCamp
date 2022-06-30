using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Models
{
    public class Product
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
                if (Char.IsLower(value[0]))
                {
                    name = $"{Char.ToUpper(value[0])}{value.Substring(1)}";
                }
                else
                {
                    name = value;
                }
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
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Weight");
                weight = value;
            }
        }
        public Product() : this("empty", 0.0, 0.0)
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
            return this.Name.Equals(product.Name) && this.Price == product.Price;
        }
        public override int GetHashCode()
        {
            return (Name, Price).GetHashCode();
        }
        public virtual void IncreasePrice(int percent)
        {
            Price *= (((100 + (double)percent) / 100));
        }
        public virtual string ToFileString()
        {
            return $"Product_{Name}_{Weight}_{Price}";
        }

        public virtual Product Clone()
        {
            return new Product(Name, Price, Weight);
        }
        public virtual bool Seach(string search)
        {
            if (string.IsNullOrWhiteSpace(search) || search.Length<Settings.MinSearchSymbols) return false;
            if(Name.Contains(search)) return true;
            if(double.TryParse(search, out double searchDouble))
            {
                if (Weight == searchDouble) return true;
                if (Price == searchDouble) return true;
            }
            return false;
        }
    }
}
