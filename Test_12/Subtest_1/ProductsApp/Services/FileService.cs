using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Services
{
    static internal class FileService
    {
        public static void AddStringToFile(string fileName, string data, bool appendData = true)
        {
            using (StreamWriter stream = new (fileName, appendData))
            {
                stream.WriteLine(data);
            }
        }
        public static List<string> GetStringsFromFile(string fileName)
        {
            List<string> res = new ();
            using (StreamReader stream = new (fileName))
            {
                while (!stream.EndOfStream)
                {
                    res.Add(stream.ReadLine());
                }
            }
            return res;
        }
    }
}
