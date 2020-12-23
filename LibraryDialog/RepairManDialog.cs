﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryMenu;

namespace LibraryDialog
{
    public class RepairManDialog
    {
        
        public char AllowContinue()
        {
                char answer = 'n';
                try
                {
                    Console.Write("               Do you want to continue? (y/n) -> ");
                    answer = Convert.ToChar(Console.ReadLine());
                }
                catch (Exception err)
                {
                    Console.WriteLine($"\n> ERR:{err.Message}");
                }
                return answer;
        }
        public int StartMenuChoice()
        {
            int choice = -1;
            try
            {
                Console.Write("\n               Please, input choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice > 2 || choice < 1)
                    throw new Exception("\n               You have entered an invalid value!");
            }
            catch (Exception err)
            {
                Console.WriteLine($"\n               ERR: {err.Message}");
            }
            return choice;
        }
        public int WhenLoggedMenuChoice()
		{
            int choice = -1;
            try
            {
                Console.Write("\n               Please, input choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice > 3 || choice < 1)
                    throw new Exception("\n               You have entered an invalid value!");
            }
            catch (Exception err)
            {
                Console.WriteLine($"\n               ERR: {err.Message}");
            }
            return choice;
		}
        public int TaskReadynessOptionsMenuChoice()
		{
            int choice = -1;
            try
            {
                Console.Write("\n               Please, input choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice > 3 || choice < 1)
                    throw new Exception("\n               You have entered an invalid value!");
            }
            catch (Exception err)
            {
                Console.WriteLine($"\n               ERR: {err.Message}");
            }
            return choice;
        }
    }

}

