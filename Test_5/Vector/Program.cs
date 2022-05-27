using System;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Vector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector arrBubble;                   //Clone aray for different algoritms
            Vector arrQS;
            Vector arrSM;
            Vector arrPyr;
            string fileName = "randomArray";
            if (FileAccess.ReadArrayFromFile(fileName, out int[] fileArray))
            {
                Console.WriteLine("Reading array from file");
                arrBubble = new Vector(fileArray);
                arrQS = new Vector(fileArray);
                arrSM = new Vector(fileArray);
                arrPyr = new Vector(fileArray);
            }
            else
            {
                int n = 10000;
                arrBubble = new Vector(n);
                arrBubble.InitRandom(1, 100);
                int[] arr = new int[n];
                for (int i = 0; i < n; i++)
                {
                    arr[i] = arrBubble[i];
                }
                arrQS = new Vector(arr);
                arrSM = new Vector(arr);
                arrPyr = new Vector(arr);
                FileAccess.WriteArrayToFile(fileName, arr);
            }
            Console.WriteLine("Unsorted array");
            Console.WriteLine(arrBubble);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            arrBubble.Bubble();
            stopwatch.Stop();
            TimeSpan bubble = stopwatch.Elapsed;
            Console.WriteLine("Sorted array");
            Console.WriteLine(arrBubble);
            stopwatch.Restart();
            arrQS.QuickSort();
            stopwatch.Stop();
            TimeSpan qs = stopwatch.Elapsed;
            stopwatch.Restart();
            arrSM.SplitMergeSort();
            stopwatch.Stop();
            TimeSpan sM = stopwatch.Elapsed;
            stopwatch.Restart();
            arrPyr.PyramidalSort();
            stopwatch.Stop();
            TimeSpan pyr = stopwatch.Elapsed;
            Console.WriteLine("bubble = {0} sec and {1}msec", bubble.Seconds, bubble.Milliseconds);
            Console.WriteLine("qSort = {0} sec and {1}msec", qs.Seconds, qs.Milliseconds);
            Console.WriteLine("Split and Merge = {0} sec and {1}msec", sM.Seconds, sM.Milliseconds);
            Console.WriteLine("Pyramidal = {0} sec and {1}msec", pyr.Seconds, pyr.Milliseconds);
                            //Some result
                            //bubble = 1 sec and 553msec
                            //qSort = 0 sec and 8msec
                            //Split and Merge = 0 sec and 5msec
                            //Pyramidal = 0 sec and 9msec
        }
    }
}
