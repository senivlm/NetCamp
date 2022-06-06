using System;

namespace Text
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sourceFileName = @"../../../Data.txt";
            string destFileName = @"../../../Result.txt";
            StringService stringService = null;
            try
            {
                stringService = new StringService(sourceFileName);
                stringService.SaveToFile(destFileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            Console.WriteLine(stringService.GetShortestLongesrSententcesesWords());
            Console.ReadLine();
        }
    }
}
