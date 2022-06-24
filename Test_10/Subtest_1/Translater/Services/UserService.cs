using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translater.Services
{
    internal class UserService
    {
        public static bool TryAskUser(string word,out string translated)
        {
            translated=string.Empty;
            if(string.IsNullOrEmpty(word))return false;
            int attempt = Settings.attemptsCount;
            string question = $"translate please word \"{word}\"";
            while(attempt > 0)
            {
                string translate=AskUser(question);
                if (!string.IsNullOrWhiteSpace(translate))
                {
                    translated=translate;
                    return true;
                }
                attempt--;
            }
            return false;
        }
        public static string AskUser(string questions)
        {
            Console.WriteLine(questions);
            return Console.ReadLine().ToLower();
        }
    }
}
