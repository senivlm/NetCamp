using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    internal class Storage
    {
        private Product[] products;
        public Product[] Products { get => products; private set => products = value; }
        public Storage()
        {
            Products = new Product[20];
        }
        public Storage(int lenght)
        {
            Products = new Product[lenght];
        }
        public Storage(Product[] products)
        {
            Products = products;
        }
        public Product this[int index]
        {
            get
            {
                return products[index];
            }
            set
            {
                products[index] = value;
            }
        }
        Product CreateProduct()
        {
            bool seccessful = true;
            Product product = null;
            Console.WriteLine("Створення продукту");
            do
            {
                Console.WriteLine("Введіть назву");
                string name = Console.ReadLine();
                Console.WriteLine("Введіть вагу");
                string weightStr = Console.ReadLine();
                Console.WriteLine("Введіть цiну");
                string priceStr = Console.ReadLine();
                try
                {
                    product = new Product(name, priceStr, weightStr);
                    seccessful = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Продукт не створено. Повторіть ввод.");
                    seccessful = false;
                }
            } while (!seccessful);
            return product;
        }
        Meat CreateMeat()
        {
            Meat meat = null;
            bool seccessful = true;
            Console.WriteLine("Створення м'ясного продукту");
            do
            {
                Console.WriteLine("Введіть назву");
                string name = Console.ReadLine();
                Console.WriteLine("Введіть вагу");
                string weightStr = Console.ReadLine();
                Console.WriteLine("Введіть цiну");
                string priceStr = Console.ReadLine();
                Console.WriteLine("Введіть категорію");
                string categoryStr = Console.ReadLine();
                Console.WriteLine("Введіть вид");
                string kindStr = Console.ReadLine();
                try
                {
                    meat = new Meat(name, priceStr, weightStr, categoryStr, kindStr);
                    seccessful = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("М'ясо не створено. Повторіть ввод.");
                    seccessful = false;
                }
            } while (!seccessful);
            return meat;
        }
        void AddProductToList(Product product)
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] == null)
                {
                    products[i] = product;
                    break;
                }
            }
        }
        public void AddProduct() => AddProductToList(CreateProduct());
        public void AddMeat() => AddProductToList(CreateMeat());
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
        public void PrintAllProducts()
        {
            Console.WriteLine("Повний список продуктів:");
            foreach (Product product in Products)
            {
                if(product!=null)
                Console.WriteLine(product);
            }
        }
        public List<Meat> GetAllMeatProduct()
        {
            List<Meat> meats = new List<Meat>();
            foreach (Product product in Products)
            {
                if (product is Meat) meats.Add(product as Meat);
            }
            return meats;
        }
        public void InsreaseAllPricess(int percent)
        {
            foreach (Product product in Products)
            {
                if (product != null)
                    product.IncreasePrice(percent);
            }
        }
    }
}
