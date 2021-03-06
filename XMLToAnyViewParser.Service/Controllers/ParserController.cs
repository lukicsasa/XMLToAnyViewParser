﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XMLToAnyViewParser.Models;
using XMLToAnyViewParser.BLL;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using XMLToAnyViewParser.Models.ViewModels;
using XMLToAnyViewParser.Service.Helpers;

namespace XMLToAnyViewParser.Service.Controllers
{
    public class ParserController : BaseController
    {
        [TokenAuthorize]
        [HttpGet]
        public GetViewResponse Get(string client, string view)
        {
            GetViewResponse response =
                new GetViewResponse { View = XmlToViewParser.Service.ViewsTransformatter.Transform(client, view) };
            return response;
        }

        [AllowAnonymous]
        [HTTPSRequired]
        [HttpGet]
        public IHttpActionResult Get(string client, bool isLogin = true)
        {
            try
            {
                GetViewResponse response =
                    new GetViewResponse { View = XmlToViewParser.Service.ViewsTransformatter.Transform(client, isLogin ? "login" : "register") };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
