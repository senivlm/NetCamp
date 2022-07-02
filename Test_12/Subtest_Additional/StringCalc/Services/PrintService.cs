using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc.Services
{
    internal class PrintService
    {
        public static void PrintAllert(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void PrintGreen(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void Print(string text)
        {
            Console.WriteLine(text);
        }
        public static string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
