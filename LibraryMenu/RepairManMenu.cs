using System;
using Library1;


namespace LibraryMenu
{
	public class RepairManMenu
	{
        public void StartMenu()
        {
            Console.WriteLine(" ╒════════════════════════════════════════════╕");
            Console.WriteLine(" │    Welcome to system. Authorize please     │");
            Console.WriteLine(" │────────────────────────────────────────────│");
            Console.WriteLine(" │              1. Log in                     │");
            Console.WriteLine(" │              2. Exit                       │");
            Console.WriteLine(" ╘════════════════════════════════════════════╛");
        }
        public void WhenLoggedMenu(ref RepairMan repairMan)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"           Welcome, {repairMan.Name}!        ");
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
