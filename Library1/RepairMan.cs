﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1
{
    public class RepairMan : Employee
    {
        public bool IsFree { get; set; }
        public void DisplayRepairMan()
        {
            DisplayEmployee();
            if (!IsFree)
                Console.WriteLine($"Isn't free!");
            else
                Console.WriteLine($"Is free!");
        }
    }
}
