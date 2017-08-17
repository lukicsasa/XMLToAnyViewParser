using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLToAnyViewParser.Models;
using XMLToAnyViewParser.Models.ViewModels;

namespace XMLToAnyViewParser.BLL.Interfaces
{
    public interface IFormResolver
    {
        FormSubmitResponseJson ResolveForm(GeneralModel model, string formType);
    }
}
