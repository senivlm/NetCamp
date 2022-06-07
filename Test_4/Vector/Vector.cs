﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{// не бачу реалізації для різних опорних елементів
    internal class Vector
    {
        int[] array;
        public Vector(int n)
        {
            array = new int[n];
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
            int temp = 0;
            for (int i = 0; i < halfLenght; i++)
            {
                temp = array[i];
                array[i] = array[lenght - i];
                array[lenght - 1] = temp;
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
                    if (array[j] < array[j + 1])
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
                if (array[max] < array[i - 1]) max = i;
            }
            Swap(start, min);
            Swap(end, max);
            if (end - start > 2)
            {
                int middle = (array[end] - array[start]) / 2 + array[start];
                int l = start + 1, r = end - 1;
                while (l < r)
                {// умови треба поміняти місцями
                    while (array[l] <= middle && l < r) l++;
                    while (array[r] >= middle && r > l) r--;
                    if (l < r) Swap(l++, r--);
                }
                QuickSort(start + 1, l - 1);
                QuickSort(l, end - 1);
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
    }
}
