using System;
using Library1;
using System.Text;

public class ClientMenu
{
    public void StartMenu()
    {
        Console.WriteLine("");
        Console.WriteLine("               ╒════════════════════════════════════════════╕");
        Console.WriteLine("               │       We welcome you to the Happy_PC       │");
        Console.WriteLine("               │────────────────────────────────────────────│");
        Console.WriteLine("               │              1. Registration               │");
        Console.WriteLine("               │              2. Log in                     │");
        Console.WriteLine("               │              3. Show price list            │");
        Console.WriteLine("               │              4. Exit                       │");
        Console.WriteLine("               ╘════════════════════════════════════════════╛");
    }
    public void LogInMenu(Client client)
    {
        Console.WriteLine("               ╒════════════════════════════════════════════╕");
       Console.WriteLine($"                         Welcome, {client.Name}!            ");
        Console.WriteLine("               │────────────────────────────────────────────│");
        Console.WriteLine("               │           1. Create new order              │");
        Console.WriteLine("               │           2. Show all my orders            │");
        Console.WriteLine("               │           3. Log out                       │");
        Console.WriteLine("               │           4. Exit                          │");
        Console.WriteLine("               ╘════════════════════════════════════════════╛");
    }
    public void FinishProgramm()
    {
        Console.WriteLine("\n");
        Console.WriteLine("        ╒══════════════════════════════════════════════════════════════╕");
        Console.WriteLine("        │ GoodBye. Thanks for choosing us. With best regards, Happy_PC │");
        Console.WriteLine("        ╘══════════════════════════════════════════════════════════════╛");
        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
    }
    public void BadFinishProgramm()
    {
        Console.WriteLine("\n");
        Console.WriteLine("        ╒══════════════════════════════════════════════════════════════╕");
        Console.WriteLine("        │            No attempts left. Please, try later.              │");
        Console.WriteLine("        ╘══════════════════════════════════════════════════════════════╛");
        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
    }
    public void LogOutMenu(Client client)
    {
        Console.WriteLine("               ╒════════════════════════════════════════════╕");
        Console.WriteLine($"                         GoodBye, {client.Surname} {client.Name}!      ");
        Console.WriteLine("               ╘════════════════════════════════════════════╛");
    }
    public void DisplayTypeWork()
    {
        Console.Write("                _______________________________________");
        Console.WriteLine("\n               | Choose what do you want us to do: ");
        Console.Write("               | 1. Hardware repair -> ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("600");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\n               | 2. Software repair -> ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("300");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\n               | 3. Diagnostics     -> ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("900");
        Console.ForegroundColor = ConsoleColor.White;
    }
    public int InputChoiceOrder()
    {
        int choice = 0;
        try
        {
            Console.Write("               -> ");
            choice = Convert.ToInt32(Console.ReadLine());
            if (choice > 3 || choice < 0)
                Console.WriteLine("               You input incorrect choice!");
        }
        catch (Exception err)
        {
            Console.WriteLine($"ERR: {err.Message}");
        }
        return choice;
    }

}
