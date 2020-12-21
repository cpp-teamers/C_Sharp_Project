﻿using System;
using LibraryMenu;
using LibraryDialog;
using System.IO;
using Library1;

namespace ManagerModule
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagerMenu menu = new ManagerMenu();
            ManagerDialog dialog = new ManagerDialog();
            ManagerDataManager dataManager = new ManagerDataManager();
            ManagerMenu.exit = true;

            do
            {
                menu.StartMenu();
                switch (dialog.ChoosenParametr())
                {
                    case 1:
                        ManagerMenu.counterOfIncorrect = 0;
                        do
                        {
                            string login = dialog.LogInDialog();
                            if (Directory.Exists(@$"..\..\..\..\Data\managers\{login}") && dataManager.PasswordIsCorrect(login, dialog.PasswordDialog()))
                            {
                                Manager manager = dataManager.GetManager(login);
                                do
                                {
                                    menu.LogInMenu(manager);
                                    switch (dialog.ChoosenParametr())
                                    {
                                        case 1:

                                            break;
                                        case 2:
                                            break;
                                        case 3:
                                            ManagerMenu.exit = false;
                                            break;
                                        default:
                                            Console.WriteLine("!UNKNOWN PARAMS!");
                                            break;
                                    }

                                } while (ManagerMenu.exit && dialog.AllowContinue());
                            }
                            else
                            {
                                Console.WriteLine($"\n> Login or password is incorrect!!! Left {3 - ManagerMenu.counterOfIncorrect} try");
                                ManagerMenu.counterOfIncorrect++;
                            }
                        } while (ManagerMenu.counterOfIncorrect < 3 && ManagerMenu.exit);
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
