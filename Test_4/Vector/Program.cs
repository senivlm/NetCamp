using System;
using System.Diagnostics;

namespace Vector
{
    internal class Program
    {
        static  void Main(string[] args)
        {
            int n = 2000;                      //Bubble against QuickSort
            Vector arr = new Vector(n);
            Vector arr2 = new Vector(n);
            arr.InitRandom(-10, 25);
            for (int i = 0; i < n; i++)
            {
                arr2[i] = arr[i];
            }
            Console.WriteLine("Unsorted array");
            Console.WriteLine(arr);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            arr.QuickSort();
            stopwatch.Stop();
            TimeSpan qs = stopwatch.Elapsed;
            Console.WriteLine("Sorted array");
            Console.WriteLine(arr);
            stopwatch.Restart();
            arr2.Bubble();
            stopwatch.Stop();
            TimeSpan bu = stopwatch.Elapsed;
            Console.WriteLine("qSort = {0} sec and {1}msec", qs.Seconds, qs.Milliseconds);
            Console.WriteLine("bubble = {0} sec and {1}msec", bu.Seconds, bu.Milliseconds);
        }
    }
}
