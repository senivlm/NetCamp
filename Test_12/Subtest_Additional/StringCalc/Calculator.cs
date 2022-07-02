using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalc
{
    internal class Calculator
    {
        public Dictionary<string, string> functions = new();
        public double Calculate(string data)
        {
            List<string> strings = ToList(data);
            List<string> formula = ListToFormula(strings);
            return CalculateForfulu(formula);
        }
        private List<string> ToList(string str)
        {
            List<string> res = new();
            str = str.Replace(",", ".").ToLower();
            Regex regex = new Regex(@"(\d+(?:[.]\d+)?)|(\w+)|(\S)");
            MatchCollection regexRes = regex.Matches(str);
            foreach (Match m in regexRes) res.Add(m.Value);
            return res;
        }
        private List<string> ListToFormula(List<string> data)
        {

            List<string> functionNames = functions.Keys.ToList();
            List<string> res = new();
            Stack<string> operations = new();
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
                        operations.Push("*");
                    }
                    operations.Push("(");
                }
                else if (data[i].Equals(")"))
                {
                    string func = "";
                    while (operations.Count > 0 && !(func = operations.Pop()).Equals("("))
                    {
                        res.Add(func);
                    }
                }
                else if (functionNames.Count > 0 && functionNames.Contains(data[i]))
                {
                    string funcName = data[i++];
                    if (!data[i].Equals("(")) throw new ArgumentException($"невiрно визвана шункцiя \"{funcName}\"");
                    i++;
                    List<string> funcArguments = new();
                    while (!data[i].Equals(")"))
                    {
                        funcArguments.Add(data[i++]);
                    }
                    List<string> funcFormula = CalculateFunction(funcName, funcArguments);
                    foreach (string formula in funcFormula) res.Add(formula);
                }
                else if (!(operations.Count > 0
                   && Settings.OperationPriority[data[i]] < Settings.OperationPriority[operations.Peek()]))
                {
                    operations.Push(data[i]);
                }

                else if (operations.Count > 0)
                {
                    while (operations.Count > 0 &&
                        Settings.OperationPriority[data[i]] <= Settings.OperationPriority[operations.Peek()])
                    {
                        res.Add(operations.Pop());
                    }
                    operations.Push(data[i]);
                }
            }
            while (operations.Count > 0)
            {
                res.Add(operations.Pop());
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
                    CalculateOperation(str, ref digits);
                }
            }
            if (digits.Count != 1) throw new ArgumentException("пoмилка у формулi");
            return digits.Pop();
        }
        private void CalculateOperation(string operation, ref Stack<double> data)
        {
            switch (operation)
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
        public void AddFunction(string name, string function)
        {
            functions.Add(name, function);
        }
        private List<string> CalculateFunction(string functionName, List<string> arguments)
        {
            string function = functions.GetValueOrDefault(functionName);
            if (string.IsNullOrWhiteSpace(function)) throw new ArgumentException($"функцiя пуста \"{functionName}\"");
            List<string> functionList = ToList(function);
            for (int i = 0; i < functionList.Count; i++)
            {
                switch (functionList[i])
                {
                    case "a":
                        functionList[i] = arguments[0];
                        break;
                    case "b":
                        functionList[i] = arguments[1];
                        break;
                    case "c":
                        functionList[i] = arguments[2];
                        break;
                    case "d":
                        functionList[i] = arguments[3];
                        break;
                    case "e":
                        functionList[i] = arguments[4];
                        break;
                }
            }
            return ListToFormula(functionList);
        }
    }
}
