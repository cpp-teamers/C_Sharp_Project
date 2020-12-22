using System;
using System.Xml.Serialization;
using System.IO;
using Library1;
using LibraryMenu;


namespace RepairManModule
{
    public class RepairManDataManager
    {
        string path;
        RepairMan rm;
        XmlSerializer serializer;


        public RepairManDataManager()
        {
            path = @$"..\..\..\..\Data\repairmen";
            serializer = new XmlSerializer(typeof(RepairMan));
            InitData();
            SaveData();
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
            

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                rm = (RepairMan)serializer.Deserialize(fs);
            }
        }
        public void LogIn()
        {
            int chancesToEnterPassword = 3;

            Console.Write("\n>Enter your name: ");
            string name = Console.ReadLine();

            bool succeed_entry = false;

            SaveData();

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
                        Console.Write($"Sorry! Password is incorrect! You got {chancesToEnterPassword} chances");
                    }
                }
                while (chancesToEnterPassword != 0);


                if (succeed_entry)
                {
                    RepairManMenu rmm = new RepairManMenu();
                    rmm.WhenLoggedMenu(ref rm);
                    
                }
            }
            else
            {
                Console.Write($"Sorry! There is no such person.");
            }


        }
        private bool ValidName(string nameInDir)
        {


            string[] files = Directory.GetFiles(path);
            bool isFound = false;

            foreach (string f in files)
            {
                if (f == nameInDir)
                {
                    isFound = true;
                    break;
                }
            }

            return isFound;
        }
        private bool EnterPassword(string nameInDir)
        {
            bool success = false;

            Console.Write("\n>Password:");
            string enteredPassword = Console.ReadLine();

            LoadDataOfRepM(nameInDir);

            if (enteredPassword == rm.AccountData.Password)
            {
                success = true;
            }

            return success;
        }

    }
}

