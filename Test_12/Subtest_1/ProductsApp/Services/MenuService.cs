using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Services
{
    internal class MenuService
    {
        public void Start()
        {
            int selectedMenu = -1;
            while(selectedMenu != 0)
            {
                PrintMeny();
                if (!int.TryParse(Console.ReadLine(), out selectedMenu))
                {
                    selectedMenu = -1;
                    Console.WriteLine("Помилка. Повторіть ввод");
                }
                switch (selectedMenu)
                {
                    case 1: Menu1();
                        break;
                    case 2:  Menu2();
                        break;

                }
            }
        }
        private void PrintMeny()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Оберiть пункт меню");
            Console.WriteLine("1 - додавання та вичiтання складiв");
            Console.WriteLine("2 - додана подiя при додаваннi продукту iз невiрною датою");
            Console.WriteLine("0 - Вихiд");
            Console.ResetColor();
        }
        private void Menu1()
        {
            List<Product> list1 = new List<Product> {
               new Product("Meat",12,40),
               new Product("Appes", 2,12),
               new Meat("Pork", 45, 15,new DateTime(2023,05,12), Category.firstSort, Kind.pork),
               new Meat("Beef", 60, 15, new DateTime(2025,05,12),Category.firstSort, Kind.pork)
            };
            List<Product> list2 = new List<Product> {
               new Product("Potato",11,400),
               new Product("Carrot", 12,12),
               new Meat("Pork", 45, 15,new DateTime(2023,05,12), Category.firstSort, Kind.pork),
               new Meat("Beef", 60, 5,new DateTime(2023,05,12),Category.firstSort, Kind.pork)
            };
            Storage storage1 = new Storage(list1);
            Storage storage2 = new Storage(list2);
            Console.WriteLine("Products only in storage1");
            List<Product> minus = storage1 - storage2;
            foreach (Product product in minus)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();
            Console.WriteLine("Products from storage1 which are in storage2");
            List<Product> intersection = storage1 & storage2;
            foreach (Product product in intersection)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();
            Console.WriteLine("Sum products in both storages");
            var plus = storage1 + storage2;
            foreach (var product in plus)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();
        }
        private void Menu2()
        {
            List<Product> list = new List<Product> {
               new Product("Potato",11,400),
               new Product("Carrot", 12,12),
               new Meat("Pork", 45, 15,new DateTime(2023,05,12), Category.firstSort, Kind.pork),
               new Meat("Beef", 60, 5,new DateTime(2023,05,12),Category.firstSort, Kind.pork)
            };
            Storage storage = new Storage(list);
            storage.AddMeat(new Meat("Beef", 60, 15, new DateTime(2022, 05, 12), Category.firstSort, Kind.pork));
            Console.WriteLine();
        }
    }
}
