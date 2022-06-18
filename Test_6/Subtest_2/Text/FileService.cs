using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text
{
    static internal class FileService
    {
        public static string[] ReadSentencessFromTXTFile(string fileName)
        {
            List<string> sentencess = new List<string>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string endString = string.Empty;
                while (reader.Peek() > 0)
                {
                    string line = reader.ReadLine();
                    if (!string.IsNullOrEmpty(endString)) line = endString + line;
                    List<string> stringSentencess = StringService.SplitToSentences(line, out endString);
                    if (stringSentencess.Count > 0) sentencess.AddRange(stringSentencess);
                }
            }
            return sentencess.ToArray();
        }
        public static void SaveToFile(string fileName, List<string> data)
        {
            using (StreamWriter stream = new StreamWriter(fileName))
            {
                foreach (string line in data)
                {
                    stream.WriteLine(line);
                }
            }
        }
    }
}
