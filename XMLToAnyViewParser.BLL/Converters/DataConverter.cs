using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLToAnyViewParser.Models.ViewModels;

namespace XMLToAnyViewParser.BLL.Converters
{
    public class DataConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(GeneralModel);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = JObject.Load(reader);
            GeneralModel model;
            var vmt = obj["ViewModelType"];
            if (vmt == null)
            {
                throw new ArgumentException("Missing viewModelType", "viewModelType");
            }

            string viewModelType = vmt.Value<string>();
            if (viewModelType == "login")
            {
                model = new LoginViewModel();
            }
            else if (viewModelType == "home")
            {
                model = new HomeViewModel();
            } // ...add other ViewModels
            else
            {
                throw new NotSupportedException("Unknown viewModel type: " + viewModelType);
            }

            serializer.Populate(obj.CreateReader(), model);
            return model;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
