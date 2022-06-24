using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translater.Services
{
    internal static class FileService
    {
        public static List<string> LoadStrings(string filaName)
        {
            List<string> result = new List<string>();
            using (StreamReader stream = new StreamReader(filaName))
            {
                while (!stream.EndOfStream)
                {
                    result.Add(stream.ReadLine());
                }
            }
            return result;
        }
        public static void SaveStrings(string fileName, List<string> data, bool appendData = true)
        {
            using (StreamWriter stream = new StreamWriter(fileName, appendData))
            {
                foreach (string line in data)
                {
                    stream.WriteLine(line);
                }
            }
        }
    }
}
