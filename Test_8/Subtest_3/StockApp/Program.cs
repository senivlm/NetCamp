using System;
using System.Collections.Generic;
using StockApp.Model;

namespace StockApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            StockProduct product = new StockProduct { Name = "Banan", Price = 3, Weight = 2, Count = 4 };
            StockProduct product1 = new StockProduct { Name = "Boob", Price = 2, Weight = 1, Count = 3 };
            StockProduct product2 = new StockProduct { Name = "Meat", Price = 10.2, Weight = 121, Count = 5 };
            StockProduct product3 = new StockProduct { Name = "Fish", Price = 10.2, Weight = 121, Count = 4 };
            StockProduct product4 = new StockProduct { Name = "Meat", Price = 10.2, Weight = 121, Count = 4 };
            StockProduct product5 = new StockProduct { Name = "Meat", Price = 1, Weight = 1, Count = 4 };
            Stock stock1 = new Stock();
            stock1.AddProduct(product);
            stock1.AddProduct(product1);
            stock1.AddProduct(product2);
            stock1.AddProduct(product3);
            stock1.AddProduct(product4);
            Stock stock2 = new Stock();
            stock2.AddProduct(product);
            stock2.AddProduct(product5);
            stock2.AddProduct(product2);

            List<StockProduct> plus = stock1 + stock2;
            //List<StockProduct> minus = stock1 - stock2;
            //List<StockProduct> joint = stock1.Joint(stock2);
        }
    }
}
