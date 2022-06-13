using System;

namespace VisitorsStatistics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filaName = @"..\..\..\data.txt";
            Statistics statistics = null;
            try
            {
                statistics = new Statistics(filaName);
                Console.WriteLine(statistics.GetStatistics());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
