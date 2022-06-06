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
            string text = FileService.ReadTXTFile(fileName);
            string[] sentences = SplitToSentences(text);
            words = new string[sentences.Length][];
            for (int i = 0; i < sentences.Length; i++)
            {
                words[i] = SplitSentence(sentences[i]);
            }
        }
        public override string ToString()
        {
            string text = string.Empty;
            for (int i = 0; i < words.Length; i++)
            {
                if (i != 0) text += "\r\n";
                for (int j = 0; j < words[i].Length; j++)
                {
                    text += String.Format("{0}{1}", j == 0 ? '\t' : ' ', words[i][j]);

                }
            }
            return text;
        }
        public void SaveToFile(string filename)
        {
            FileService.SaveToFile(filename, this.ToString());
        }
        string[] SplitSentence(string str)
        {
            return str.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }
        string[] SplitToSentences(string str)
        {
            List<string> res = new List<string>();
            str = str.Replace("\r\n", " ");
            int endPos = str.Length;
            int startPos = 0;
            while (startPos < endPos)
            {
                int pt1 = str.IndexOf(". ", startPos);
                if (pt1 < 0) pt1 = endPos;
                int quest = str.IndexOf("?", startPos);
                if (quest < 0) quest = endPos;
                int exclam = str.IndexOf("!", startPos);
                if (exclam < 0) exclam = endPos;
                int min = Math.Min(pt1, quest < exclam ? quest : exclam);
                if (min == endPos)
                {
                    string st = str.Substring(startPos, endPos - startPos);
                    if (!string.IsNullOrWhiteSpace(st)) res.Add(st);
                    break;
                }
                res.Add(str.Substring(startPos, min - startPos + 1));
                startPos = min + 1;
            }
            return res.ToArray();
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
            char[] punctuations = new char[] { ',', ':', '-', ';', '.', '!', '?'};
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
