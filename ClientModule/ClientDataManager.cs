using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Library1;
using System.Runtime.Serialization.Formatters.Binary;
using LibraryDialog;

namespace ClientModule
{
    public class ClientDataManager
    {
        private BinaryFormatter bf = new BinaryFormatter();
        private Client client = new Client();
        private ClientDialog clientDialog = new ClientDialog();
        public void Registration(Client client)
        {
            Random random = new Random();
            ClientDialog cd = new ClientDialog();

            string LoginId = Convert.ToString(random.Next(100000, 999999));

            string path = @$"..\..\..\..\Data\clients\{LoginId}";

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
            // Очень важное смс - нужно запомнить свой id для того, чтобы потом залогиниться
            Console.Write($"\n\n Here is your id -> ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{LoginId}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" <- Please, remember that. Press any key to continue.");
            Console.ReadKey();
            // создание папки с названием = id клиента
            DirectoryInfo directoryInfo = Directory.CreateDirectory(Convert.ToString(path));
            // Ввод параметров клиента с консоли
            cd.CreateClient(client, LoginId);
            // Сохранение клиента в dat файл
            SaveClient(path, client);
        }


        public void SaveClient(string path, Client client)
        {
            path += @"\data.dat";
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                bf.Serialize(fs, client);
            }
        }
        public bool FindDirectory()
        {
            bool access = false;
            string id = clientDialog.InputId();
            string path = @"..\..\..\..\Data\clients\";
            DirectoryInfo d = new DirectoryInfo(path);
            DirectoryInfo[] clients = d.GetDirectories(); // Считал название всех файликов
            for (int i = 0; i < clients.Length; i++)
            {
                if(clients[i].Name == id)
                {
                    Console.WriteLine("\n> Папка найдена (0_0)");
                    access = true;
                    break;
                }
            }
            if (!access)
                Console.WriteLine($"\n> Пользователь {id} не найден!");
            return access;
        }
    }
}
