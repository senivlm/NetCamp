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
            storage.InsreaseAllPricess(30);
            storage.PrintAllProducts();
            List<Meat> meatProducts = storage.GetAllMeatProduct();
            foreach (Meat meat in meatProducts)
            {
                Console.WriteLine(meat);
            }
        }
    }
}
