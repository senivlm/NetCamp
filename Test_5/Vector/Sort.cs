using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    static internal class Sort
    {
        static void Merge(ref int[] array, int l, int q, int r)
        {
            int i = l, j = q;
            int[] temp = new int[r - l];
            int k = 0;
            while (i < q && j < r)
            {
                if (array[i] < array[j])
                {
                    temp[k] = array[i++];
                }
                else
                {
                    temp[k] = array[j++];
                }
                k++;
            }
            if (i == q)
            {
                for (int m = j; m < r; m++)
                {
                    temp[k++] = array[m];
                }
            }
            else
            {
                while (i < q)
                {
                    temp[k] = array[i];
                    i++;
                    k++;
                }
            }
            for (int n = 0; n < temp.Length; n++)
            {
                array[n + l] = temp[n];
            }
        }
        static public int[] SplitMergeSort(ref int[] array)
        {
            SplitMergeSort(ref array, 0, array.Length);
            return array;
        }
        static void SplitMergeSort(ref int[] array, int start, int end)
        {
            if (end - start <= 1) return;
            int middle = (end + start) / 2;
            SplitMergeSort(ref array, start, middle);
            SplitMergeSort(ref array, middle, end);
            Merge(ref array, start, middle, end);
        }
    }
}
