using System;

namespace Product
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product = null;
            Buy buy = null;
            Console.WriteLine("Створення продукту!");
            do
            {
                Console.WriteLine("Введiть назву продукту!");
                string name = Console.ReadLine();
                Console.WriteLine("Введiть цуні продукту (грн)!");
                string priceStr = Console.ReadLine();
                Console.WriteLine("Введiть вагу продукту (кг)!");
                string weightStr = Console.ReadLine();
                try
                {
                    product = new Product(name, priceStr, weightStr);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (product == null) Console.WriteLine(" Введіть продукт повторно");
            }
            while (product == null);
            Check.Print(product);
            Console.WriteLine("Створення покупки!");
            do
            {
                Console.WriteLine("Введiть кількість продуктiв!");
                string countStr = Console.ReadLine();
                if (int.TryParse(countStr, out int count))
                {
                    try
                    {
                        buy = new Buy(product, count);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                if (buy == null) Console.WriteLine(" Введіть кiлькiсть продуктiв повторно");
            } while (buy == null);
            Check.Print(buy);
            Console.ReadLine();
        }
    }
}
