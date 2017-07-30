using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLToAnyViewParser.Common.Exceptions
{
    public class RuntimeException : ApplicationException
    {
        public RuntimeException(string message) : base(message)
        {

        }
    }
}
