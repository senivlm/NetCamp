using Restaurant.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    internal class Currency
    {
        private Dictionary<string, double> courses;

        public Dictionary<string, double> Courses { get => courses; private set => courses = value; }
        public Currency()
        {
            courses = new();
        }
        public Currency(string fileName)
        {
            courses = PriceService.Load(fileName);
        }
        public double this[string key]
        {
            get
            {
                try
                {
                    return courses[key];
                }
                catch
                {
                    return 0;
                }
            }
        }
        public List<string> GetAllNames()
        {
            return courses.Keys.ToList();
        }
    }
}
