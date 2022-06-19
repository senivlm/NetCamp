using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetEmails
{
    internal static class FileService
    {
        public static List<string> LoadFile(string fileName)
        {
            List<string> lines = new List<string>();
            using (StreamReader stream = new StreamReader(fileName))
            {
                while (!stream.EndOfStream)
                    lines.Add(stream.ReadLine());
            }
            return lines;
        }
    }
}
