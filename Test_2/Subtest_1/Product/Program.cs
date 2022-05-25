using System;
using System.Collections.Generic;

namespace Product
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Meat meat = new Meat("t", 4, 4, Category.firstSort, Kind.veal);
            Meat meat2 = new Meat("t", 4, 4, Category.firstSort, Kind.veal);
            Meat meat3 = new Meat("t", 5, 4, Category.firstSort, Kind.veal);
            Console.WriteLine("IS {0} \n AND {1}\n ARE EQUALS - {2}", meat, meat2, meat.Equals(meat2));
            Console.WriteLine("IS {0} \n AND {1}\n ARE EQUALS - {2}", meat, meat2, meat.Equals(meat3));
            Console.WriteLine();
            Console.WriteLine("Createing dairy products");
            try
            {
                Dairy_product dairy_Product = new Dairy_product("t", 5, 4, "02.02.2020");
                Console.WriteLine(dairy_Product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                Dairy_product dairy_Product1 = new Dairy_product("t", 5, 4, "02.02.2024");
                Console.WriteLine(dairy_Product1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
            Console.WriteLine("Creating Storage");
            Storage storage = new Storage();
            storage.InitializationProducts();
            Console.WriteLine(storage);
            storage.AddProduct();
            storage.AddMeat();
            Console.WriteLine(storage);
            Console.WriteLine("Збільшена цінв на 30%");
            storage.InsreaseAllPricess(30);
            Console.WriteLine(storage);
            List<Meat> meatProducts = storage.GetAllMeatProduct();
            Console.WriteLine("М'ясні продукти");
            foreach (Meat meatProduct in meatProducts)
            {
                Console.WriteLine(meatProduct);
            }
        }
    }
}
