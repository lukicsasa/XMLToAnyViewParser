using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLToAnyViewParser.Models.Exceptions
{
    public class BadViewNameException : Exception
    {
        public BadViewNameException()
        {

        }

        public BadViewNameException(string message) : base(message)
        {

        }

        public BadViewNameException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
