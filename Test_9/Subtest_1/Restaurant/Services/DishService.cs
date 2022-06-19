using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    internal static class DishService
    {
        public static List<Dish> LoadDishes(string fileName)
        {
            List<Dish> dishes = new List<Dish>();
            string[] strings = FileService.LoadStrings(fileName);
            for(int i = 0; i < strings.Length; i++)
            {
                string dishName=strings[i++];
                Dictionary<string, int> ingridients = new();
                while(i < strings.Length && !string.IsNullOrWhiteSpace(strings[i]))
                {
                    if(!TryParseIngridient(strings[i], out string nameIng, out int weightIng))
                        throw new Exception("wrong format in menu file");
                    ingridients.Add(nameIng, weightIng);
                    i++;
                }
                dishes.Add(new Dish(dishName, ingridients));
            }
            return dishes;
        }
        private static bool TryParseIngridient(string data, out string nameIng, out int weightIng)
        {
            nameIng = string.Empty;
            weightIng = 0;
            if (string.IsNullOrWhiteSpace(data)) return false;
            int position = data.IndexOf(',');
            if (position <= 0) return false;
            nameIng = data.Substring(0, position).Trim();
            Regex regex = new Regex(@"\d{1,5}");
            Match match = regex.Match(data.Substring(position + 1));
            return int.TryParse(match.Value, out weightIng);
        }
    }
}
