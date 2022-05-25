using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    internal enum Start { right, down };
    internal class Matrix
    {
        int[,] array;
        public Matrix(int n = 5, int m = 5)
        {
            array = new int[n, m];
        }
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    string suffix = array[i, j] < 10 ? " " : "";
                    result += $"{array[i, j]} {suffix}";
                }
                result += $"\n";
            }
            return result;
        }
        public override bool Equals(object obj)
        {
            int cellCount = array.GetLength(0);
            int rowCount = array.GetLength(1);
            Matrix matrix = obj as Matrix;
            if (matrix == null) return false;
            if(matrix.array.GetLength(0) != cellCount) return false;
            if (matrix.array.GetLength(1) != rowCount) return false;
            for(int i=0; i<cellCount; i++)
            {
                for(int j=0; j<rowCount; j++)
                {
                    if (array[i, j] != matrix.array[i, j]) return false;    
                }
            }
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public void DiagonalSnake(Start start)
        {
            int increment = start == Start.right ? 1 : -1;
            int iMax = array.GetLength(0) - 1, jMax = array.GetLength(1) - 1;
            int i = 0, j = 0;
            for (int index = 1; index < array.Length + 1; index++)
            {
                array[i, j] = index;
                if (i == iMax && increment == -1)
                {
                    j++;
                    increment = 1;
                }
                else if (j == jMax && increment == 1)
                {
                    i++;
                    increment = -1;
                }
                else if (j == 0 && increment == -1)
                {
                    i++;
                    increment = 1;
                }
                else if (i == 0 && increment == 1)
                {
                    j++;
                    increment = -1;
                }
                else
                {
                    i -= increment;
                    j += increment;
                }
            }
        }
    }
}
