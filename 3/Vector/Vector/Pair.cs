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
    }
}
