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
                        dataManager.FindDirectory();
                        break;
                    case 3:
                        Console.WriteLine("3");
                        break;
                }
            } while (clientDialog.AllowContinue() == 'y');

            // Finish
            Console.Clear();
            clientMenu.FinishProgramm();
        }
    }
}
