﻿using System;
using LibraryMenu;
using LibraryDialog;
namespace DirectorModule
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 50);
            DirectorMenu directorMenu = new DirectorMenu();
            DirectorDialog directorDialog = new DirectorDialog();
            DirectorDataManager dataManager = new DirectorDataManager();
            Director director = new Director();
            // bool
            bool exit = false;
            int safer = 3; // 3 попытки ввести верный догин и пароль
            do
            {
                Console.Clear();

                directorMenu.StartMenu();
                switch (directorDialog.Choice())
                {
                    case 1:
                        //dataManager.SaveDATA();
                        // Ввод данных
                        Console.Write("               Input your name -> ");
                        string name = Console.ReadLine();
                        Console.Write("               Input your password -> ");
                        string password = Console.ReadLine();
                        // Загружает данные про директора 
                        director = dataManager.LoadDirector();
                        if (name == director.Name && password == director.Password)
                        {
                            do
                            {
                                Console.Clear();
                                directorMenu.LogInMenu();
                                switch (directorDialog.ChoiceAfter())
                                {
                                    case 1:
                                        //.CreateOrder(order);
                                        // dataManager.SaveOrder(id, order);
                                        dataManager.AddManager();
                                        Console.WriteLine("1");
                                        break;
                                    case 2:
                                        //dataManager.ShowAllOrders(id);
                                        Console.WriteLine("2");

                                        break;
                                    case 3:
                                        //clientMenu.LogOutMenu(client);
                                        Console.WriteLine("3");

                                        break;
                                    case 4:
                                        Console.WriteLine("");
                                        break;
                                    case 5:
                                        exit = true;
                                        break;
                                }
                            } while (exit == false && directorDialog.AllowContinue() == 'y');
                        }
                        else
                        {
                            safer--;
                            Console.WriteLine($"\n               Inccorect login or password. {safer} attempts left");
                        }
                        break;
                    case 2:
                        exit = true;
                        break;
                }
            } while (exit == false && directorDialog.AllowContinue() == 'y');
            // Finsih ->
            Console.Clear();
            directorMenu.Finish();
        }
    }
}
