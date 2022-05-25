using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class CreateArray
    {
        public int[,] VerticalSnake(int height, int width)
        {
            int[,] result = new int[height, width];
            int indexer = 1;
            int decrement = 1;
            int j = 0;
            for (int i = 0; i < width; i++)
            {
                if (decrement > 0) { j = 0; }
                else { j = height - 1; }
                do
                {
                    result[j, i] = indexer++;
                    j += decrement;
                } while (j >= 0 && j < height);
                decrement = -decrement;
            }
            return result;
        }
        public int[,] DiagonalSnake(int height, int width)
        {
            int[,] result = new int[height, width];
            int decrement = -1;
            int lenght = height * width;
            int i = 0;
            int j = 0;
            for (int indexer = 1; indexer <= lenght; indexer++)
            {
                result[i, j] = indexer;
                if (i == height - 1 && decrement == 1)
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
                else if (j == width - 1 && decrement == -1)
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
            return result;
        }
        public int[,] SpiralSnake(int height, int width)
        {
            int[,] result = new int[height, width];
            int minHeight = 0, maxHeight = height - 1;
            int minWidth = 1, maxWidth = width - 1;
            int lenght = height * width;
            int i = -1, j = 0;
            int indexer = 0;
            do
            {
                while (i < maxHeight)
                {
                    result[++i, j] = ++indexer;
                }
                maxHeight--;
                while(j<maxWidth)
                {
                    result[i, ++j] = ++indexer;
                }
                maxWidth--;
                while (i > minHeight && j > minWidth)
                {
                    result[--i, j] = ++indexer;
                }
                minHeight++;
                while (j >minWidth)
                {
                    result[i, --j] = ++indexer;
                }
                minWidth++;

            } while (indexer < lenght);
         return result;
        }
    }
}
