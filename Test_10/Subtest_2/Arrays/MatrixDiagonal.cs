using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class MatrixDiagonal:IEnumerable
    {
        private int[,] matrix;
        private int row;
        private int col;
        public MatrixDiagonal(int[,] array)
        {
            matrix = array;
            row = array.GetLength(0);
            col = array.GetLength(1);
        }

        public IEnumerator GetEnumerator()
        {
            int decrement = -1;  //Цей елемент встановлює яким буде другий елемент (вправо чи вниз).
            int lenght = row * col;
            int i = 0;
            int j = 0;
            for (int indexer = 1; indexer <= lenght; indexer++)
            {
                yield return matrix[i, j];
                // можна відділити логіку заповнення
                if (i == row - 1 && decrement == 1)
                {
                    j++;
                    decrement = -1;
                }
                else if (i == 0 && decrement == -1)
                {
                    j++;
                    decrement = 1;
                }
                else if (j == 0 && decrement == 1)
                {
                    i++;
                    decrement = -1;
                }
                else if (j == col - 1 && decrement == -1)
                {
                    i++; ;
                    decrement = 1;
                }

                else
                {
                    i += decrement;
                    j -= decrement;
                }
            }
        }
    }
}
