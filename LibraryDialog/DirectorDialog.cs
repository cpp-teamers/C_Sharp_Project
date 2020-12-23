using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library1;

namespace LibraryDialog
{
    public class DirectorDialog
    {
        public int Choice()
        {
            int choice = -1;
            try
            {
                Console.Write("\n               Please, input choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice > 2 || choice < 1)
                    throw new Exception("\n               You have entered an invalid value!");
            }
            catch (Exception err)
            {
                Console.WriteLine($"\n               ERR: {err.Message}");
            }
            return choice;
        }
        public int ChoiceAfter()
        {
            int choice = -1;
            try
            {
                Console.Write("\n               Please, input choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice > 3 || choice < 1)
                    throw new Exception("\n               You have entered an invalid value!");
            }
            catch (Exception err)
            {
                Console.WriteLine($"\n               ERR: {err.Message}");
            }
            return choice;
        }
        public char AllowContinue()
        {
            char answer = 'n';
            try
            {
                Console.Write("               Do you want to continue? (y/n) -> ");
                answer = Convert.ToChar(Console.ReadLine());
            }
            catch (Exception err)
            {
                Console.WriteLine($"\n> ERR:{err.Message}");
            }
            return answer;
        }
        public void CreateManager(Manager manager, string LoginId)
        {
            Console.WriteLine("");
            Console.WriteLine("               ╒════════════════════════════════════════════╕");
            Console.WriteLine("               │   Okay, now input manager DATA, please     │");
            Console.WriteLine("               ╘════════════════════════════════════════════╛");
            // Ввод ФИО
            Console.Write("\n               | Name -> ");
            string name = Console.ReadLine();
            Console.Write("               | Surname -> ");
            string surname = Console.ReadLine();
            Console.Write("               | Patronymic -> ");
            string patronymic = Console.ReadLine();
            Console.Write("               | Age -> ");
            int age = Convert.ToInt32(Console.ReadLine());

            // Ввод адресса
            Console.Write("               ────────────────────────────────────────────");
            Console.Write("\n               | City -> ");
            string city = Console.ReadLine();
            Console.Write("               | Street -> ");
            string street = Console.ReadLine();
            Console.Write("               | Number of block -> ");
            string numOfBlock = Console.ReadLine();
            Console.Write("               | Number of apartment -> ");
            int numOfApartment = Convert.ToInt32(Console.ReadLine());
            //
            Console.WriteLine("               ────────────────────────────────────────────");
            Console.Write("               | Input experience -> ");
            int exprience = Convert.ToInt32(Console.ReadLine());
            Console.Write("               | Input salary ($) -> ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());
            // Ввод пароля
            Console.Write("               ────────────────────────────────────────────");
            Console.Write("\n               | Password -> ");
            string password = Console.ReadLine();
            // Присваивание параметров классу менеджера
            manager.AccountData = new AccountData() { Login = LoginId, Password = password };
            manager.Name = name;
            manager.Surname = surname;
            manager.Patronymic = patronymic;
            manager.Adress = new Adress() { City = city, Street = street, NumOfBlock = numOfBlock, NumOfApartment = numOfApartment };
            manager.Age = age;
            manager.Rate = 8.0;
            manager.Salary = salary;

            Console.WriteLine($"\n               Manager {name, 4} {surname, 7} was successfully created!");
            // Console.WriteLine("               Press any key to continue.");
            // Console.ReadKey();

        }
        public void CreateRepairMan(RepairMan repairMan)
        {
            Console.WriteLine("");
            Console.WriteLine("               ╒════════════════════════════════════════════╕");
            Console.WriteLine("               │   Okay, now input repair man DATA, please  │");
            Console.WriteLine("               ╘════════════════════════════════════════════╛");
            // Ввод ФИО
            Console.Write("\n               | Name -> ");
            string name = Console.ReadLine();
            Console.Write("               | Surname -> ");
            string surname = Console.ReadLine();
            Console.Write("               | Patronymic -> ");
            string patronymic = Console.ReadLine();
            Console.Write("               | Age -> ");
            int age = Convert.ToInt32(Console.ReadLine());

            // Ввод адресса
            Console.Write("               ────────────────────────────────────────────");
            Console.Write("\n               | City -> ");
            string city = Console.ReadLine();
            Console.Write("               | Street -> ");
            string street = Console.ReadLine();
            Console.Write("               | Number of block -> ");
            string numOfBlock = Console.ReadLine();
            Console.Write("               | Number of apartment -> ");
            int numOfApartment = Convert.ToInt32(Console.ReadLine());
            //
            Console.WriteLine("               ────────────────────────────────────────────");
            Console.Write("               | Input experience -> ");
            int exprience = Convert.ToInt32(Console.ReadLine());
            Console.Write("               | Input salary ($) -> ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());
            // Ввод пароля
            Console.Write("               ────────────────────────────────────────────");
            Console.Write("\n               | Login -> ");
            string LoginId = Console.ReadLine();
            Console.Write("\n               | Password -> ");
            string password = Console.ReadLine();
            // Присваивание параметров классу менеджера
            repairMan.AccountData = new AccountData() { Login = LoginId, Password = password };
            repairMan.Name = name;
            repairMan.Surname = surname;
            repairMan.Patronymic = patronymic;
            repairMan.Adress = new Adress() { City = city, Street = street, NumOfBlock = numOfBlock, NumOfApartment = numOfApartment };
            repairMan.Age = age;
            repairMan.Rate = 8.0;
            repairMan.Salary = salary;
            repairMan.PathsOfOrders = new List<string>();

            Console.WriteLine($"\n               Manager {name,4} {surname,7} was successfully created!");
        }

    }
}
