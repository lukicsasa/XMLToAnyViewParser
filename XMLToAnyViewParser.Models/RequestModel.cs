using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLToAnyViewParser.Models
{
    public class RequestModel
    {
        public string Client { get; set; }

        public string ViewName { get; set; }

        public object Data { get; set; }
    }
}
