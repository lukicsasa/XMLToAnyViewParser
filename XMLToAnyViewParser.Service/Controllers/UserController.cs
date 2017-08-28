using System;
using System.Web.Configuration;
using System.Web.Mvc;
using XMLToAnyViewParser.BLL.Managers;
using XMLToAnyViewParser.Common.Helpers;
using XMLToAnyViewParser.Common.Models;
using XMLToAnyViewParser.Entities;
using XMLToAnyViewParser.Service.Models;

namespace XMLToAnyViewParser.Service.Controllers
{
    public class UserController : Controller
    {
        [AllowAnonymous]
        [HttpPost]
        public object Login(LoginModel model)
        {
            User user = UserManager.Login(model.Email, model.Password);
            UserModel userModel = Mapper.Map(user);
            return new { User = userModel, Token = CreateLoginToken(user) };
        }

        [NonAction]
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