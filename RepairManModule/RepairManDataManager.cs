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

        public void LogIn()
		{
            int chancesToEnterPassword = 3;

            Console.Write("\n>Enter your name: ");
            string name = Console.ReadLine();



            if (ValidName(name))
            {
				if (EnterPassword(name))
				{

				}
			}
			else
			{
                Console.Write($"Sorry! There is no such repairman.");
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
            bool failed = false;

            Console.Write("\n>Password:");
            string enteredPassword = Console.ReadLine();
            LoadDataOfRepM(nameInDir);

			if (enteredPassword == rm.AccountData.Password)
			{
                failed = true;
			}

            return failed;
		}


        private void LoadDataOfRepM(string name)
		{
            path += ('/' + name + ".xml");

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                rm = (RepairMan)serializer.Deserialize(fs);
            }
		}

    }
}
