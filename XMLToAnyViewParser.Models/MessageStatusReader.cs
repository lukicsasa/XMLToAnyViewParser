using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace XMLToAnyViewParser.Models
{
    public class MessageStatusReader
    {
        

        public List<StatusMessage> GetStatusMessageList()
        {
            using (StreamReader r = new StreamReader("config.json"))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<StatusMessage>>(json);
            }
        }
    }
}
