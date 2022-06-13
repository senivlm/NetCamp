using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorsStatistics
{
    internal class Statistics
    {
        List<Visit> visits;
        public Statistics(string fileName)
        {
            visits = new List<Visit>();
            List<string> visitStr = FileService.ReadFile(fileName);
            foreach (string str in visitStr)
            {
                try
                {
                    List<string> arguments = str.Split(" ").ToList();
                    visits.Add(new Visit(arguments[0], arguments[1], arguments[2]));
                }
                catch { }
            }
        }
        public string GetStatistics()
        {
            string res = string.Empty;
            if (visits.Count == 0) return "There is no visit";
            var ipVisits = visits.GroupBy(v => v.Ip);
            foreach (var ipVis in ipVisits)
            {
                res += $"Ip: {ipVis.Key} made {ipVis.Count()} visits\n\r";
                res += $"Most popular day(s) is {GetMostPopularDay(ipVis.ToList())}\n\r";
                res += $"Most popular time(s) is {GetMostPopularTime(ipVis.ToList())}\n\r\n\r";
            }
            res += $"Most popular time(s) for all visits is {GetMostPopularTime(visits)}\n\r";
            return res;
        }
        string GetMostPopularDay(List<Visit> visits)
        {
            var dayVisits = visits.GroupBy(v => v.Day);
            int maxVisitCount = 0;
            string days = string.Empty;
            foreach (var dayVis in dayVisits)
            {
                if (dayVis.Count() > maxVisitCount)
                {
                    maxVisitCount = dayVis.Count();
                    days = dayVis.Key.ToString();
                }
                else if (dayVis.Count() == maxVisitCount)
                {
                    days += $", {dayVis.Key.ToString()}";
                }
            }
            return days;
        }
        string GetMostPopularTime(List<Visit> visits)
        {
            string res = string.Empty;
            int maxCount = 0;
            for (int i = 0; i < 24; i++)
            {
                int count = visits.Where(v => v.Time.Hour == i).Count();
                if (count > maxCount)
                {
                    res = $"from {i}h to {i + 1}h";
                    maxCount = count;
                }
                else if (count == maxCount)
                {
                    res += $", from {i}h to {i + 1}h";
                }
            }
            return res;
        }
    }
}
