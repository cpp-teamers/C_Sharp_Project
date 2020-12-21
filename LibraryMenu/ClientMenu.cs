using System;
using Library1;
using System.Text;

public class ClientMenu
{
    public void StartMenu()
    {
        Console.WriteLine("");
        Console.WriteLine(" ╒════════════════════════════════════════════╕");
        Console.WriteLine(" │       We welcome you to the Happy_PC       │");
        Console.WriteLine(" │────────────────────────────────────────────│");
        Console.WriteLine(" │              1. Registration               │");
        Console.WriteLine(" │              2. Log in                     │");
        Console.WriteLine(" │              3. Show price list            │");
        Console.WriteLine(" ╘════════════════════════════════════════════╛");
    }
    public void LogInMenu(Client client)
    {
        Console.WriteLine("╒════════════════════════════════════════════╕");
       Console.WriteLine($"│         Welcome, {client.Name}!            │");
        Console.WriteLine("│────────────────────────────────────────────│");
        Console.WriteLine("│           1. Create new form               │");
        Console.WriteLine("│           2. Show all my orders            │");
        Console.WriteLine("│           3. Log out                       │");
        Console.WriteLine("╘════════════════════════════════════════════╛");
    }
}
