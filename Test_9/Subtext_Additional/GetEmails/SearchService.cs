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
        public static List<string> GetEmailsFromFile(string fileName, bool searchByRegularExpression = true)
        {
            return GetEmails(FileService.LoadFile(fileName), searchByRegularExpression);
        }
        public static List<string> GetEmails(List<string> data, bool searchByRegularExpression = true)
        {
            List<string> result = new List<string>();
            foreach (string str in data)
                if (searchByRegularExpression)
                {
                    result.AddRange(SearchEmail(str));
                }
                else
                {
                    result.AddRange(SearchByChar(str));
                }
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
        private static List<string> SearchByChar(string dataStr)
        {
            char[] allowedPunctuations = new char[] { '.', '_' };
            List<string> result = new List<string>();
            int position = 0;
            while (position < dataStr.Length)
            {
                if ((position = dataStr.IndexOf("@", position + 1)) == -1) break;
                int startPos = position, endPos = position;
                while (startPos > 0)
                {
                    if (char.IsLetter(dataStr[startPos - 1]) || char.IsDigit(dataStr[startPos - 1]) ||
                        allowedPunctuations.Contains(dataStr[startPos - 1]))
                    {
                        startPos--;
                    }
                    else
                    {
                        break;
                    }
                }
                while (endPos < dataStr.Length - 1)
                {
                    if (char.IsLetter(dataStr[endPos + 1]) || char.IsDigit(dataStr[endPos + 1]) ||
                   ('.'.Equals(dataStr[endPos + 1]) && endPos != position + 1))
                    {
                        endPos++;
                    }
                    else break;
                }
                result.Add(dataStr.Substring(startPos, endPos - startPos));
            }
            return result;
        }
    }
}
