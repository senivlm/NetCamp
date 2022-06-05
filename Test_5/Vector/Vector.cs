using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    internal class Vector
    {
        int[] array;
        public Vector(int n)
        {
            array = new int[n];
        }
        public Vector(int[] data)
        {
            array = new int[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                array[i] = data[i];
            }
        }
        public int this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i] + " ";
            }
            return result;
        }
        public override bool Equals(object obj)
        {
            int count = array.Length;
            Vector vector = obj as Vector;
            if (vector == null) return false;
            if (vector.array.GetLength(0) != count) return false;
            for (int i = 0; i < count; i++)
            {
                if (array[i] != vector.array[i]) return false;
            }
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public void InitRandom(int a, int b)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(a, b + 1);
            }
        }
        public void InitPoliandr(int a, int b)
        {
            int middle = array.Length / 2 + array.Length % 2;
            Random random = new Random();
            for (int i = 0; i < middle; i++)
            {
                int val = random.Next(a, b + 1);
                array[i] = val;
                array[array.Length - 1 - i] = val;
            }
        }
        public void InitShufle()
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                int val = 0;
                do
                {
                    val = random.Next(1, array.Length + 1);
                } while (!array.Contains(val));
                array[i] = val;
            }
        }
        public Pair[] CalculateFreq()
        {
            Pair[] pairs = new Pair[array.Length];
            for (int i = 0; i < pairs.Length; i++)
            {
                pairs[i] = new Pair(0, 0);
            }
            int countDifference = 0;
            for (int i = 0; i < array.Length; i++)
            {
                bool isElement = false;
                for (int j = 0; j < countDifference; j++)
                {
                    if (array[i] == pairs[j].Number)
                    {
                        pairs[j].Freq++;
                        isElement = true;
                        break;
                    }
                }
                if (!isElement)
                {
                    pairs[countDifference].Freq++;
                    pairs[countDifference].Number = array[i];
                    countDifference++;
                }
            }
            Pair[] result = new Pair[countDifference];
            for (int i = 0; i < countDifference; i++)
            {
                result[i] = new Pair(pairs[i].Number, pairs[i].Freq);
            }
            return result;
        }
        public bool IsPoliand()
        {
            int lenght = array.Length;
            int middle = array.Length / 2 + 1;
            for (int i = 0; i < middle; i++)
            {
                if (!(array[i] == array[lenght - 1 - i])) return false;
            }
            return true;
        }
        public void ReverseMassive()
        {
            int lenght = array.Length;
            int halfLenght = lenght / 2;
            for (int i = 0; i < halfLenght; i++)
            {
                Swap(i, lenght - 1 - i);
            }
        }
        public Pair BiggestPair()
        {
            Pair[] pairs = CalculateFreq();
            Pair result = new Pair(0, 0);
            for (int i = 0; i < pairs.Length; i++)
            {
                if (pairs[i].Freq > result.Freq)
                {
                    result = pairs[i];
                }
            }
            return result;
        }
        public void Bubble()
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int item = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = item;
                    }
                }
            }
        }
        public void Counting()
        {
            int max = array[0];
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            int[] temp = new int[max - min + 1];
            for (int i = 0; i < array.Length; i++)
            {
                temp[array[i] - min]++;
            }
            int k = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                for (int j = 0; j < temp[i]; j++)
                {
                    array[k++] = i + min;
                }
            }
        }
        public void QuickSort()
        {
            QuickSort(0, array.Length - 1);
        }
        void QuickSort(int start, int end)
        {
            if (end - start < 1) return;
            int min = start, max = end;
            for (int i = start + 1; i <= end; i++)
            {
                if (array[min] > array[i]) min = i;
                if (array[max] < array[i - 1]) max = i-1;
            }
            if (end - start >= 1)
            {
                if (array[min] == array[max]) return;
                int middle = (array[min] + array[max]) / 2;
                int l = start, r = end;
                while (l < r)
                {
                    while (array[l] <= middle && l < r) l++;
                    while (array[r] > middle && r > l) r--;
                    if (l < r) Swap(l++, r--);
                }
                QuickSort(start , l-1);
                QuickSort(l, end);
            }
        }
        void Swap(int n, int m)
        {
            if (n != m)
            {
                int tmp = array[n];
                array[n] = array[m];
                array[m] = tmp;
            }
        }
        void Merge(int l, int q, int r)
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
                this.array[n + l] = temp[n];
            }
        }
        public void SplitMergeSort()
        {
            SplitMergeSort(0, array.Length);
        }
        public void SplitMergeSort(int start, int end)
        {
            if (end - start <= 1) return;
            int middle = (end + start) / 2;
            SplitMergeSort(start, middle);
            SplitMergeSort(middle, end);
            Merge(start, middle, end);
        }
        void comparissionPyramidElem(int elem, int lenght)
        {
            int l = elem * 2 + 1, r = elem * 2 + 2;
            int max = elem;
            if (l < lenght && array[l] > array[max]) max = l;
            if (r < lenght && array[r] > array[max]) max = r;
            if (max != elem)
            {
                Swap(max, elem);
                comparissionPyramidElem(max, lenght);
            }
        }
        public void PyramidalSort()
        {
            int lenght = array.Length;
            for (int i = lenght / 2 - 1; i >= 0; i--)
            {
                comparissionPyramidElem(i, lenght);
            }
            for (int i = lenght - 1; i >= 0; i--)
            {
                Swap(i, 0);
                comparissionPyramidElem(0, i);
            }
        }
    }
}
