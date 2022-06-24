using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translater.Models;

namespace Translater.Services
{
    internal class TranslaterService
    {
        public static void TranslateFile(string sourceFile, string destinationFile, string dictionaryFile = Settings.dictionaryFileName)
        {
            Dictionary dictionary = new Dictionary(dictionaryFile);
            List<string> sentences = FileService.LoadStrings(sourceFile);
            List<string> result = new();
            foreach (string sentence in sentences)
            {
                SentenceServise.ToWords(sentence, out List<string> words, out List<string> betwins, out bool isFirstLitera);
                TranslateList(words, out List<string> translatedWords, dictionary);
                List<string> correctedWords = SentenceServise.CorrectUpperCase(words, translatedWords);
                string translatedSentence = SentenceServise.ToSentence(correctedWords, betwins, isFirstLitera);
                result.Add(translatedSentence);
            }
            FileService.SaveStrings(destinationFile, result, false);
        }
        public static void TranslateList(List<string> words, out List<string> transtatedWords, Dictionary dictionary)
        {
            transtatedWords = new List<string>();
            foreach (string word in words)
            {
                if (dictionary.TryGetValue(word, out string val))
                {
                    transtatedWords.Add(val);
                }
                else if (UserService.TryAskUser(word, out string translated))
                {
                    transtatedWords.Add(translated);
                    dictionary.AddValue(word, translated);
                    FileService.SaveStrings(dictionary.FileName, new List<string> { $"{word}-{translated}" });
                }
                else
                {
                    transtatedWords.Add(word);
                }
            }
        }
    }
}
