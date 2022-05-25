using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    internal class Storage
    {
        private List<Product> products;
        public Storage()
        {
            products = new List<Product>();
        }
        public Product this[int index]
        {
            get
            {
                return products[index];
            }
        }
        public override string ToString()
        {
            string res = $"Повний список продуктів:\n";
            foreach (Product product in products)
            {
                res += product + "\n";
            }
            return res;
        }
        public override bool Equals(object obj)
        {
            Storage storage = obj as Storage;
            if (storage == null) return false;
            if (products.Count != storage.products.Count) return false;
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i] != storage.products[i]) return false;
            }
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        void AddProductToList(Product product)
        {
            if (product == null) throw new ArgumentNullException();
            products.Add(product);
        }
        public void AddProduct() => AddProductToList(CreateProductFromConsole.CreateProduct());
        public void AddMeat() => AddProductToList(CreateProductFromConsole.CreateMeat());
        public void InitializationProducts()
        {
            List<Product> products = new List<Product>()
            {
                new Product("Fish",34.5,5),
                new Product("Pork", 4,76),
                new Meat("Pork", 45, 1,"firstSort","veal"),
                new Meat("kaban", 230.45, 0.9,"firstSort","pork")
            };
            foreach (Product product in products)
            {
                AddProductToList(product);
            }
        }
        public List<Meat> GetAllMeatProduct()
        {
            List<Meat> meats = new List<Meat>();
            foreach (Product product in products)
            {
                if (product is Meat) meats.Add(product as Meat);
            }
            return meats;
        }
        public void InsreaseAllPricess(int percent)
        {
            foreach (Product product in products)
            {
                if (product != null)
                    product.IncreasePrice(percent);
            }
        }
    }
}
