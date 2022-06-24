using System;
using Translater.Services;

namespace Translater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TranslaterService.TranslateFile(Settings.sourceFileName, Settings.resultFileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
