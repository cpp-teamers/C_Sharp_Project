﻿using System;
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
            Console.Write("> Choose Params => ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
