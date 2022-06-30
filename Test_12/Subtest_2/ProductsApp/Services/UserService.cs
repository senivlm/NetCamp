using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Services
{
    public delegate void SendMessageToUser(string message);
    internal class UserService
    {
        public static void SendToConsole(string message) => Console.WriteLine(message);
        public static void SendAlertMessage(string message)
        {
            Console.ForegroundColor= ConsoleColor.Red;
            SendToConsole(message);
            Console.ResetColor();
        }
    }
}
