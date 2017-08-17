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
        

        public string GetStatusMessage(ResponseStatus status)
        {
            using (StreamReader r = new StreamReader("config.json"))
            {
                string json = r.ReadToEnd();
                var listOfMessages = JsonConvert.DeserializeObject<List<StatusMessage>>(json);

                var statusMessage = listOfMessages.FirstOrDefault(m => m.Status == status.ToString());
                return statusMessage.Message;
            }
        }
    }
}
