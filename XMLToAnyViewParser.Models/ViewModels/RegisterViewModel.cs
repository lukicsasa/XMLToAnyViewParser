using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLToAnyViewParser.Common.Managers;

namespace XMLToAnyViewParser.Models.ViewModels
{
    public class RegisterViewModel : GeneralModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public override object ResolveForm()
        {
           return UserManager.Register(Username, Password, Email, FirstName, LastName);
        }
    }
}
