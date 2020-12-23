using System;
using LibraryMenu;
using Library1;
using LibraryDialog;


namespace RepairManModule
{
    class Program
    {
        static void Main(string[] args)
        {
            RepairManDataManager rmdm = new RepairManDataManager();
            RepairManDialog rmd = new RepairManDialog();
            RepairManMenu rmm = new RepairManMenu();

            bool exit = false;
            do
            {
                Console.Clear();
                rmm.StartMenu();

                switch (rmd.StartMenuChoice())
                {
                    case 1:
                        rmdm.LogIn();
                        break;
                    case 2:
                        exit = true;
                        break;
                    default:
                        break;
                }

				

            }
            while (exit == false && rmd.AllowContinue() == 'y' );

        }
	}
}
