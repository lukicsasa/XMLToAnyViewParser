using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLToAnyViewParser.BLL.Interfaces;
using XMLToAnyViewParser.Models;
using XMLToAnyViewParser.Models.ViewModels;

namespace XMLToAnyViewParser.BLL
{
    public class FormResolver : IFormResolver
    {
        private MessageStatusReader messageStatusReader = new MessageStatusReader();

        public FormSubmitResponseJson ResolveForm(GeneralModel model, string formType)
        {
            FormSubmitResponseJson response = new FormSubmitResponseJson();

            switch (formType)
            {
                case "login":

                    response.Data = model.ResolveForm();
                    response.Status = ResponseStatus.Ok;
                    //response.Message = messageStatusReader.GetStatusMessage(response.Status);

                    return response;

                case "home":

                    return response;

            }

            response.Status = ResponseStatus.Unknown;
            response.Data = null;
            response.Message = messageStatusReader.GetStatusMessage(response.Status);

            return response;
        }
        
    }
}
