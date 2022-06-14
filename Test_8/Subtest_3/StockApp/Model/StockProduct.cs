using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Model
{
    internal class StockProduct
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public override int GetHashCode() => (Name, Weight, Price).GetHashCode();
        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }
    }
}
