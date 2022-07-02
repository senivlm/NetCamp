using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc
{
    internal class Calculator
    {
        public double Calculate(string data)
        {
            List<string> strings = ToList(data);
            List<string> formula = ListFormula(strings);
            return CalculateForfulu(formula);
        }
        private List<string> ToList(string str)
        {
            List<string> res = new();
            str = str.Replace(",", ".").ToLower();
            string digit = "", function = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]) || str[i].Equals('.'))
                {
                    digit = $"{digit}{str[i]}";
                    if (function.Length > 0)
                    {
                        res.Add(function);
                        function = "";
                    }
                }
                else if (char.IsLetter(str[i]))
                {
                    function = $"{function}{str[i]}";
                    if (digit.Length > 0)
                    {
                        res.Add(digit);
                        digit = "";
                    }
                }
                else if (Settings.OperationPriority.ContainsKey(str[i].ToString()))
                {
                    if (function.Length > 0)
                    {
                        res.Add(function);
                        function = "";
                    }
                    else if (digit.Length > 0)
                    {
                        res.Add(digit);
                        digit = "";
                    }
                    res.Add(str[i].ToString());
                }
                else if (str[i].Equals(')'))
                {
                    if (function.Length > 0)
                    {
                        res.Add(function);
                        function = "";
                    }
                    else if (digit.Length > 0)
                    {
                        res.Add(digit);
                        digit = "";
                    }
                    res.Add(str[i].ToString());
                }
            }
            if (function.Length > 0)
            {
                res.Add(function);
            }
            else if (digit.Length > 0)
            {
                res.Add(digit);
            }
            return res;
        }
        private List<string> ListFormula(List<string> data)
        {
            List<string> res = new();
            Stack<string> functions = new();
            for (int i = 0; i < data.Count; i++)
            {
                if (double.TryParse(data[i], NumberStyles.Number, CultureInfo.InvariantCulture, out _))
                {
                    res.Add(data[i]);
                }
                else if (data[i].Equals("("))
                {
                    if (i > 0 && (data[i - 1].Equals(")") ||
                        double.TryParse(data[i - 1], NumberStyles.Number, CultureInfo.InvariantCulture, out _)))
                    {
                        functions.Push("*");
                    }
                    functions.Push("(");
                }
                else if (data[i].Equals(")"))
                {
                    string func = "";
                    while (functions.Count > 0 && !(func = functions.Pop()).Equals("("))
                    {
                        res.Add(func);
                    }
                }
                else if (!(functions.Count > 0
                   && Settings.OperationPriority[data[i]] < Settings.OperationPriority[functions.Peek()]))
                {
                    functions.Push(data[i]);
                }
                else if (functions.Count > 0)
                {
                    while (functions.Count > 0 &&
                        Settings.OperationPriority[data[i]] <= Settings.OperationPriority[functions.Peek()])
                    {
                        res.Add(functions.Pop());
                    }
                    functions.Push(data[i]);
                }
            }
            while (functions.Count > 0)
            {
                res.Add(functions.Pop());
            }
            return res;
        }
        private double CalculateForfulu(List<string> data)
        {
            Stack<double> digits = new();
            foreach (string str in data)
            {
                if (double.TryParse(str, NumberStyles.Number, CultureInfo.InvariantCulture, out double val))
                {
                    digits.Push(val);
                }
                else
                {
                    CalculateFunction(str, ref digits);
                }
            }
            if (digits.Count != 1) throw new ArgumentException("плмилка у формулi");
            return digits.Pop();
        }
        private void CalculateFunction(string function, ref Stack<double> data)
        {
            switch (function)
            {
                case "+":
                    data.Push(data.Pop() + data.Pop());
                    break;
                case "-":
                    data.Push(data.Pop() - data.Pop());

                    break;
                case "*":
                    data.Push(data.Pop() * data.Pop());

                    break;
                case "/":
                    double a = data.Pop();
                    double b = data.Pop();
                    if (a == 0) throw new ArgumentException("дiлення на 0");
                    data.Push(b / a);
                    break;
                case "^":
                    data.Push(Math.Pow(data.Pop(), data.Pop()));
                    break;
                case "√":
                    data.Push(Math.Sqrt(data.Pop()));
                    break;
                case "sin":
                    data.Push(Math.Sin(data.Pop()));
                    break;
                case "cos":
                    data.Push(Math.Cos(data.Pop()));
                    break;
                default: throw new ArgumentException("невiдомий оператор");
            }
        }
    }
}
