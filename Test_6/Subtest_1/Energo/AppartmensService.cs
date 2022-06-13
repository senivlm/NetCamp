using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Energo
{
    internal class AppartmensService
    {
        List<Appartment> appartments;
        int quarter;
        public int Quarter { get => quarter; }
        string errors;
        public string Errors { get { return errors; } }
        public AppartmensService(string filename)
        {
            appartments = new List<Appartment>();
            errors = String.Empty;
            int appartmentCount = 0;
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line0 = reader.ReadLine();
                    string[] lines0 = line0.Split("_");
                    if (lines0.Length == 2)
                    {
                        if (!int.TryParse(lines0[0], out appartmentCount))
                        {
                            errors += "error in appartment count; ";
                        }
                        if (!int.TryParse(lines0[1], out quarter))
                        {
                            errors += "error in year quarter; ";
                        }
                    }
                    else
                    {
                        errors += "error in first file string; ";
                    }
                    while (reader.Peek() > -1)
                    {
                        string line = reader.ReadLine();
                        string[] lines = line.Split("_");
                        try
                        {
                            Appartment appartment = new Appartment(lines);
                            appartments.Add(appartment);
                        }
                        catch (Exception ex)
                        {
                            errors += $"appartment {lines[0]}: {ex.Message}; ";
                        }
                    }
                    if (appartmentCount != appartments.Count)
                    {
                        errors += $"appartments count do not match count string in file";
                    }
                }
            }
            catch (FileNotFoundException)
            {
                errors += "file not found; ";
            }
            catch (Exception e)
            {
                errors += e.Message;
            }
        }
        public override string ToString()
        {
            string result = string.Empty;
            foreach (Appartment appartment in appartments)
            {
                result += $"{appartment}\r\n";
            }
            return result;
        }
        public void SortByAppartmentName()
        {
            appartments = appartments.OrderBy(ap => ap.Number).ToList();
        }
        public Appartment GetByNumber(int number)
        {
            Appartment appartment = appartments.FirstOrDefault(ap => ap.Number == number);
            return appartment;
        }
        public string GetAppWithMaxCredit(double price)
        {
            Appartment appartment = appartments
                .Aggregate((x, y) => (x.endCounter - x.startCounter) > (y.endCounter - y.startCounter) ? x : y);
            double debt = (appartment.endCounter - appartment.startCounter) * price;
            return string.Format($"The biggest creditor : {appartment.FIO} with credit {debt}");
        }
        public string GetCountDayAfterCheckCounter()
        {
            string res = string.Empty;
            foreach (Appartment appartment in appartments)
            {
                if (appartment.counterReadingDates.Count == 0)
                {
                    res += $"Appartment {appartment.Number} did not give meter readings\r\n";
                }
                else
                {
                    DateTime last = appartment.counterReadingDates.Max();
                    int days = (DateTime.Now - last).Days;
                    res += $"Appartment {appartment.Number} give metter {days} days ago\r\n";
                }
            }
            return res;
        }
        public string GetAppartmentsWhichDidnotGetElectricity()
        {//Добре, що освоюєте linq
            List<Appartment> resAppartments = appartments.Where(ap => ap.endCounter == ap.startCounter).ToList();
            string res = string.Empty;
            if (resAppartments.Any())
            {
                foreach (Appartment appart in resAppartments)
                {
                    res += $"{appart}\r\n";
                }
            }
            else
            {
                res = "All appartments used electricity";
            }
            return res;
        }
    }
}
