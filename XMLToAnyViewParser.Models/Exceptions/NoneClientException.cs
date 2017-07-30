using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLToAnyViewParser.Models.Exceptions
{
    public class NoneClientException : Exception
    {
        public NoneClientException()
        {

        }

        public NoneClientException(string message) : base(message)
        {

        }

        public NoneClientException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
