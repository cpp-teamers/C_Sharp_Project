using System;
using LibraryMenu;

namespace ManagerModule
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagerMenu menu = new ManagerMenu();
            do
            {
                ManagerMenu.exit = true;
                menu.StartMenu();
                switch (menu.ChoosenParametr())
                {
                    case 1:

                        break;
                    case 2:
                        ManagerMenu.exit = false;
                        break;
                    default:
                        Console.WriteLine("!UNKNOWN PARAMS!");
                        break;
                }
            } while (ManagerMenu.exit && menu.AllowContinue());
        }
    }
}
