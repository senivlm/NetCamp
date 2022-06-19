using System;
using System.Collections.Generic;

namespace GetEmails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"..\..\..\Data.txt";
           List<string> emails= SearchService.GetEmailsFromFile(fileName);
            Console.WriteLine("Emails:");
            foreach (string email in emails)
                Console.WriteLine(email);
        }
    }
}
