using System;
using System.Diagnostics;

namespace Vector
{
    internal class Program
    {
        static  void Main(string[] args)
        {
            Vector arr = new Vector(2000);
            arr.InitRandom(-10, 25);
            Console.WriteLine("Unsorted array");
            Console.WriteLine(arr);
            arr.QuickSort();
            Console.WriteLine("Sorted array");
            Console.WriteLine(arr);
        }
    }
}
