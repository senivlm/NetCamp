using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energo
{
    internal static class FileService
    {
        public static void SaveListToFile(string fikeName, List<string> data)
        {
            using(StreamWriter stream = new StreamWriter(fikeName))
            {
                foreach(string str in data)
                {
                    stream.WriteLine(str);
                }
            }
        }
    }
}
