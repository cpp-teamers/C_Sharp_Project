using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library1;

namespace LibraryMenu
{
    public class DirectorMenu
    {
        private DateTime h = DateTime.Now;
        public void StartMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("               ╒════════════════════════════════════════════╕");
            Console.WriteLine("               │         Welcome you to the Happy_PC        │");
            Console.WriteLine("               │────────────────────────────────────────────│");
            Console.WriteLine("               │                1. Log in                   │");
            Console.WriteLine("               │                2. Exit                     │");
            Console.WriteLine("               ╘════════════════════════════════════════════╛");
        }
        public void LogInMenu()
        {
            Console.WriteLine("               ╒════════════════════════════════════════════╕");
           Console.WriteLine($"               |                    Welcome!                |");
            Console.WriteLine("               │────────────────────────────────────────────│");
            Console.WriteLine("               │              1. Add manager                │");
            Console.WriteLine("               │              2. Add repairMan              │");
            Console.WriteLine("               │              3. Exit                       │");
            Console.WriteLine("               ╘════════════════════════════════════════════╛");
        }

        public void Finish()
        {
            Console.WriteLine("\n");
            Console.WriteLine("               ╒════════════════════════════════════════════╕");
                if (h.Hour >= 4 && h.Hour < 12)
                Console.WriteLine($"               |        GoodBye! Have a good morning        | ");
            else if (h.Hour >= 12 && h.Hour < 17)
                Console.WriteLine($"               |         GoodBye! Have a good day           | ");
            else if (h.Hour >= 17 && h.Hour < 24)
                Console.WriteLine($"               |        GoodBye! Have a good evening        | ");
            else if (h.Hour >= 0 && h.Hour < 4 || h.Hour == 24)
                Console.WriteLine($"               |         GoodBye! Have a good night         | ");
            Console.WriteLine("               ╘════════════════════════════════════════════╛");
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

        }
        /*public void AddManagerMenu(Manager manager)
        {
            Console.WriteLine("");
            Console.WriteLine("               ╒════════════════════════════════════════════╕");
            Console.WriteLine("               │   Okay, now input manager DATA, please     │");
            Console.WriteLine("               ╘════════════════════════════════════════════╛");

        }*/

    }
}
