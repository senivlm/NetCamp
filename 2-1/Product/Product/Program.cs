using System;
using System.Collections.Generic;

namespace Product
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();
            storage.InitializationProducts();
            storage.PrintAllProducts();
            storage.AddProduct();
            storage.AddMeat();
            storage.PrintAllProducts();
            Console.WriteLine("Збільшена цінв на 30%");
            storage.InsreaseAllPricess(30);
            storage.PrintAllProducts();
            List<Meat> meatProducts = storage.GetAllMeatProduct();
            Console.WriteLine("М'ясні продукти");
            foreach (Meat meat in meatProducts)
            {
                Console.WriteLine(meat);
            }
        }
    }
}
