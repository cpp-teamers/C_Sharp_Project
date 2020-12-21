using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDialog
{
    public class ClientDialog
    {
        public char AllowContinue()
        {
            char answer = 'n';
            try
            {
                Console.Write("  Do you want to continue? (y/n) -> ");
                answer = Convert.ToChar(Console.ReadLine());
            }
            catch(Exception err)
            {
                Console.WriteLine($"\n> ERR:{err.Message}");
            }
            return answer;
        }
        public int Choice()
        {
            int choice = -1;
            try
            {
                Console.Write("\n  Please, input choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice > 3 || choice < 1)
                    throw new Exception("\n> You have entered an invalid value!");
            }
            catch(Exception err)
            {
                Console.WriteLine($"\n> ERR: {err.Message}");
            }
            return choice;
        }
        public bool Success()
        {
            bool success = true;
            return success;
        }
    }
}
