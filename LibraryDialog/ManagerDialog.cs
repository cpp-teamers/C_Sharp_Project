using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDialog
{
    public class ManagerDialog
    {
        public bool AllowContinue()
        {
            Console.Write("\n Continue?(y/n) => ");
            return Convert.ToChar(Console.ReadLine()) == 'y';
        }

        public int ChoosenParametr()
        {
            Console.Write("\n> Choose Params => ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public string LogInDialog()
        {
            Console.Write("\n Input login => ");
            return Convert.ToString(Console.ReadLine());
        }

        public string PasswordDialog()
        {
            Console.Write("\n Input password => ");
            return Convert.ToString(Console.ReadLine());
        }

        public int ChoosenOrders()
        {
            Console.Write("\n> Choose Order, Which you want to distribute => ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public int ChoosenRepairs()
        {
            Console.Write("\n> Choose RepairMen, to whom you want distribute order => ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
