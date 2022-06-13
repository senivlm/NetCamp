using System;
using System.IO;

namespace Energo
{
    internal class Program
    {
        static void Main(string[] args)
        {//не побачила результуючого файлу
            AppartmensService appartmensService = new AppartmensService(@"..\..\..\data.txt");
            if (appartmensService.Errors.Length > 0)
            {
                Console.WriteLine($"Errors:{appartmensService.Errors}");

            }
            Console.WriteLine(appartmensService);
            appartmensService.SortByAppartmentName();
            Console.WriteLine("Sorted list");
            Console.WriteLine(appartmensService);
            Console.WriteLine("Get appartment 2");
            Console.WriteLine(appartmensService.GetByNumber(2));
            Console.WriteLine("Get the biggest debtor");
            Console.WriteLine("Enter price 1kW electricity");
            int i = 4;
            double price = 0;
            do
            {
                if (double.TryParse(Console.ReadLine(), out price))
                {
                    i = 0;
                }
                else
                {
                    i--;
                    if (i > 0) Console.WriteLine("Try again");
                }
            }
            while (i > 0);
            if (price > 0) Console.WriteLine(appartmensService.GetAppWithMaxCredit(price));
            Console.WriteLine("Days have passed since the submission of the meter reading");
            Console.WriteLine(appartmensService.GetCountDayAfterCheckCounter());
            Console.WriteLine("Get appartment not used electricity");
            Console.WriteLine(appartmensService.GetAppartmentsWhichDidnotGetElectricity());
        }
    }
}
