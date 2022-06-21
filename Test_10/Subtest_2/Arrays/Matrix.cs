using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class Matrix : IEnumerable
    {
        private int[,] matrix;
        private int row;
        private int col;
        public Matrix(int[,] array)
        {
            matrix = array;
            row = array.GetLength(0);
            col = array.GetLength(1);
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    yield return matrix[i, i % 2 == 0 ? j : col - j - 1];
                }
            }
        }
    }
}
