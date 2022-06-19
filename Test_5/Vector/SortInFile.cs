using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    internal class SortInFile
    {
        public void Sort(string sourceFile, string destinationFile, bool ordedAscending = true)
        {
            if (string.IsNullOrEmpty(sourceFile) || string.IsNullOrEmpty(destinationFile))
                throw new ArgumentNullException();
            if (!destinationFile.Equals(sourceFile)) FileServices.Copyfile(sourceFile, destinationFile);
            FileServices.SplitFileInHalf(destinationFile);
            Vector vector = new Vector("tmp1");
            vector.QuickSort(ordedAscending);
            vector.SaveToFile("tmp1");
            vector = new Vector("tmp2");
            vector.QuickSort(ordedAscending);
            vector.SaveToFile("tmp2");
            FileServices.MergeAndSortTwoArrayFiles(destinationFile,ordedAscending);
        }
    }
}
