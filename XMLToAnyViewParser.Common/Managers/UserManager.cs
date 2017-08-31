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

                var user = uow.UserRepository.Find(u => u.Username.ToLower().Trim() == username.ToLower().Trim()).FirstOrDefault();
                if (user == null || !PasswordHelper.ValidatePassword(password, user.Password)) throw new ValidationException("Wrong username or password!");
                return user;
            }
        }

        public static User Register(string username, string password, string email, string firstName, string lastName)
        {
            using (var uow = new UnitOfWork())
            {
                var user = uow.UserRepository.Find(u => u.Username.ToLower().Trim() == username.ToLower().Trim()).FirstOrDefault();
                if (user != null) throw new ValidationException("Username already taken!");

                user = new User
                {
                    Username = username,
                    Password = PasswordHelper.CreateHash(password),
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email
                };
                
                uow.UserRepository.Insert(user);
                uow.Save();
                return user;
            }
        }
    }
}
