using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    internal class Pair
    {
        public int Number { get; set; }
        public int Freq { get; set; }
        public Pair(int number, int freq)
        {
            Number = number;
            Freq = freq;
        }
        public override string ToString()
        {
            return $"{Number} - {Freq}";
        }
        public override bool Equals(object obj)
        {
            Pair pair = obj as Pair;
            if (pair == null) return false;
            return pair.Number == Number && pair.Freq == Freq; 
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
