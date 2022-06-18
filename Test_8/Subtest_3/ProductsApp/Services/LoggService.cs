using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Services
{
    internal static class LoggService
    {
        public static void AddLogToFile(string logData)
        {

            FileService.AddStringToFile(Settings.ErrorLogFile,
                $"{DateTime.Now.ToString()} {logData}");
        }
        public static List<string> GetLoggsFromDate(string date)
        {
            if (string.IsNullOrEmpty(date)) return GetLoggsFromDate();
            if (!DateTime.TryParse(date, out DateTime dt))
                throw new ArgumentException("Wrong Date");
            return GetLoggsFromDate(dt);
        }
        public static List<string> GetLoggsFromDate(DateTime? date = null)
        {
            List<string> loggs = FileService.GetStringsFromFile(Settings.ErrorLogFile);
            if (date != null)
            {
                List<(DateTime, string)> values = new List<(DateTime, string)>();
                foreach (string str in loggs)
                {
                    if (DateTime.TryParse(str.Substring(0, 10), out DateTime dateLog))
                    {
                        values.Add(new(dateLog, str));
                    }
                }
                loggs = values.Where(v => date < v.Item1).Select(v => v.Item2).ToList();
            }
            return loggs;
        }
    }
}
