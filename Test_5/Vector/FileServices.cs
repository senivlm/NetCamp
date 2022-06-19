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
        public static void SplitFileInHalf(string filename, string firstFileName = "tmp1",
            string secondFileName = "tmp2")
        {
            using (FileStream stream = new FileStream(filename, FileMode.Open))
            using (FileStream streamFirst = new FileStream(firstFileName, FileMode.Create))
            using (FileStream streamSecond = new FileStream(secondFileName, FileMode.Create))
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
        public static void MergeAndSortTwoArrayFiles(string filename, bool ordedAscending,
            string firstFileName = "tmp1", string secondFileName = "tmp2")
        {
            using (FileStream stream = new FileStream(filename, FileMode.Open))
            using (FileStream streamFirst = new FileStream(firstFileName, FileMode.Open))
            using (FileStream streamSecond = new FileStream(secondFileName, FileMode.Open))
            {
                bool canReadFirst = streamFirst.CanRead;
                bool canReadsecond = streamSecond.CanRead;
                int? firstVal = null, secondVal = null;
                while (stream.Position < streamFirst.Length + streamSecond.Length)
                {
                    if (firstVal == null && streamFirst.Position < streamFirst.Length) firstVal = streamFirst.ReadByte();
                    if (secondVal == null && streamSecond.Position < streamSecond.Length) secondVal = streamSecond.ReadByte();
                    if (firstVal == null)
                    {
                        stream.WriteByte((byte)secondVal);
                        secondVal = null;
                    }
                    else if (secondVal == null)
                    {
                        stream.WriteByte((byte)firstVal);
                        firstVal = null;
                    }
                    else if (firstVal < secondVal ^ ordedAscending)
                    {
                        stream.WriteByte((byte)secondVal);
                        secondVal = null;
                    }
                    else
                    {
                        stream.WriteByte((byte)firstVal);
                        firstVal = null;
                    }
                }
            }
            try
            {
                File.Delete(firstFileName);
                File.Delete(secondFileName);
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
