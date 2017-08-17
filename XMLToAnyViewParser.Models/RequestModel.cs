using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLToAnyViewParser.Models.ViewModels;

namespace XMLToAnyViewParser.Models
{
    [Serializable]
    public class RequestModel
    {
        public string Client { get; set; }

        public string FormType { get; set; }

        public GeneralModel Data { get; set; }
    }
}
