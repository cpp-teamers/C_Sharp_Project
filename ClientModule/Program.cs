using System;

namespace ClientModule
{
    class Program
    {
        static void Main(string[] args)
        {
            // ПРОТОТИП 
            char s = 'n';
            // Создание классов
            ClientMenu clientMenu = new ClientMenu();
            do
            {
                Console.Clear();
                clientMenu.StartMenu();
                // 
                Console.Write("   -> "); // Delete
                s = Convert.ToChar(Console.ReadLine()); // Delete
            } while (s == 'y');


            // Finish
            Console.WriteLine("\n Programm finished (0_0)");
        }
    }
}
