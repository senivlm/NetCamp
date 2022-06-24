using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Translater.Services
{
    internal static class SentenceServise
    {
        public static void ToWords(string data, out List<string> words, out List<string> betwins, out bool isFirstLitera)
        {
            words = new();
            betwins = new();
            isFirstLitera = false;
            if (string.IsNullOrWhiteSpace(data)) return;
            Regex regexWords = new Regex(@"\w+");
            words = regexWords.Matches(data).Select(r => r.Value).ToList();
            Regex regexBetwins = new Regex(@"\W+");
            betwins = regexBetwins.Matches(data).Select(r => r.Value).ToList();
            isFirstLitera = char.IsLetterOrDigit(data[0]);
        }
        public static string ToSentence(List<string> words, List<string> betvins, bool isFirstLitera)
        {
            int i = 0, j = 0;
            string result = string.Empty;
            while (i < words.Count || j < betvins.Count)
            {
                if (isFirstLitera)
                {
                    result += words[i++];
                    isFirstLitera = false;
                }
                if (j < betvins.Count)
                {
                    result += betvins[j++];
                }
                if (i < words.Count)
                {
                    result += words[i++];
                }
            }
            return result;
        }
        public static List<string> CorrectUpperCase(List<string> sourceWords, List<string> words)
        {
            if (sourceWords.Count != words.Count) throw new ArgumentException("incorrect translated word's list");
            List<string> result = new();
            for (int i = 0; i < sourceWords.Count; i++)
            {
                if (string.IsNullOrEmpty(words[i])) result.Add(words[i]);
                if (char.IsLower(sourceWords[i][0]))
                    result.Add(words[i]);
                else
                    result.Add($"{char.ToUpper(words[i][0])}{words[i].Substring(1).ToLower()}");
            }
            return result;
        }
    }
}
