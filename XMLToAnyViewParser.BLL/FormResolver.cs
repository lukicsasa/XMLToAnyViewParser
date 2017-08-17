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

            if(model is LoginViewModel)
            {
                return null;
            }

            switch (formType)
            {
                case "login":

                    LoginViewModel vm = model as LoginViewModel;
                    response.Data = "u did it";
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
