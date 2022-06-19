using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GetEmails
{
    internal static class SearchService
    {
        public static List<string> GetEmailsFromFile(string fileName)
        {
            return GetEmails(FileService.LoadFile(fileName));
        }
        public static List<string> GetEmails(List<string> data)
        {
            List<string> result = new List<string>();
            foreach (string email in data)
                result.AddRange(SearchEmail(email));
            return result;
        }
        private static List<string> SearchEmail(string dataStr)
        {
            List<string> result = new List<string>();
            Regex regex = new Regex(@"[a-z,A-Z,0-9]+@\w+\.\w+|[a-z,A-Z,0-9][a-z,A-Z,0-9,\.,\u005F]+[a-z,A-Z,0-9]@\w+\.\w+");
            MatchCollection matches = regex.Matches(dataStr);
            foreach (Match match in matches)
                result.Add(match.Value);
            return result;
        }
    }
}
