using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorsStatistics
{
    internal class Visit
    {
        public string Ip { get; set; }
        public DateTime Time { get; set; }
        public Settings.WeeksDay Day { get; set; }
        public Visit()
        {
            Ip = "0.0.0.0";
            Time = new DateTime();
            Day = Settings.WeeksDay.monday;
        }
        public Visit(string ipStr, string timeStr, string dayStr)
        {
            if (string.IsNullOrEmpty(ipStr)) throw new ArgumentNullException("Empty Ip");
            if (string.IsNullOrEmpty(timeStr)) throw new ArgumentNullException("Empty Time");
            if (string.IsNullOrEmpty(dayStr)) throw new ArgumentNullException("Empty Day");
            Ip = ipStr;
            Time = DateTime.Parse(timeStr);
            Day = (Settings.WeeksDay)Enum.Parse(typeof(Settings.WeeksDay), dayStr);
        }
        public override string ToString()
        {
            return $"{Ip} {Time.ToShortTimeString()} {Day}";
        }
    }
}
