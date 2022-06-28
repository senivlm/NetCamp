using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    internal static class MenuService
    {
        static public bool TryGetMenuTotalSum(Menu menu, PriceKurant priceKurant,
            out double menuTotalSum, out Dictionary<string, int> ingridients)
        {
            menuTotalSum = default;
            ingridients = new();
            for (int i = 0; i < menu.Length; i++)
            {
                // розкажіть свою ідею на занятті. Так, як Ви, ніхто не робив.
                if (!TryGetDishPrice(menu[i], ref priceKurant, ref ingridients,
                    out double sumPrice))
                {
                    menuTotalSum = default;
                    ingridients = new();
                    return false;
                }
                menuTotalSum += sumPrice;
            }
            return true;
        }
        static private bool TryGetDishPrice(Dish dish, ref PriceKurant priceKurant,
           ref Dictionary<string, int> ingridients, out double sumPrice)
        {
            sumPrice = default;
            foreach (string key in dish.Keys)
            {
                if (!priceKurant.TryGetProductPrice(key, out double poductPrice))
                {
                    if (!TryCorrectPrice(key, out poductPrice)) throw new ArgumentNullException($"We have no price for {key}");
                }
                AddIngridients(key, dish[key], ref ingridients);
                sumPrice += poductPrice * dish[key] / 1000;
            }
            return true;
        }
        static private void AddIngridients(string key, int weight, ref Dictionary<string, int> ingridients)
        {
            if (ingridients.ContainsKey(key))
            {
                ingridients[key] += weight;
            }
            else
            {
                ingridients.Add(key, weight);
            }
        }
        static private bool TryCorrectPrice(string key, out double poductPrice)
        {
            int attempts = Settings.attemptsCount;
            bool res;
            while (!(res = UserService.CorrectPrice(key, out poductPrice)) && attempts-- > 1) { }
            return res;
        }
        public static void SaveResult(string fileName, double summ, Dictionary<string, int> ingridients)
        {
            Currency currency = new Currency(Settings.currencyFileName);
            List<string> toFile = new();
            if(!UserService.SelectCurrency(currency, out string currencyName, out double course))
            {
                throw new ArgumentNullException("wrong currency");
            }
            toFile.Add("    Products list:");
            foreach(var ing in ingridients)
            {
                toFile.Add($" * {ing.Key} - {ing.Value} gramm");
            }
            toFile.Add($"Totall summ {(summ * course):0.##} {currencyName}");
            FileService.SaveStrings(fileName, toFile);
        }
    }
}
