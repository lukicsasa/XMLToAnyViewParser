using System;

namespace XMLToAnyViewParser.Models.ViewModels
{
    
    public class LoginViewModel : GeneralModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public override object ResolveForm()
        {
            if(Username == "aa" && Password == "aa")
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
