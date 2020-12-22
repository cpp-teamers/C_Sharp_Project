using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1
{
    [Serializable]
    public struct Adress
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string NumOfBlock { get; set; }
        public int NumOfApartment { get; set; }
        public override string ToString()
        {
            return $"City: {City}" +
                $"\n Place of residence: {Street},{NumOfBlock}, ap.{NumOfApartment}.";
        }
    }
    [Serializable]
    public struct AccountData
    {
        public string Password { get; set; }
        public string Login { get; set; }
    }
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; } // Отчество
        public int Age { get; set; }
        public Adress Adress { get; set; }
        public AccountData AccountData { get; set; }
        public void DisplayPerson()
        {
            Console.WriteLine($" -> {Name} {Surname} {Patronymic} <-");
            Console.WriteLine($" Age: {Age} y.o.");
            Console.WriteLine(Adress);
        }
    }
}
