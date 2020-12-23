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
						if (rmdm.LogIn())
						{
                            bool try_again = false;
                            do
                            {

                                rmm.WhenLoggedMenu(ref rmdm.rm);

								switch (rmd.WhenLoggedMenuChoice())
								{
                                    case 1:
                                        rmdm.DisplayCurrentTasks();
                                        break;
                                    case 2:
										{
                                            rmm.TaskReadynessOptionsMenu();
											switch (rmd.TaskReadynessOptionsMenuChoice())
											{
                                                case 1:
                                                    {
                                                        rmdm.MarkTaskReady();
                                                    }
                                                    break;
                                                case 2:
                                                    {
                                                        rmdm.MarkInProgress();
                                                    }
                                                    break;
                                                default:
													break;
											}
										}
                                        break;
                                    case 3:
                                        exit = true;
                                        break;
									default:
                                        {
                                            try_again = rmd.TryAgain();
                                            break;
                                        }
								}

								
                            } while (!exit && try_again);

                        }
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
