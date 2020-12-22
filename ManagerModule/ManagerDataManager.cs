using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.IO;
using Library1;

namespace ManagerModule
{
    class ManagerDataManager
    {
        private string path_managers = @"..\..\..\..\Data\menegers\";
        private string path_clients = @"..\..\..\..\Data\clients\";
        private BinaryFormatter bf = new BinaryFormatter();

        public bool PasswordIsCorrect(string login, string password)
        {
            string path = path_clients + login + @"\" + "data.dat";
            Manager manager = null;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                manager = (Manager)bf.Deserialize(fs);
            }
            return (password == manager.AccountData.Password);
        }

        public Manager GetManager(string login)
        {
            string path = path_clients + login + @"\" + "data.dat";
            Manager manager = null;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                manager = (Manager)bf.Deserialize(fs);
            }
            return manager;
        }

        public List<Order> GetNotDistributedOrders(string login) // достроить логику
        {
            DirectoryInfo di = new DirectoryInfo(path_clients);
            DirectoryInfo[] directories = di.GetDirectories();
            FileInfo[] files = null;

            List<Order> orders = new List<Order>();
            string path;
            Order order = null;

            foreach(var directory in directories)
            {
                files = di.GetFiles("^[0-9]$.dat");
                foreach (var file in files)
                {
                    path = file.FullName;
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        order = (Order)bf.Deserialize(fs);
                        if (order.Actual)
                            orders.Add(order);
                    }
                }
            }
            return orders;
        }
    }
}
