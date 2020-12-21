using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1
{
    [Serializable]
    public class Client : Person
    {
        public void DisplayClient()
        {
            DisplayPerson();
        }
    }
}
