using Restaurant.Models;
using Restaurant.Services;
using System;
using System.Collections.Generic;

namespace Restaurant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = null;
            PriceKurant priceKurant = null;
            try
            {
                menu = new Menu(Settings.menuFileName);
                priceKurant = new PriceKurant(Settings.pricesFileName);
                
                if(MenuService.TryGetMenuTotalSum(menu, priceKurant, out double sum, out Dictionary<string, int> ingridients))
                {
                    MenuService.SaveResult(Settings.resultFileName, sum, ingridients);
                }
                else
                {
                    throw new Exception("Menu calculating error");
                }
                Console.WriteLine("Menu successfully calculated and writed to file.");
            }
            catch (Exception ex)
            {// Користувачу слід було вказати продукти, які не мали цінника
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
