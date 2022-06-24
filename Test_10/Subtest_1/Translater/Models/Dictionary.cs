using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translater.Services;

namespace Translater.Models
{
    internal class Dictionary
    {
        private Dictionary<string, string> _dictionary;
        public string FileName { get;private set; }
        public Dictionary(string fileName)
        {
            FileName = fileName;
            List<string> strings = FileService.LoadStrings(fileName);
            _dictionary = new();
            foreach (string str in strings)
            {
                if (string.IsNullOrWhiteSpace(str)) continue;
                string[] dictVal = str.Split('-');
                if (dictVal.Length < 2) continue;
                _dictionary.Add(dictVal[0], dictVal[1]);
            }
        }
        public bool TryGetValue(string key, out string val)
        {
             _dictionary.TryGetValue(key, out val);
            return !string.IsNullOrWhiteSpace(val);
        }
        public void AddValue(string key, string val)
        {
            _dictionary.Add(key, val);
        }
    }
}
