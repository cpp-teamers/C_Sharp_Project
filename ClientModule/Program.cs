using System;
using LibraryDialog;

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
            // 
            do
            {
                Console.Clear();
                
                clientMenu.StartMenu();
                switch (clientDialog.Choice())
                {
                    case 1:
                        Console.Clear();
                        dataManager.Registration();
                        break;
                    case 2:
                        Console.WriteLine("2");
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
