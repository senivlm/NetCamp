using ProductsApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Models
{
    internal class Storage
    {
        private List<Product> products;
        public Product this[int index]
        {
            get
            {
                return products[index];
            }
        }
        public Storage()
        {
            products = new List<Product>();
        }
        public Storage(List<Product> listPoducts) : base()
        {
            products = listPoducts;
        }
        public Storage(string FileName) : this()
        {
            try
            {
                List<string> productsStr = FileService.GetStringsFromFile(FileName);
                foreach (string str in productsStr)
                {
                    try
                    {
                        string[] prodStr = str.Split("_");
                        Product product = null;
                        switch (prodStr[0])
                        {
                            case "Meat":
                                product = new Meat(prodStr[1], prodStr[2], prodStr[3],
                                    prodStr[4], prodStr[5]);
                                break;
                            case "Product":
                                product = new Product(prodStr[1], prodStr[2], prodStr[3]);
                                break;
                            default: throw new ArgumentException($"Wrong format in string {str}");
                        }
                        products.Add(product);
                    }
                    catch (Exception ex)
                    {
                        LoggService.AddLogToFile(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                LoggService.AddLogToFile(ex.Message);
                throw;
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
        public static List<Product> operator +(Storage a, Storage b)
        {
            List<Product> productsA = new List<Product>();
            foreach (var t in a.products)
            {
                productsA.Add(t.Clone());
            }
            foreach (Product prod in b.products)
            {
                Product prodInList = productsA.FirstOrDefault(pr => pr.Equals(prod));
                if (prodInList == null)
                {
                    productsA.Add(prod.Clone());
                }
                else
                {
                    prodInList.Weight += prod.Weight;
                }
            }
            return productsA;
        }
        public static List<Product> operator -(Storage a, Storage b)
        {
            List<Product> productsA = new List<Product>();
            foreach (var t in a.products)
            {
                productsA.Add(t.Clone());
            }
            foreach (Product prod in b.products)
            {
                Product prodInList = productsA.FirstOrDefault(pr => pr.Equals(prod));
                if (prodInList != null)
                {
                    if (prodInList.Weight > prod.Weight)
                        prodInList.Weight -= prod.Weight;
                    else productsA.Remove(prod);
                }
            }
            return productsA;
        }
        public static List<Product> operator &(Storage a, Storage b)
        {
            List<Product> res = new List<Product>();
            foreach (Product prod in b.products)
            {
                Product prodInList = a.products.FirstOrDefault(pr => pr.Equals(prod));
                if (prodInList != null)
                {
                    Product product = prodInList.Clone();
                    product.Weight = Math.Min(prod.Weight, prodInList.Weight);
                    res.Add(product);
                }
            }
            return res;
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
                new Product("pork", 4,76),
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
        public void SaveToFile(string fileName)
        {
            string productsStr = string.Empty;
            foreach (Product product in products)
            {
                if (!String.IsNullOrEmpty(productsStr)) productsStr += $"\r\n";
                productsStr += product.ToFileString();
            }
            try
            {
                FileService.AddStringToFile(fileName, productsStr, false);
            }
            catch (Exception ex)
            {
                LoggService.AddLogToFile(ex.Message);
            }
        }
    }
}
