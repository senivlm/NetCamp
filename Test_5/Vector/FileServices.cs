using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    static internal class FileServices
    {
        enum FilePart { first, middle, second }
        public static void WriteArrayToFile(string fileName, int[] data)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                foreach (var item in data)
                {
                    stream.WriteByte(Convert.ToByte(item));
                }
            }
        }
        public static bool ReadArrayFromFile(string fileName, out int[] data)
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
        public static void SortArrayInFile(string fileName)
        {
            FilePart[] order = new FilePart[] {
                FilePart.first, FilePart.second, FilePart.middle,
                FilePart.first, FilePart.second, FilePart.middle };
            foreach (var part in order)
                SortFilePart(fileName, part);
        }
        static void SortFilePart(string fileName, FilePart part)
        {
            try
            {
                using (FileStream stream = new FileStream(fileName, FileMode.Open))
                {
                    int lenght = (int)stream.Length / 2 + 1;
                    int start = 0;
                    if (part == FilePart.middle)
                    {
                        start = lenght / 2;
                    }
                    else if (part == FilePart.second)
                    {
                        start = lenght;
                        lenght = (int)stream.Length - lenght;
                    }
                    byte[] bytes = new byte[lenght];
                    int[] data = new int[lenght];
                    stream.Position = start;
                    stream.Read(bytes, 0, lenght);
                    data = bytes.Select(b => (int)b).ToArray();
                    Sort.SplitMergeSort(ref data);
                    bytes = data.Select(d => (byte)d).ToArray();
                    stream.Position = start;
                    stream.Write(bytes, 0, lenght);
                }
            }
            catch { }
        }
        public static void Copyfile(string sourceFileName, string destinationFileName)
        {
            try
            {
                File.Copy(sourceFileName, destinationFileName, true);
            }
            catch { }
        }
    }
}
