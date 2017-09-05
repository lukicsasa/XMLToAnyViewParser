using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using XMLToAnyViewParser.Common.Exceptions;
using XMLToAnyViewParser.Common.Helpers;
using XMLToAnyViewParser.Common.Models;
using XMLToAnyViewParser.Data.UnitOfWork;
using XMLToAnyViewParser.Entities;
using XMLToAnyViewParser.Service.Helpers;

namespace XMLToAnyViewParser.Service.Controllers
{
    public class UserController : BaseController
    {
        [TokenAuthorize]
        [HttpGet]
        public UserModel Get()
        {
            var userId = CurrentUser.Id;
            using (var uow = new UnitOfWork())
            {
                var user = uow.UserRepository.First(a => a.Id == userId);
                ValidationHelper.ValidateNotNull(user);
                return Mapper.AutoMap<User, UserModel>(user);
            }
        }

        [TokenAuthorize]
        [HttpPut]
        public UserModel Put(UserModel userModel)
        {
            if(userModel.Id != CurrentUser.Id)
                throw new ValidationException("You are not allowed to update this user's details.");

            using (var uow = new UnitOfWork())
            {
                var user = uow.UserRepository.First(a => a.Id == userModel.Id);
                ValidationHelper.ValidateNotNull(user);

                user.Email = userModel.Email;
                user.FirstName = userModel.FirstName;
                user.LastName = userModel.LastName;
                user.Username = userModel.Username;

                uow.Save();
                return Mapper.AutoMap<User, UserModel>(user);
            }
        }
    }
}