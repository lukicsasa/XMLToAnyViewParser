using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XMLToAnyViewParser.Models;
using XMLToAnyViewParser.BLL;
using System.Web.Http.Cors;

namespace XMLToAnyViewParser.Service.Controllers
{
    [EnableCors(origins: "http://localhost:55899", headers: "*", methods: "*")]
    public class ParserController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(string client, string view)
        {
            GetViewResponse response = new GetViewResponse();

            response.ViewHTML = XmlToViewParser.Service.ViewsTransformatter.Transform(client, view);

            return Ok(response);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] RequestModel request)
        {
            return Ok();
        }
    }
}
