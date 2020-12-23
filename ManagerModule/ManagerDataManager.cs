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
        private string path_managers = @"..\..\..\..\Data\managers\";
        private string path_clients = @"..\..\..\..\Data\clients\";
        private string path_repairs = @"..\..\..\..\Data\repairmen\";
        private BinaryFormatter bf = new BinaryFormatter();

        public bool PasswordIsCorrect(string login, string password)
        {
            string path = path_managers + login + @"\" + "data.dat";
            Manager manager = null;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                manager = (Manager)bf.Deserialize(fs);
            }
            return (password == manager.AccountData.Password);
        }

        public Manager GetManager(string login)
        {
            string path = path_managers + login + @"\" + "data.dat";
            Manager manager = null;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                manager = (Manager)bf.Deserialize(fs);
            }
            return manager;
        }

        public SortedList<Order, string> GetNotDistributedOrders()
        {
            DirectoryInfo di = new DirectoryInfo(path_clients);
            DirectoryInfo[] directories = di.GetDirectories();
            FileInfo[] files = null;

            SortedList<Order, string> orders = new SortedList<Order, string>();
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
                            orders.Add(order, path);
                    }
                }
            }
            return orders;
        }

        public void SaveOrder(Order order, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Write))
            {
                bf.Serialize(fs, order);
            }
        }

        public SortedList<RepairMan, string> GetRepairsMan()
        {
            DirectoryInfo di = new DirectoryInfo(path_repairs);
            DirectoryInfo[] directories = di.GetDirectories();
            FileInfo[] files = null;

            SortedList<RepairMan, string> repairs = new SortedList<RepairMan, string>();
            string path;
            RepairMan repair = null;

            foreach(var directory in directories)
            {
                files = di.GetFiles("*.dat");
                path = files[0].FullName;
                using(FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    repair = (RepairMan)bf.Deserialize(fs);
                    repairs.Add(repair, path);
                }
            }
            return repairs;
        }

        public void SaveRepairMan(RepairMan repair, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Write))
            {
                bf.Serialize(fs, repair);
            }
        }


    }
}
