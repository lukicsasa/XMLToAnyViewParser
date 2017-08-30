using System.Linq;
using XMLToAnyViewParser.Common.Exceptions;
using XMLToAnyViewParser.Common.Helpers;
using XMLToAnyViewParser.Data.UnitOfWork;
using XMLToAnyViewParser.Entities;

namespace XMLToAnyViewParser.Common.Managers
{
    public class UserManager
    {
        public static User Login(string username, string password)
        {
            using (var uow = new UnitOfWork())
            {
                if (string.IsNullOrWhiteSpace(username)) throw new ValidationException("You must provide login data!");

                var user = uow.UserRepository.First(u => u.Username.ToLower().Trim() == username.ToLower().Trim());
                if (user == null || !PasswordHelper.ValidatePassword(password, user.Password)) throw new ValidationException("Wrong username or password!");
                return user;
            }
        }
    }
}
