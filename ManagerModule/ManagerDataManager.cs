using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.IO;
using Library1;
using System.Xml.Serialization;

namespace ManagerModule
{
    class ManagerDataManager
    {
        private string path_managers = @"..\..\..\..\Data\managers\";
        private string path_clients = @"..\..\..\..\Data\clients\";
        private string path_repairs = @"..\..\..\..\Data\repairmen\";
        private BinaryFormatter bf = new BinaryFormatter();
        private XmlSerializer xml = new XmlSerializer(typeof(RepairMan));

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

        public SortedList<string, Order> GetNotDistributedOrders()
        {
            DirectoryInfo di = new DirectoryInfo(path_clients);
            DirectoryInfo[] directories = di.GetDirectories();
            FileInfo[] files = null;

            SortedList<string, Order> orders = new SortedList<string, Order>();
            string path;
            Order order = null;

            foreach(var directory in directories)
            {
                files = directory.GetFiles("?.dat");
                foreach (var file in files)
                {
                    path = path_clients + directory.Name+ @"\" + file.Name;
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        order = (Order)bf.Deserialize(fs);
                        if (order.Actual)
                            orders.Add(path, order);
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

        public SortedList<string, RepairMan> GetRepairsMan()
        {
            DirectoryInfo di = new DirectoryInfo(path_repairs);
            DirectoryInfo[] directories = di.GetDirectories();
            FileInfo[] files = null;

            SortedList<string, RepairMan> repairs = new SortedList<string, RepairMan>();
            string path;
            RepairMan repair = null;

            foreach(var directory in directories)
            {
                files = directory.GetFiles("*.xml");
                path = path_repairs + directory.Name + @"\" + files[0].Name;
                using(FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    repair = (RepairMan)xml.Deserialize(fs);
                    repairs.Add(path, repair);
                }
            }
            return repairs;
        }

        public void SaveRepairMan(RepairMan repair, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Write))
            {
                xml.Serialize(fs, repair);
            }
        }


    }
}
