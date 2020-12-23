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
            SaveClient(client);
        }
        public void SaveClient(Client client)
        {
            string path = @$"..\..\..\..\Data\clients\{client.AccountData.Login}\data.dat";
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                bf.Serialize(fs, client);
            }
        }
        public Client LoadClient(string id)
        {
            Client client = new Client();

            if(FindDirectory(id) == true)
            { 
                string path = @$"..\..\..\..\Data\clients\{id}\data.dat";
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    client = (Client)bf.Deserialize(fs);
                }
            }
            return client;
        }
        public bool FindDirectory(string id)
        {
            string path = @$"..\..\..\..\Data\clients\";
            bool access = false;
            DirectoryInfo d = new DirectoryInfo(path);
            DirectoryInfo[] clients = d.GetDirectories(); // Считал название всех файликов
            for (int i = 0; i < clients.Length; i++)
            {
                if(clients[i].Name == id)
                {
                    access = true;
                    break;
                }
            }
            return access;
        }
        public string Password(Client client)
        {
            return client.AccountData.Password;
        }
        public void ShowAllOrders(string id)
        {
            string path = @$"..\..\..\..\Data\clients\{id}\";
            Order order = new Order();
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles("*.dat");

            if (files.Length == 1)
                Console.WriteLine("\n               You haven't got any orders yet!");
            else
            {
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].Name != "data.dat")
                    {
                        path = @$"..\..\..\..\Data\clients\{id}\{files[i].Name}";
                        order = LoadOrder(path);
                        Console.Write($"{i + 1} -> {order.Description}, {order.DeadLine.Date.Year}.{order.DeadLine.Date.Month}.{order.DeadLine.Date.Day}");
                        if (!order.Actual)
                            Console.WriteLine($"  Oder is done");
                        else
                            Console.WriteLine($"  Oder isn't done");
                    }
                }
            }
        }
        public void SaveOrder(string id, Order order)
        {
            string path = @$"..\..\..\..\Data\clients\{id}\";
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles("*.dat");

            int fileCounter = 1;
            string FileName = $"{fileCounter}.dat";
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Name != "data.dat" && files[i].Name != FileName)
                {
                    break;
                }
                else
                {
                    fileCounter++;
                    FileName = $"{fileCounter}.dat";
                }
            }
            FileName = $"{fileCounter}.dat";
            // Окончательный путь файла
            path += $"{FileName}";
            // Запись заказа
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                bf.Serialize(fs, order);
            }
            Console.WriteLine("               Order was successfully created! ");
        }
        public Order LoadOrder(string path)
        {
            Order order = new Order();
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
               order  = (Order)bf.Deserialize(fs);
            }
            return order;
        }
    }
}
