using System;
using System.Xml.Serialization;
using System.IO;
using Library1;


namespace RepairManModule
{
    public class RepairManDataManager
    {
        string path;
        RepairMan rm;
        XmlSerializer serializer;


        public RepairManDataManager()
		{
            path = @"../../../../repairmen";
            serializer = new XmlSerializer(typeof(RepairMan));

		}

        private void LoadDataOfRepM(string name)
		{
            path += ('/' + name + ".xml");

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


				if (true)
				{
                    Console.Write("dfdsf");
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
