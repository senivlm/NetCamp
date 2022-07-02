using System;

namespace StringCalc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new();
            string formula = "1+2.1(3 + .4) * 5=";
            try
            {
                Console.WriteLine($"Формула - {formula} = {calculator.Calculate(formula)}");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            Console.WriteLine();
            formula = "cos((0.14+3)*2)+2";
            try
            {
                Console.WriteLine($"Формула - {formula} = {calculator.Calculate(formula)}");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            Console.WriteLine();
            Console.WriteLine("Введiть вашу фомулу");
            formula = Console.ReadLine();
            try
            {
                Console.WriteLine($"Формула - {formula} = {calculator.Calculate(formula)}");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
