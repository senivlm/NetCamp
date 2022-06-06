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
        public static string ReadTXTFile(string fileName)
        {
            string res = string.Empty;
            using (StreamReader reader = new StreamReader(fileName))
            {

                res = reader.ReadToEnd();
            }
            return res;
        }
        public static void SaveToFile(string fileName, string data)
        {
            using(StreamWriter stream = new StreamWriter(fileName))
            {
                stream.Write(data);
            }
        }
    }
}
