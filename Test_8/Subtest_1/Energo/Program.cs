using System;
using System.IO;

namespace Energo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppartmensService appartmensService = new AppartmensService(@"..\..\..\data.txt");
            AppartmensService appartmensService1 = new AppartmensService(@"..\..\..\data1.txt");
            Console.WriteLine("  a + b");
            Console.WriteLine(appartmensService + appartmensService1);
            Console.WriteLine("  a - b");
            Console.WriteLine(appartmensService1-appartmensService);
        }
    }
}
