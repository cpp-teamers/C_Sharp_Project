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
            bool exit = false;
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
                        Console.Write("               Input your id -> ");
                        string id = Console.ReadLine();
                        // Загружает данные про клиента 
                        client = dataManager.LoadClient(id);
                        bool access = dataManager.FindDirectory(id);
                        Console.Write("               Input your password -> ");
                        string password = Console.ReadLine();
                        if (access == true && password == dataManager.Password(client))
                        {
                            do
                            {
                                Console.Clear();
                                clientMenu.LogInMenu(client);
                                switch (clientDialog.Choice())
                                {
                                    case 1:
                                        Console.WriteLine("1");
                                        break;
                                    case 2:
                                        Console.WriteLine("2");
                                        break;
                                    case 3:
                                        Console.WriteLine("3");
                                        break;
                                    case 4:
                                        exit = true;
                                        break;
                                }
                            } while (exit == false && clientDialog.AllowContinue() == 'y');
                        }
                        break;
                    case 3:
                        Console.WriteLine("3");
                        break;
                    case 4:
                        exit = true;
                        break;
                }
            } while (exit == false && clientDialog.AllowContinue() == 'y');

            // Finish
            Console.Clear();
            clientMenu.FinishProgramm();
        }
    }
}
