using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Services
{
    static internal class CreateProductFromConsole
    {
        public static Product CreateProduct()
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
        public static Meat CreateMeat()
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
                    if (!(Double.TryParse(priceStr, out double price) && Double.TryParse(weightStr, out double weight))) throw new ArgumentException();
                    meat = new Meat(name, price, weight, categoryStr, kindStr);
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
    }
}
