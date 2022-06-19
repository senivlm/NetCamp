using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    internal static class UserService
    {
        public static bool CorrectPrice(string key, out double price)
        {
            Console.WriteLine($"We have no correct price for {key}");
            Console.WriteLine("enter corrct price in 'hrn'");
            return double.TryParse(Console.ReadLine(), out price);
        }
        public static bool SelectCurrency(Currency currency, out string currencyName, out double course)
        {
            currencyName = null;
            course = default;
            int attempts = Settings.attemptsCount;
            while(attempts > 0)
            {
                if(TryGetCorrencyName(currency, out currencyName,out course))
                {
                    return true;
                }
                else
                {
                    attempts--;
                }
            }
            return false;
        }
        private static bool TryGetCorrencyName(Currency currency, out string currencyName, out double course)
        {
            Console.WriteLine("Please select currency");
            course = 0;
            int number = 1;
            Dictionary<string, string> select = new();
            foreach (string currName in currency.GetAllNames())
            {
                Console.Write($"{number} - \"{currName}; ");
                select.Add(number.ToString(), currName);
                number++;
            }
            Console.WriteLine();
            if(select.TryGetValue(Console.ReadLine(), out currencyName))
            {
                course = currency[currencyName];
            }
            return course != 0;
        }
    }
}
