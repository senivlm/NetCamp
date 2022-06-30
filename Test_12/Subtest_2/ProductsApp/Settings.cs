using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp
{
    internal class Settings
    {
        public static Dictionary<Category, int> AdditionalSortsPersons
        {
            get
            {
                return new Dictionary<Category, int>
                {
                    { Category.hiestSort, 15 },
                    { Category.firstSort, 10 },
                    { Category.secondSort, 5 },
                };
            }
        }
        public const string ErrorLogFile = "error.log";
        public const string ProductsToRemoveFile = "ProductsToRemove.txt";
        public const int MinSearchSymbols = 2;
    }
}
