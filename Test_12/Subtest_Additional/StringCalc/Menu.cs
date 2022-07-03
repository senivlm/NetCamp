using StringCalc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc
{
    internal class Menu
    {
        private Calculator calculator;
        public Menu()
        {
            calculator = new Calculator();
        }
        public void Start()
        {
            int selectedMenu = -1;
            while (selectedMenu != 0)
            {
                PrintService.PrintGreen(PrintMenu());
                if (!int.TryParse(Console.ReadLine(), out selectedMenu))
                {
                    selectedMenu = -1;
                    PrintService.PrintAllert("Помилка. Повторіть ввод");
                }
                switch (selectedMenu)
                {
                    case 1:
                        Menu1();
                        break;
                    case 2:
                        Menu2();
                        break;
                    case 3:
                        Menu3();
                        break;

                }
            }
            PrintService.PrintGreen(PrintMenu());
        }
        private string PrintMenu()
        {
            string res = "Оберiть пункт меню\r\n";
            res = $"{res} 1 -  тестовi завдання на калькуляторi\r\n";
            res = $"{res} 2 -  ввести формулу вручну\r\n";
            res = $"{res} 3 -  ввести формулу з функцiями\r\n";
            res = $"{res} 0 -  Вихiд\r\n";
            return res;
        }
        private string PrintSubMenu3()
        {
            string res = "Оберiть пiдпункт меню \"ввести формулу з функцiями\"\r\n";
            res = $"{res} 1 -  додати функцiю\r\n";
            res = $"{res} 2 -  ввести формулу та порахувати\r\n";
            res = $"{res} 0 -  назад\r\n";
            return res;
        }
        private void Menu1()
        {
            Calculator calculator = new();
            string formula = "max( 1 2.51)*(3 + 0.4) * 5";
            try
            {
                PrintService.Print($"Формула - {formula} = {calculator.Calculate(formula).ToString("0.###")}");
            }
            catch (Exception ex) { PrintService.PrintAllert(ex.Message); }
            PrintService.Print("");
            formula = "cos((0.14 +3)* 2)+2";
            try
            {
                PrintService.Print($"Формула - {formula} = {calculator.Calculate(formula).ToString("0.###")}");
            }
            catch (Exception ex) { PrintService.PrintAllert(ex.Message); }
        }
        private void Menu2()
        {
            PrintService.Print("Введiть вашу фомулу");
            string formula = Console.ReadLine();
            try
            {
                PrintService.Print($"Формула - {formula} = {calculator.Calculate(formula)}");
            }
            catch (Exception ex) { PrintService.PrintAllert(ex.Message); }
        }
        private void Menu3()
        {
            int selectedSubMenu = -1;
            while (selectedSubMenu != 0)
            {
                PrintService.PrintGreen(PrintSubMenu3());
                if (!int.TryParse(Console.ReadLine(), out selectedSubMenu))
                {
                    selectedSubMenu = -1;
                    PrintService.PrintAllert("Помилка. Повторіть ввод");
                }
                switch (selectedSubMenu)
                {
                    case 1:
                        Submenu31();
                        break;
                    case 2:
                        Menu2();
                        break;
                }
            }

        }
        private void Submenu31()
        {
            PrintService.Print("введiть назву функцiї (лише буквами)");
            string name = PrintService.ReadLine();
            PrintService.Print("введiть  функцiю з аргументами (a b c d e) через пробiл, максимум 5, або без.");
            PrintService.Print("Якщо вводите лише один аргумент, то це буде \'a\', 2 -> \'a\' та \'b\'...");
            string func = PrintService.ReadLine();
            calculator.functions.Add(name, func);
        }
    }
}
