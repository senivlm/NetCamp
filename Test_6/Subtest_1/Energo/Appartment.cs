using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energo
{
    internal class Appartment
    {
        public int Number { get; set; }
        public string FIO { get; set; }
        public int startCounter { get; set; }
        public int endCounter { get; set; }
        public List<DateTime> counterReadingDates { get; set; }
        public Appartment()
        {
            FIO = string.Empty;
            counterReadingDates = new List<DateTime>();
        }
        public Appartment(string[] data)
        {
            if (data.Length < 4) throw new ArgumentException("Not enaph arguments");
            counterReadingDates = new List<DateTime>();
            string errors = string.Empty;
            if (int.TryParse(data[0], out int number))
            {
                Number = number;
            }
            else
            {
                errors += "error in appartment number; ";
            }
            if (data[1].Length > 3)
            {
                FIO = data[1];
            }
            else
            {
                errors += "error in appartment owner; ";
            }
            if (int.TryParse(data[2], out int startCount))
            {
                startCounter = startCount;
            }
            else
            {
                errors += "error in appartment start counter; ";
            }
            if (int.TryParse(data[3], out int endCount))
            {
                endCounter = endCount;
            }
            else
            {
                errors += "error in appartment start counter; ";
            }
            if (data.Length > 4)
            {
                for (int i = 4; i < data.Length; i++)
                {
                    if (DateTime.TryParse(data[i], out DateTime date))
                    {
                        counterReadingDates.Add(date);
                    }
                    else
                    {
                        errors += $"error in appartment counter reading date number {i - 3}; ";
                    }
                }
                counterReadingDates=counterReadingDates.OrderBy(d => d.Date).ToList();
            }
            if(!string.IsNullOrEmpty(errors)) throw new FormatException(errors);
        }
        public override string ToString()
        {
            List<string> data = new List<string>
            {
                Number.ToString(),
                FIO,
                startCounter.ToString(),
                endCounter.ToString()
            };
            foreach (DateTime date in counterReadingDates)
            {
                data.Add(date.ToString("dd MMMM"));
            }
            return FormatterService.GetTabbleRowl(data);
        }
    }
}