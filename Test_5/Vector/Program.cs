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
            //Я виправив сортування - тепер файл повністю не загружається у пам'ять.
            //та додав порядок сортування
            string fileName = "randomArray";
            string sortedFileName = "sortedArray";
            if (!FileServices.ReadArrayFromFile(fileName, out int[] fileArray))
            {
                int n = 11;
                Vector arrBubble = new Vector(n);
                arrBubble.InitRandom(1, 100);
                int[] arr = new int[n];
                for (int i = 0; i < n; i++)
                {
                    arr[i] = arrBubble[i];
                }
                try
                {
                    FileServices.WriteArrayToFile(fileName, arr);
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            }

            SortInFile sortInFile = new SortInFile();
            try
            {
                sortInFile.Sort(fileName, sortedFileName,true);
                Console.WriteLine("File successfuly sorted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
