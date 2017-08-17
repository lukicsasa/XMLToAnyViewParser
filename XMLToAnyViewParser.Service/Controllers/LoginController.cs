using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using XMLToAnyViewParser.BLL;
using XMLToAnyViewParser.Models.ViewModels;

namespace XMLToAnyViewParser.Service.Controllers
{
    [EnableCors(origins: "http://localhost:55899", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {

        [HttpPost]
        public IHttpActionResult Post([FromBody]LoginViewModel requestData)
        {

            try
            {
                GeneralModel data = requestData;

                var response = XmlToViewParser.Service.FormResolver.ResolveForm(data, data.ViewModelType);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
