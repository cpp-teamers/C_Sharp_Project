using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryExceptions;

namespace LibraryDialog
{
    public class ManagerDialog
    {
        public bool AllowContinue()
        {
            try
            {
                Console.Write("\n Continue?(y/n) => ");
                string choose = Console.ReadLine();
                if (!Char.TryParse(choose, out char ans))
                {
                    throw new CharException("Incorrect symbol", choose);
                }
                return (ans == 'y');
            }
            catch(BaseException err)
            {
                Console.WriteLine($"\n CharException: {err.Message}");
                Console.WriteLine($" InvalidateValue: {err.Parametr}");
                Console.WriteLine("\n Press any key");
                Console.ReadKey();
                return false;
            }
        }

        public int ChoosenParametr()
        {
            try
            {
                Console.Write("\n> Choose Params => ");
                string choose = Console.ReadLine();
                if (!Int32.TryParse(choose, out int ans))
                {
                    throw new IntException("Incorrect symbol", choose);
                }
                return ans;
            }
            catch(BaseException err)
            {
                Console.WriteLine($"\n IntException: {err.Message}");
                Console.WriteLine($" InvalidateValue: {err.Parametr}");
                Console.WriteLine("\n Press any key");
                Console.ReadKey();
                return 0;
            }
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
            try
            {
                Console.Write("\n> Choose Order, Which you want to distribute => ");
                string choose = Console.ReadLine();
                if(!Int32.TryParse(choose, out int ans))
                {
                    throw new IntException("Incorrect symbol", choose);
                }
                return ans;
            }
            catch(BaseException err)
            {
                Console.WriteLine($"\n IntException: {err.Message}");
                Console.WriteLine($" InvalidateValue: {err.Parametr}");
                Console.WriteLine("\n Press any key");
                Console.ReadKey();
                return 0;
            }
        }

        public int ChoosenRepairs()
        {
            try
            {
                Console.Write("\n> Choose RepairMen, to whom you want distribute order => ");
                string choose = Console.ReadLine();
                if(!Int32.TryParse(choose, out int ans))
                {
                    throw new IntException("Incorrect symbol", choose);
                }
                return ans;
            }
            catch(BaseException err)
            {
                Console.WriteLine($"\n IntException: {err.Message}");
                Console.WriteLine($" InvalidateValue: {err.Parametr}");
                Console.WriteLine("\n Press any key");
                Console.ReadKey();
                return 0;
            }
        }
    }
}
