using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc
{
    internal class Settings
    {
        public static Dictionary<string, int> OperationPriority = new()
        {
            { "(", 0 },
            { "+", 1 },
            { "-", 1 },
            { "*", 2 },
            { "/", 2 },
            { "^", 3 },
            { "√", 3 },
            { "sin", 4 },
            { "cos", 4 },
        };
        public const int NewOperationPriority = 4;
    }
}
