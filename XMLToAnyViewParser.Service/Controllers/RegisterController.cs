using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using XMLToAnyViewParser.BLL;
using XMLToAnyViewParser.Models.ViewModels;

namespace XMLToAnyViewParser.Service.Controllers
{
    public class RegisterController : ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult Post([FromBody]RegisterViewModel requestData)
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