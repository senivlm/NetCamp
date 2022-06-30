using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Models
{
    static internal class Check
    {
        static public void Print(Buy buy)
        {
            Console.WriteLine(buy);
        }
        static public void Print(Product product)
        {
            Console.WriteLine(product);
        }
    }
}
