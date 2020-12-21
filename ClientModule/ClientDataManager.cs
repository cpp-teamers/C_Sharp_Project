using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Library1;

namespace ClientModule
{
    class ClientDataManager
    {
        public void Registration()
        {
            Random random = new Random();

            string LoginId = Convert.ToString(random.Next(100000, 999999));

            string path = @$"..\..\..\..\Data\clients\{LoginId}";
            Console.WriteLine($"!!!PATH: {path}");

            int counterRescuer = 0; // Для предотвращения замыкания цикла while
            while (Directory.Exists(path))
            {
                LoginId = Convert.ToString(random.Next(100000, 999999));
                path = @$"..\..\..\..\Data\clients\{LoginId}";
                Console.WriteLine($" PATH2: {path}"); // !!!!!!!!!!
                // 
                counterRescuer++;
                if (counterRescuer == 999999)
                {
                    Console.WriteLine("ADMIIIIIN"); // Notifier !!!!!!!!!!!!
                    break;
                }
            }
            DirectoryInfo directoryInfo = Directory.CreateDirectory(Convert.ToString(path));
            Console.WriteLine("\n> Directory was successfully added!");
            
            Console.WriteLine("\n Input Password -> ");
            /*string password = Console.ReadLine();
            Client client = new Client()
            {
                new AccountData() { Login = LoginId, Password = password },
            }*/
        }
    }
}
