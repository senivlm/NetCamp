using ProductsApp.Models;
using ProductsApp.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProductsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
           MenuService menuService = new MenuService();
            menuService.Start();
        }
    }
}
