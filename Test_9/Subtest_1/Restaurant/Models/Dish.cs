using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    internal class Dish
    {
        private string name;
        private Dictionary<string, int> _ingridients;
        public int this[string key]
        {
            get
            {
                return _ingridients[key];
            }
        }
        public int Length => _ingridients.Count;
        public IEnumerable<string> Keys => _ingridients.Keys;

        public string Name { 
            get => name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("Enter dish name");
                name = value;
            }
        }

        public Dish()
        {
            _ingridients = new();
        }
        public Dish(string name, Dictionary<string, int> ingridients) : this()
        {
            Name = name;
            _ingridients = ingridients;
        }
    }
}
