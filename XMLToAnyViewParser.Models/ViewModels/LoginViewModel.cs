using System;
using System.Web.Configuration;
using XMLToAnyViewParser.Common.Helpers;
using XMLToAnyViewParser.Common.Managers;
using XMLToAnyViewParser.Common.Models;
using XMLToAnyViewParser.Entities;

namespace XMLToAnyViewParser.Models.ViewModels
{
    
    public class LoginViewModel : GeneralModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public override object ResolveForm()
        {
            User user = UserManager.Login(Username, Password);
            return new { User = user, Token = CreateLoginToken(user) };
        }

        private string CreateLoginToken(User user)
        {
            UserJwtModel userModel = Mapper.AutoMap<User, UserJwtModel>(user);
            userModel.ExpirationDate = DateTime.UtcNow.AddDays(1);

            string secretKey = WebConfigurationManager.AppSettings["JwtSecret"];
            string token = JWT.JsonWebToken.Encode(userModel, secretKey, JWT.JwtHashAlgorithm.HS256);
            return token;
        }
    }
}
