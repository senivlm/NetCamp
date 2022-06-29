using ProductsApp.Models;
using ProductsApp.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProductsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> list1 = new List<Product> {
               new Product("Meat",12,40),
               new Product("Appes", 2,12),
               new Meat("Pork", 45, 15,new DateTime(2023,05,12), Category.firstSort, Kind.pork),
               new Meat("Beef", 60, 15, new DateTime(2025,05,12),Category.firstSort, Kind.pork)
            };
            List<Product> list2 = new List<Product> {
               new Product("Potato",11,400),
               new Product("Carrot", 12,12),
               new Meat("Pork", 45, 15,new DateTime(2023,05,12), Category.firstSort, Kind.pork),
               new Meat("Beef", 60, 5,new DateTime(2023,05,12),Category.firstSort, Kind.pork)
            };
            Storage storage1 = new Storage(list1);
            Storage storage2 = new Storage(list2);
            Console.WriteLine("Products only in storage1");
            List<Product> minus = storage1 - storage2;
            foreach (Product product in minus)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();
            Console.WriteLine("Products from storage1 which are in storage2");
            List<Product> intersection = storage1 & storage2;
            foreach (Product product in intersection)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();
            Console.WriteLine("Sum products in both storages");
            var plus = storage1 + storage2;
            foreach (var product in plus)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();
            storage1.AddMeat(new Meat("Beef", 60, 15, new DateTime(2022, 05, 12), Category.firstSort, Kind.pork));
        }
    }
}
