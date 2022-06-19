using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energo
{
    internal static class FormatterService
    {
        private static int tabbleWidth;
        private static int add;
        public static string GetTabbleRowl(List<string> data)
        {
            while (data.Count < 7)
            {
                data.Add("");
            }
            if (tabbleWidth == 0)
            {
                SetDimantions();
            }
            string addStr = string.Empty;
            for(int i=0; i<add; i++)
            {
                addStr += " ";
            }
            string result = $"| { data[0],2}{addStr} | { data[1],-15}{addStr} | { data[2],-6}{addStr}"+
                $" | { data[3],-6}{addStr} | { data[4],-10}{addStr} | { data[5],-10}{addStr} | { data[6],-9}{addStr} |";
            int t = result.Length;
            return result;
        }
        public static string GetRowLine()
        {
            if (tabbleWidth == 0)
            {
                SetDimantions();
            }
            string res = string.Empty;
            for(int i=0; i<tabbleWidth; i++)
            {
                res += "-";
            }
            return res;
        }
        public static string GetTabbleHeader()
        {
            List<string> headers = new List<string>
            {
                "N",
                "Name",
                "start",
                "finish",
                "month 1",
                "month 2",
                "month 3"
            };
            return GetTabbleRowl(headers);
        }
        private static void SetDimantions()
        {
            if (Settings.TabbleDimention > 80)
            {
                add = (int)Math.Round((decimal)(Settings.TabbleDimention - 79) / 8, MidpointRounding.AwayFromZero);
                tabbleWidth = 80 + add * 7;
            }
            else
            {
                tabbleWidth = 80;
                add = 0;
            }
        }
    }
}
