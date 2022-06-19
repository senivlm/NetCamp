using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    internal static class FileService
    {
        public static string[] LoadStrings(string filaName)
        {
            List<string> result = new List<string>();
            using (StreamReader stream = new StreamReader(filaName))
            {
                while (!stream.EndOfStream)
                {
                    result.Add(stream.ReadLine());
                }
            }
            return result.ToArray();
        }
        public static void SaveStrings(string fileName, List<string> data)
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
