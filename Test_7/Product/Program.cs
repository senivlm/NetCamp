using System;
using System.Collections.Generic;
using System.IO;

namespace Product
{
    internal class Program
    {//Не знайшла 8.
        static void Main(string[] args)
        {

            string fileStorage = "storage.txt";
            Storage storage = new Storage();
            storage.InitializationProducts();
            storage.SaveToFile(fileStorage);
            FileService.AddStringToFile(fileStorage, "Meat_pork_1_45_firstSort_veal");
            FileService.AddStringToFile(fileStorage, "Mea!_Pork_1_45_firstSort_veal");
            FileService.AddStringToFile(fileStorage, "Meat_Pork_1_4r5_firstSort_veal");
            Console.WriteLine($"Storage has saved to file \"{fileStorage}\"");
            Console.WriteLine("Enter file name to load storage");
            Storage loaded = null;
            int tryCount = 3;
            //Подумайте, де місце цьому коду.
            while (tryCount > 0)
            {
                try
                {
                    string fileName = Console.ReadLine();
                    if (string.IsNullOrEmpty(fileName))
                        throw new ArgumentException("File name coud not be empty");
                    loaded = new Storage(fileName);
                    break;
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine($"file not found. You have {--tryCount} attemp");
                    Logger.AddLogToFile("File not found");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"File do not loaded. You have {--tryCount} attemp");
                    Logger.AddLogToFile(ex.Message);
                }
            }
            if (loaded != null)
            {


                Console.WriteLine(loaded);
            }
            else
            {
                Console.WriteLine("File do not loaded");
            }
            Console.WriteLine($"\r\n Loadin Log from date. Enter date");
            List<string> logs = new List<string>();
            try
            {
                string dateStr = Console.ReadLine();
                logs = Logger.GetLoggsFromDate(dateStr);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (logs.Count > 0)
            {
                foreach (string log in logs)
                {
                    Console.WriteLine(log);
                }
            }
        }
    }
}
