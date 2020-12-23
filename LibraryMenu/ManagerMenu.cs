using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library1;

namespace LibraryMenu
{
    public class ManagerMenu
    {
        public static bool exit;
        public static int counterOfIncorrect;
        public void StartMenu()
        {
            Console.Clear();
            Console.WriteLine("╒════════════════════════════════════════════╕");
            Console.WriteLine("│       We welcome you to the ManagerModule  │");
            Console.WriteLine("│                                            │");
            Console.WriteLine("│             1. Log in                      │");
            Console.WriteLine("│             2. Exit                        │");
            Console.WriteLine("│                                            │");
            Console.WriteLine("╘════════════════════════════════════════════╛");
        }

        public void LogInMenu(Person person)
        {
            Console.Clear();
            Console.WriteLine($"            Welcome, {person.Name}!            ");
            Console.WriteLine("╒════════════════════════════════════════════╕");
            Console.WriteLine("│                                            │");
            Console.WriteLine("│          1. Display not distributed orders │");
            Console.WriteLine("│          2. Distribute orders              │");
            Console.WriteLine("│          3. Exit                           │");
            Console.WriteLine("│                                            │");
            Console.WriteLine("╘════════════════════════════════════════════╛");
        }

        
    }
}
