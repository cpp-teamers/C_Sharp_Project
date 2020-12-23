using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library1;
using LibraryMenu;
using LibraryExceptions;

namespace LibraryDialog
{
    public class ClientDialog
    {
        ClientMenu cm = new ClientMenu();
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
            try
            {
                Console.WriteLine("");
                Console.WriteLine("               ╒════════════════════════════════════════════╕");
                Console.WriteLine("               │     Okay, now input your DATA, please      │");
                Console.WriteLine("               ╘════════════════════════════════════════════╛");
                // Ввод ФИО
                Console.Write("\n               | Name -> ");
                string name = Console.ReadLine();
                Console.Write("               | Surname -> ");
                string surname = Console.ReadLine();
                Console.Write("               | Patronymic -> ");
                string patronymic = Console.ReadLine();
                Console.Write("               | Age -> ");

                if (!Int32.TryParse(Console.ReadLine(), out int age) || age < 3 || age > 150)
                {
                    throw new AgeLimitException("               Invalid age!", Convert.ToString(age));
                }
                // Ввод адресса
                Console.Write("               ────────────────────────────────────────────");
                Console.Write("\n               | City -> ");
                string city = Console.ReadLine();
                Console.Write("               | Street -> ");
                string street = Console.ReadLine();
                Console.Write("               | Number of block -> ");
                string numOfBlock = Console.ReadLine();
                Console.Write("               | Number of apartment -> ");
                if (!Int32.TryParse(Console.ReadLine(), out int numOfApartment) || numOfApartment < 0 || numOfApartment > 1000 )
                {
                    throw new ApartmentException("               Invalid number of apartment!", Convert.ToString(numOfApartment));
                }
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
                Console.WriteLine("               User was successfully created!");
                Console.WriteLine($"\n\n               Welcome, {name,4} {surname,4}");
                // Console.WriteLine("               Press any key to continue.");
                // Console.ReadKey();
            }
            catch (AgeLimitException ale)
            {
                Console.WriteLine($"               Error: {ale.Message}, -> {ale.Parametr}");
            }
            catch (ApartmentException ae)
            {
                Console.WriteLine($"               Error: {ae.Message}, -> {ae.Parametr}");
            }
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
        public void CreateOrder(Order order)
        {

            Console.WriteLine("");
            Console.WriteLine("               ╒════════════════════════════════════════════╕");
            Console.WriteLine("               │       Okay, now fill the form, please      │");
            Console.WriteLine("               ╘════════════════════════════════════════════╛");
            Console.WriteLine("               ______________________________________________");
            Console.Write("               | Describe the order in a few words -> ");

            string describe = Console.ReadLine();
            order.Description = describe;
            // Вывод на экран цены работ
            cm.DisplayTypeWork();
            switch (cm.InputChoiceOrder())
            {
                case 1:
                    order.OrderType = OrderType.HardwareRepair;
                    break;
                case 2:
                    order.OrderType = OrderType.SoftwareRepair;
                    break;
                case 3:
                    order.OrderType = OrderType.Diagnostics;
                    break;
            }
            // Дата окончания действительности заказа
            Console.Write("               Input deadline of the order -> ");
            if (!Int32.TryParse(Console.ReadLine(), out int days))
            {
                Console.WriteLine("               You input invalid number of days! ");
            }
            if(days > 365)
            {
                Console.WriteLine("               Input number of days bigger than 365 days! ");
            }
            else
            {
                order.DeadLine = DateTime.Now.AddDays(days);
            }
            order.Actual = true;
        }
    }
}
