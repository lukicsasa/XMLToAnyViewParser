using System;

namespace XMLToAnyViewParser.Models.ViewModels
{
    
    public abstract class GeneralModel
    {
        public string ViewModelType { get; set; }

        public abstract object ResolveForm();
    }
}
