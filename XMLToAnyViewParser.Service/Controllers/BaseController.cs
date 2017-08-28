using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using XMLToAnyViewParser.BLL.Managers;
using XMLToAnyViewParser.Service.Models;

namespace XMLToAnyViewParser.Service.Controllers
{
    public class BaseController : ApiController
    {
        internal UserJwtModel CurrentUser { get; set; }

        private UserManager _userManager;
        public UserManager UserManager => _userManager ?? (_userManager = new UserManager());
    }
}