using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1
{
    [Serializable]
    public enum OrderType { Diagnostics = 900, SoftwareRepair = 300, HardwareRepair = 600}
    [Serializable]
    public class Order
    {
        public OrderType OrderType { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; } = DateTime.Now;
        public bool Actual { get; set; } = true;
        public override string ToString()
        {
            return $"\n Order type: {OrderType}." +
                $"\n {Description}." +
                $"\n Expiration date: {DeadLine}.";
        }
    }
}
