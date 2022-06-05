using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    internal class SortInFile
    {
        public void Sort(string sourceFile, string destinationFile)
        {
            if (string.IsNullOrEmpty(sourceFile) || string.IsNullOrEmpty(destinationFile))
                throw new ArgumentNullException();
            if (!destinationFile.Equals(sourceFile)) FileServices.Copyfile(sourceFile, destinationFile);
            FileServices.SplitFileInHalf(destinationFile);
            Vector vector = new Vector(destinationFile + "1");
            vector.QuickSort();
            vector.SaveToFile(destinationFile + "1");
            vector = new Vector(destinationFile + "2");
            vector.QuickSort();
            vector.SaveToFile(destinationFile + "2");
            FileServices.MergeAndSortTwoArrayFiles(destinationFile);
        }
    }
}
