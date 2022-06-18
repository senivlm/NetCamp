using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text
{
    internal class StringService
    {
        string[][] words;
        public StringService(string fileName)
        {
            string[] sentences = FileService.ReadSentencessFromTXTFile(fileName);
            words = new string[sentences.Length][];
            for (int i = 0; i < sentences.Length; i++)
            {
                words[i] = SplitSentence(sentences[i]);
            }
        }
        public List<string> ToStringSentencess()
        {
            List<string> sentencess = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                string sentence = string.Empty;
                for (int j = 0; j < words[i].Length; j++)
                {
                    sentence += String.Format("{0}{1}", j == 0 ? '\t' : ' ', words[i][j]);
                }
                sentencess.Add(sentence);
            }
            return sentencess;
        }
        public void SaveToFile(string filename)
        {
            FileService.SaveToFile(filename, this.ToStringSentencess());
        }
        string[] SplitSentence(string str)
        {
            return str.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }
        public static List<string> SplitToSentences(string str, out string rest)
        {
            List<string> res = new List<string>();
            rest = string.Empty;
            if (String.IsNullOrWhiteSpace(str)) return res;
            str = str + " ";
            int endPos = str.Length;
            int startPos = 0;
            while (startPos < endPos)
            {
                int pt1 = str.IndexOf(". ", startPos);
                if (pt1 < 0) pt1 = endPos + 1;
                int quest = str.IndexOf("?", startPos);
                if (quest < 0) quest = endPos + 1;
                int exclam = str.IndexOf("!", startPos);
                if (exclam < 0) exclam = endPos + 1;
                int min = Math.Min(pt1, quest < exclam ? quest : exclam);
                if (min == endPos + 1)
                {
                    string st = str.Substring(startPos, endPos - startPos);
                    if (!string.IsNullOrWhiteSpace(st)) rest = st;
                    return res;
                }
                res.Add(str.Substring(startPos, min - startPos + 1));
                startPos = min + 1;
            }
            return res;
        }
        public string GetShortestLongesrSententcesesWords()
        {
            string res = " Shortest an longest words of sentences\r\n";
            for (int i = 0; i < words.Length; i++)
            {
                res += $"{i}\t{GetShortestAndLongest(words[i])}\r\n";
            }
            return res;
        }
        string GetShortestAndLongest(string[] sentences)
        {
            char[] punctuations = new char[] { ',', ':', '-', ';', '.', '!', '?', '(', ')' };
            string shortest = sentences[0].TrimEnd(punctuations);
            string longest = shortest;
            for (int i = 1; i < sentences.Length; i++)
            {
                string currentStr = sentences[i].TrimEnd(punctuations);
                if (currentStr.Length > longest.Length) longest = currentStr;
                if (currentStr.Length < shortest.Length) shortest = currentStr;
            }
            return $"{shortest}\t{longest}";
        }
    }
}
