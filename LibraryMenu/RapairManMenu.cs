using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library1;


namespace LibraryMenu
{
	class RapairManMenu
	{
        public void StartMenu()
        {
            Console.WriteLine("");
            Console.WriteLine(" ╒════════════════════════════════════════════╕");
            Console.WriteLine(" │       We welcome you to the Happy_PC       │");
            Console.WriteLine(" │────────────────────────────────────────────│");
            Console.WriteLine(" │              1. Log in                     │");
            Console.WriteLine(" │              2. Exit                       │");
            Console.WriteLine(" ╘════════════════════════════════════════════╛");
        }

        public void WhenLoggedMenu(ref RepairMan repairMan)
        {
            Console.WriteLine($"         Welcome, {repairMan.Name}!          ");
            Console.WriteLine("╒════════════════════════════════════════════╕");
            Console.WriteLine("│────────────────────────────────────────────│");
            Console.WriteLine("│           1. Display current task          │");
            Console.WriteLine("│           2. Task readyness                │");
            Console.WriteLine("│           3. Log out                       │");
            Console.WriteLine("╘════════════════════════════════════════════╛");
        }

        public void TaskReadynessOptionsMenu()
        {
            Console.WriteLine("╒════════════════════════════════════════════╕");
            Console.WriteLine("│────────────────────────────────────────────│");
            Console.WriteLine("│           1. Task in progress              │");
            Console.WriteLine("│           2. Task is done                  │");
            Console.WriteLine("│           3. Back                          │"); // Back to When logged menu
            Console.WriteLine("╘════════════════════════════════════════════╛");
        }

    }
}
