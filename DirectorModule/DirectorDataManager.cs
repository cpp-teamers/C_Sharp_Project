using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Library1;
using LibraryDialog;

namespace DirectorModule
{
    class DirectorDataManager
    {
        private BinaryFormatter bf = new BinaryFormatter();
        // Пути к файлам
        readonly private string directorPath = @"..\..\..\directorData.dat";
        readonly private string managerPath = @"..\..\..\..\Data\managers\";
        readonly private string repairManPath = @"..\..\..\..\Data\repairmen\";

        private XmlSerializer serializer = new XmlSerializer(typeof(RepairMan));
        private Director director = new Director();
        private List<Manager> managers = new List<Manager>();
        private List<RepairMan> repairMen = new List<RepairMan>();
        private DirectorDialog directorDialog = new DirectorDialog();
        // Добавление менеджера
        public void AddManager()
        {
            Random random = new Random();
            Manager manager = new Manager();

            string LoginId = Convert.ToString(random.Next(100000, 999999));
            string path = @$"..\..\..\..\Data\managers\{LoginId}\";

            int counterRescuer = 0;
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
            // Очень важное смс - нужно запомнить id менеджера для того, чтобы он потом смог залогиниться
            Console.Write($"\n\n Here is manager id -> ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{LoginId}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" <- Please, remember that. Press any key to continue.");
            Console.ReadKey();
            // Создание папки с названием = id менеджера
            DirectoryInfo directoryInfo = Directory.CreateDirectory(Convert.ToString(path));
            // Ввод параметров менеджера с консоли
            directorDialog.CreateManager(manager, LoginId);
            // Сохранение клиента в dat файл
            SaveManager(manager, LoginId);

        }
        // Добавление менеджера
        public void AddRepairMan()
        {
            Random random = new Random();

            RepairMan repairMan = new RepairMan();
            directorDialog.CreateRepairMan(repairMan);

            string path = @$"..\..\..\..\Data\repairmen\{repairMan.Name}\";
            string name = $@"{repairMan.Name}";
            int counterRescuer = 0;
            while (Directory.Exists(path))
            {
                name = $@"{repairMan.Name}{counterRescuer++}";
                path = @$"..\..\..\..\Data\repairmen\{name}";
                // 
                counterRescuer++;
                if (counterRescuer == 999999)
                {
                    Console.WriteLine("ADMIIIIIN"); // Notifier !!!!!!!!!!!!
                    break;
                }
            }
            // Очень важное смс - нужно запомнить id менеджера для того, чтобы он потом смог залогиниться
            Console.Write($"\n\n Here is manager id -> ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{repairMan.Name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" <- Please, remember that. Press any key to continue.");
            Console.ReadKey();
            // Создание папки с названием = id менеджера
            DirectoryInfo directoryInfo = Directory.CreateDirectory(Convert.ToString(path));
            // Сохранение клиента в dat файл
            SaveRepairMan(repairMan, name);

        }

        public void SaveManager(Manager manager, string LoginId)
        { 
            string path = @$"..\..\..\..\Data\managers\{LoginId}\data.dat";
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                bf.Serialize(fs, manager);
            }
        }
        public void SaveRepairMan(RepairMan repairMan, string name)
        {
            string path = @$"..\..\..\..\Data\repairmen\{repairMan.Name}\{name}.xml";
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fs, repairMan);
            }
        }





        // Загрузка параметров нового директора. Выполняется 1 раз!
        /*public void SaveDATA()
        {
            director.Name = "Director_HappyPC";
            director.Password = "adminHappyPC";

            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                bf.Serialize(fs, director);
            }
            Console.WriteLine("\n Все ок");
        }*/
        // Загрузка параметров директора с directorData.dat
        public Director LoadDirector()
        {
            Director director = new Director();
            using (FileStream fs = new FileStream(directorPath, FileMode.Open, FileAccess.Read))
            {
                director = (Director)bf.Deserialize(fs);
            }
            return director;
        }

    }
}
