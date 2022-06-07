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
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
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
        public static void SplitFileInHalf(string filename, string firstSuffix = "1",
            string secondSuffix = "2")
        {
            using (FileStream stream = new FileStream(filename, FileMode.Open))
            using (FileStream streamFirst = new FileStream(filename + firstSuffix, FileMode.Create))
            using (FileStream streamSecond = new FileStream(filename + secondSuffix, FileMode.Create))
            {
                long half = stream.Length / 2;
                byte[] bytes = new byte[half];
                stream.Read(bytes, 0, bytes.Length);
                streamFirst.Write(bytes, 0, bytes.Length);
                bytes = new byte[stream.Length - half];
                stream.Read(bytes, 0, bytes.Length);
                streamSecond.Write(bytes, 0, bytes.Length);
            }
        }
        public static void MergeAndSortTwoArrayFiles(string filename, string firstSuffix = "1",
            string secondSuffix = "2")
        {//два одночасно масиви не можна використовувати. не вистачає оперативки за умовою.
            ReadArrayFromFile(filename + firstSuffix, out int[] firstVals);
            ReadArrayFromFile(filename + secondSuffix, out int[] secondVals);
            using (FileStream stream = new FileStream(filename, FileMode.Open))
            {
                int first = 0, second = 0;
                int val = 0;
                while (first < firstVals.Length || second < secondVals.Length)
                {
                    if (first == firstVals.Length)
                    {
                        val = secondVals[second++];
                    }
                    else if (second == secondVals.Length)
                    {
                        val = firstVals[first++];
                    }
                    else if (firstVals[first] > secondVals[second])
                    {
                        val = firstVals[first++];
                    }
                    else
                    {
                        val = secondVals[second++];
                    }
                    stream.WriteByte((byte)val);
                }
            }
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
