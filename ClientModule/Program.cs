using System;
using LibraryDialog;
using Library1;

namespace ClientModule
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 50);
            // Создание классов
            ClientMenu clientMenu = new ClientMenu();
            ClientDialog clientDialog = new ClientDialog();
            ClientDataManager dataManager = new ClientDataManager();
            Client client = new Client();
            Order order = new Order();
            // bool
            bool exit = false;
            bool LogOut = false;
            int safer = 3; // 3 попытки ввести верный догин и пароль
            // 
            do
            {
                Console.Clear();
                
                clientMenu.StartMenu();
                switch (clientDialog.Choice())
                {
                    case 1:
                        Console.Clear();
                        dataManager.Registration(client);
                        break;
                    case 2:
                        // Ввод данных
                        Console.Write("               Input your id -> ");
                        string id = Console.ReadLine();
                        Console.Write("               Input your password -> ");
                        string password = Console.ReadLine();
                        // Существует ли пользователь с данным id
                        bool access = dataManager.FindDirectory(id);
                        // Загружает данные про клиента 
                        client = dataManager.LoadClient(id);
                        if (access == true && password == dataManager.Password(client))
                        {
                            do
                            {
                                Console.Clear();
                                clientMenu.LogInMenu(client);
                                switch (clientDialog.Choice())
                                {
                                    case 1:
                                        clientDialog.CreateOrder(order);
                                        dataManager.SaveOrder(id, order);
                                        break;
                                    case 2:
                                        dataManager.ShowAllOrders(id);
                                        break;
                                    case 3:
                                        clientMenu.LogOutMenu(client);
                                        LogOut = true;
                                        break;
                                    case 4:
                                        exit = true;
                                        break;
                                }
                            } while (LogOut == false && exit == false && clientDialog.AllowContinue() == 'y');
                        }
                        else
                        {
                            safer--;

                            Console.WriteLine($"\n               Inccorect login or password. {safer} attempts left");
                        }
                        break;
                    case 3:
                        clientMenu.DisplayTypeWork();
                        break;
                    case 4:
                        exit = true;
                        break;
                }
            } while (safer > 0 && exit == false && clientDialog.AllowContinue() == 'y');

            // Finish
            Console.Clear();
            if (safer > 0)
                clientMenu.FinishProgramm();
            else
                clientMenu.BadFinishProgramm();
        }
    }
}
