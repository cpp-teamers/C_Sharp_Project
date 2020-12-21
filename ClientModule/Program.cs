using System;
using LibraryDialog;

namespace ClientModule
{
    class Program
    {
        static void Main(string[] args)
        {
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
                        Console.WriteLine("1");
                        break;
                    case 2:
                        dataManager.Registration();
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
