using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using XMLToAnyViewParser.Common.Exceptions;

namespace XMLToAnyViewParser.Service.Helpers
{
    public class HTTPSRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                throw new AuthenticationException("HTTPS required");
            }
        }
    }
}