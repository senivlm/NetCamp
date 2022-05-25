using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    static internal class Print
    {
        public static string ArrayToString(int[,] array)
        {
            int height = array.GetLength(0);
            int width = array.GetLength(1);
            string res = String.Format("Printing array {0}x{1} \n", height, width);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    res += String.Format("{0} {1}",array[i, j], array[i, j] < 10 ? " " : "");
                }
                res +="\n";
            }
            return res;
        }
    }
}
