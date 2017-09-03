using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLToAnyViewParser.Models.ViewModels
{
    
    public class HomeViewModel : GeneralModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public override object ResolveForm()
        {
            throw new NotImplementedException();
        }
    }
}
