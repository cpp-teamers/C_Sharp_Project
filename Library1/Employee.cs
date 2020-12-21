using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1
{
    [Serializable]
    public class Employee : Person
    {
        public decimal Salary { get; set; }
        public double Rate { get; set; }
        public int Experience { get; set; } // Сколько лет работает на данную компанию
        public void DisplayEmployee()
        {
            DisplayPerson();
            Console.WriteLine($" Salary: {Salary}$");
            Console.WriteLine($" Rate: {Rate}.");
            Console.WriteLine($" Experience: {Experience} years");
        }
    }
}
