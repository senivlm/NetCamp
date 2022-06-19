using System;
using System.Collections.Generic;
using System.IO;

namespace Energo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Я додав форматування таблиці, її можна робити ширше. Ширина прописана у Settings.
            //
            //додів запис у файл
            AppartmensService appartmensService = new AppartmensService(@"..\..\..\data.txt");
            string fileResult = @"..\..\..\result.txt";
            if (appartmensService.Errors.Length > 0)
            {
                Console.WriteLine($"Errors:{appartmensService.Errors}");

            }
            appartmensService.SortByAppartmentName();
            Console.WriteLine(appartmensService);
            try
            {
                FileService.SaveListToFile(fileResult, appartmensService.ToListString());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
