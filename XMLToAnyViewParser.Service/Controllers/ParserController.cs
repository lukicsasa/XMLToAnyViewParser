using System;
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
    public class ParserController : ApiController
    {
        [TokenAuthorize]
        [HttpGet]
        public IHttpActionResult Get(string client, string view)
        {
            try
            {
                GetViewResponse response =
                    new GetViewResponse {View = XmlToViewParser.Service.ViewsTransformatter.Transform(client, view)};

                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult GetLoginPage(string client)
        {
            try
            {
                GetViewResponse response =
                    new GetViewResponse {View = XmlToViewParser.Service.ViewsTransformatter.Transform(client, "login")};
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
