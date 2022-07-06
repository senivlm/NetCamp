using StringCalc.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalc
{
    internal class Calculator
    {
        public Dictionary<string, string> functions = new();
        private Dictionary<string, double> variables = new();
        public double Calculate(string data)
        {
            variables = new();
            List<string> strings = ToList(data);
            List<string> formula = ListToFormula(strings);
            SetVariablesValue();
            return CalculateFormulu(formula);
        }
        private List<string> ToList(string str)
        {
            List<string> res = new();
            str = str.Replace(", ", ";").Replace(",", ".").ToLower();
            Regex regex = new Regex(@"(\d+(?:[.]\d+)?)|(\w+)|(\S)");
            MatchCollection regexRes = regex.Matches(str);
            foreach (Match m in regexRes) res.Add(m.Value);
            return FixNegativeDigits(res);
        }
        private List<string> FixNegativeDigits(List<string> data)
        {
            List<string> res = new();
            if (!data.Contains("-")) return data;
            List<string> symbols = new() { "(", "+", "-", "*", "/", "^", "√" };
            for (int i = 0; i < data.Count; i++)
            {
                if (i == 0 && data[i].Equals("-"))
                {
                    i++;
                    res.Add($"-{data[i]}");
                }
                else if (symbols.Contains(data[i]) && data[i + 1].Equals("-"))
                {
                    res.Add(data[i]);
                    i++; i++;
                    res.Add($"-{data[i]}");
                }
                else
                {
                    res.Add(data[i]);
                }
            }
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
                else if (data[i].Equals(";")) { }
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

                else if (Settings.OperationPriority.ContainsKey(data[i]) && !(operations.Count > 0
                   && Settings.OperationPriority[data[i]] <= Settings.OperationPriority[operations.Peek()]))
                {
                    operations.Push(data[i]);
                }
                else if (IsMathOperation(data[i]))
                {
                    operations.Push(data[i]);
                    AddMathFunction(data[i]);
                }
                else if (!Settings.OperationPriority.ContainsKey(data[i]))
                {
                    res.Add(data[i]);
                    variables.Add(data[i], 0);
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
        private double CalculateFormulu(List<string> data)
        {
            Stack<double> digits = new();
            foreach (string str in data)
            {
                if (double.TryParse(str, NumberStyles.Number, CultureInfo.InvariantCulture, out double val))
                {
                    digits.Push(val);
                }
                else if (variables.Count > 0 && variables.ContainsKey(str))
                {
                    digits.Push(variables[str]);
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
                    data.Push(-(data.Pop() - data.Pop()));

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
                    double c = data.Pop();
                    double d = data.Pop();
                    data.Push(Math.Pow(d, c));
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
                default:
                    if (IsMathOperation(operation)) CalculateMathOperation(operation, ref data);
                    break;
            }
        }
        private void CalculateMathOperation(string operationName, ref Stack<double> data)
        {
            operationName = char.ToUpper(operationName[0]) + operationName.Substring(1);
            Type? myType = typeof(Math);
            MethodInfo[] methods = myType.GetMethods();
            MethodInfo? method = methods.ToList().Where(m => m.Name.Equals(operationName)
                    && m.ReturnType == typeof(double)).FirstOrDefault();
            if (method == null) throw new ArgumentException("Wrong function Name");
            int paramCount = method.GetParameters().Length;
            if (paramCount > data.Count) throw new ArgumentException($"uncorrect parameters count in function {operationName}");
            object[] methodParams = new object[paramCount];
            for (int i = 0; i < paramCount; i++) methodParams[i] = data.Pop();
            data.Push((double)method.Invoke(null, methodParams));
        }
        private bool IsMathOperation(string name)
        {
            string operationName = char.ToUpper(name[0]) + name.Substring(1);
            Type? myType = typeof(Math);
            MethodInfo[] methods = myType.GetMethods();
            return methods.ToList().Where(m => m.Name.Equals(operationName)
                    && m.ReturnType == typeof(double)).FirstOrDefault() != null;
        }
        public void AddFunction(string name, string function)
        {
            functions.Add(name, function);
        }
        public void AddMathFunction(string name, int priority = Settings.NewOperationPriority)
        {
            Settings.OperationPriority.Add(name, priority);
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
        private void SetVariablesValue()
        {
            if (variables.Count > 0)
            {
                foreach (var variable in variables)
                {
                    string valStr = "";
                    double val = 0;
                    do
                    {
                        PrintService.Print($"Додайте значення змiнної \"{variable.Key}\"");
                        valStr = PrintService.ReadLine();
                    } while (!double.TryParse(valStr, out val));
                    variables[variable.Key] = val;
                }
            }
        }
    }
}
