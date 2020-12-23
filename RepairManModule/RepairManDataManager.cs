using System;
using System.Xml.Serialization;
using System.IO;
using Library1;
using LibraryMenu;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace RepairManModule
{
    public class RepairManDataManager
    {
        string path;
        public RepairMan rm;
        List<Order> curr_order;
        XmlSerializer serializer;
        BinaryFormatter bf;

        public RepairManDataManager()
        {
            serializer = new XmlSerializer(typeof(RepairMan));
            bf = new BinaryFormatter();
        }

        public void SaveData()
        {
            path += @"\vasyan.xml";
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                serializer.Serialize(fs, rm);
                Console.WriteLine("\n>Success: Data is saved!");
            }
        }
        private void InitData()
		{
            
            rm = new RepairMan()
            {
                Surname = "vasya",
                Name = "ivan",
                Patronymic = "Ivanovych",
                Age = 37,
                Experience = 12,
                AccountData = new AccountData() { Login = "228Ivan", Password = "50215464" },
                Adress = new Adress()
                {
                    City = "Kyiv",
                    NumOfApartment = 1,
                    NumOfBlock = "10B",
                    Street = "Shewchenka"
                },
                Salary = 1000,
                Rate = 100,
                IsFree = false
            };


        }
        private void LoadDataOfRepM(string name)
        {
            path = @$"..\..\..\..\Data\repairmen\{name}\{name}.xml";
            
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                rm = (RepairMan)serializer.Deserialize(fs);
            }
        }
        private void LoadTasks()
        {
            //List<Order> orders = new List<Order>();
            curr_order = new List<Order>();



            foreach (var path in rm.PathsOfOrders)
			{
                
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    curr_order.Add((Order)bf.Deserialize(fs));
                }
			}

        }
        public void SaveTasks()
        {
            //path += @"\vasyan.xml";
            int j = 0;

            foreach (string p in rm.PathsOfOrders)
            {

                using (FileStream fs = new FileStream(p, FileMode.Open, FileAccess.Write))
                {
                    bf.Serialize(fs, curr_order[j]);
                }
                j++;
            }   
        }


        public bool LogIn()
        {
            int chancesToEnterPassword = 3;

            Console.Write("\n>Enter your name: ");
            string name = Console.ReadLine();
            name = name.ToLower();

            bool succeed_entry = false;


            if (ValidName(name))
            {

                do
                {
                    if (EnterPassword(name))
                    {
                        succeed_entry = true;
                        break;
                    }
                    else
                    {
                        chancesToEnterPassword--;
                        Console.Write($"\nSorry! Password is incorrect! You got {chancesToEnterPassword} chances\n\n");
                    }
                }
                while (chancesToEnterPassword != 0);


            }
            else
            {
                Console.Write($"Sorry! There is no such person.");
            }

            return succeed_entry;
        }
        private bool ValidName(string nameInDir)
        {
            path = @$"..\..\..\..\Data\repairmen\{nameInDir}";
            bool isFound = false;

            if (Directory.Exists(path))
            {

                nameInDir = $@"{nameInDir}.xml";

                DirectoryInfo di = new DirectoryInfo(path);
                FileInfo[] files = di.GetFiles("*.xml");

                string[] files_str = new string[files.Length];



                for (int i = 0; i < files_str.Length; i++)
                {
                    files_str[i] = files[i].Name;
                }

                foreach (string f in files_str)
                {
                    if (nameInDir == f)
                    {
                        isFound = true;
                    }
                }
			}

            return isFound;
        }
        private bool EnterPassword(string nameInDir)
        {

            bool success = false;

            Console.Write("\n>Password: ");
            string enteredPassword = Console.ReadLine();

            LoadDataOfRepM(nameInDir);

            if (enteredPassword == rm.AccountData.Password)
            {
                success = true;
            }

            return success;
        }

        public void DisplayCurrentTasks()
		{

            LoadTasks();

            foreach (var item in curr_order)
			{
                Console.WriteLine(item);
			}
		}

        public void MarkTaskReady()
        {
            try
            {


                Console.Write("\n> What task you would like to mark as ready: ");
                Int32.TryParse(Console.ReadLine(), out int choice);
                //LoadTasks();

                curr_order[choice-1].Actual= false;

                SaveTasks();
            }
            catch (Exception)
            {
                Console.WriteLine("Sorry there is no such position");
            }
        }
        public void MarkInProgress()
        {

            try
            {


                Console.Write("\n> What task you would like to mark as ready: ");
                Int32.TryParse(Console.ReadLine(), out int choice);
                //LoadTasks();

                curr_order[choice - 1].Actual = true;

                SaveTasks();
            }
            catch (Exception)
            {
                Console.WriteLine("Sorry there is no such position");
            }
        }
    }
}

