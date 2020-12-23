using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExceptions
{
    public class BaseException : ApplicationException
    {
        public string Parametr { get; set; }
        public BaseException(string message, string parametr) : base(message)
        {
            Parametr = parametr;
        }
    }
}
