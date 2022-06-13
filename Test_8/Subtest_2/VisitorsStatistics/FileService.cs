using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorsStatistics
{
    internal static class FileService
    {
        public static List<string> ReadFile(string fileName)
        {
            List<string> list = new List<string>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (reader.Peek() > 0)
                {
                    list.Add(reader.ReadLine());
                }
            }
            return list;
        }
    }
}
