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

namespace XMLToAnyViewParser.Service.Controllers
{
    [EnableCors(origins: "http://localhost:55899", headers: "*", methods: "*")]
    public class ParserController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(string client, string view)
        {
            try
            {
                GetViewResponse response = new GetViewResponse();

                response.View = XmlToViewParser.Service.ViewsTransformatter.Transform(client, view);

                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        
    }
}
