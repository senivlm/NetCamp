using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
   static internal class FileAccess
    {
        public static void WriteArrayToFile(string fileName, int[] data)
        {
            using(FileStream stream=new FileStream(fileName, FileMode.OpenOrCreate))
            {
                foreach(var item in data)
                {
                    stream.WriteByte(Convert.ToByte(item));
                }
            }
        }
        public static bool ReadArrayFromFile(string fileName,out int[] data)
        {
            try
            {
                using (FileStream stream = new FileStream(fileName, FileMode.Open))
                {
                    byte[] bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, bytes.Length);
                    data = new int[bytes.Length];
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        data[i] = Convert.ToInt32(bytes[i]);
                    }
                }
            }
            catch
            {
                data = null;
                return false;
            }
            return true;
        }
    }
}
