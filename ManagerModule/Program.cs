using System;
using LibraryMenu;
using LibraryDialog;
using System.IO;

namespace ManagerModule
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagerMenu menu = new ManagerMenu();
            ManagerDialog dialog = new ManagerDialog();
            
            do
            {
                ManagerMenu.exit = true;
                menu.StartMenu();
                switch (dialog.ChoosenParametr())
                {
                    case 1:
                        do
                        {
                            string login = dialog.LogInDialog();
                            if (Directory.Exists(@$"..\..\..\..\Data\managers\{login}"))
                            {

                            }
                            else
                            {

                            }
                        } while()
                        break;
                    case 2:
                        ManagerMenu.exit = false;
                        break;
                    default:
                        Console.WriteLine("!UNKNOWN PARAMS!");
                        break;
                }
            } while (ManagerMenu.exit && dialog.AllowContinue());
        }
    }
}
