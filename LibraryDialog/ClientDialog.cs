using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library1;

namespace LibraryDialog
{
    public class ClientDialog
    {
        public char AllowContinue()
        {
            char answer = 'n';
            try
            {
                Console.Write("               Do you want to continue? (y/n) -> ");
                answer = Convert.ToChar(Console.ReadLine());
            }
            catch(Exception err)
            {
                Console.WriteLine($"\n> ERR:{err.Message}");
            }
            return answer;
        }
        public void CreateClient(Client client, string LoginId)
        {

            Console.WriteLine("");
            Console.WriteLine("               ╒════════════════════════════════════════════╕");
            Console.WriteLine("               │     Okay, now input your DATA, please      │");
            Console.WriteLine("               ╘════════════════════════════════════════════╛");
            // Ввод ФИО
            Console.Write("\n               |Name -> ");
            string name = Console.ReadLine();
            Console.Write("               |Surname -> ");
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
            // Ввод пароля
            Console.Write("               ────────────────────────────────────────────");
            Console.Write("\n               | Password -> ");
            string password = Console.ReadLine();
            // Присваивание параметров классу клиента
            client.AccountData = new AccountData() { Login = LoginId, Password = password };
            client.Name = name;
            client.Surname = surname;
            client.Patronymic = patronymic;

            client.Adress = new Adress() { City = city, Street = street, NumOfBlock = numOfBlock, NumOfApartment = numOfApartment };
            client.Age = age;
            Console.WriteLine($"\n\n               Welcome, {name,4} {surname,4}");
            Console.WriteLine("               Press any key to continue.");
            Console.ReadKey();
        }
        public int Choice()
        {
            int choice = -1;
            try
            {
                Console.Write("\n               Please, input choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice > 4 || choice < 1)
                    throw new Exception("\n               You have entered an invalid value!");
            }
            catch (Exception err)
            {
                Console.WriteLine($"\n               ERR: {err.Message}");
            }
            return choice;
        }
    }
}
