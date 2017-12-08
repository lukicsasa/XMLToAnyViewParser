using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using XMLToAnyViewParser.Common.Exceptions;
using XMLToAnyViewParser.Models;
using XMLToAnyViewParser.Service.Controllers;

namespace XMLToAnyViewParser.Service.Helpers
{
    public class TokenAuthorizeAttribute : ActionFilterAttribute
    {

        public string Roles { get; set; }


        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!SkipValidation(actionContext))
            {
                if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
                {
                    throw new AuthenticationException("HTTPS required");
                }

                var authorizationHeader = actionContext.Request.Headers.FirstOrDefault(h => h.Key == "Authorization");
                if (authorizationHeader.Key == null)
                {
                    throw new AuthenticationException("No Authorization header present");
                }

                // Get token from Authorization header
                string tokenString = authorizationHeader.Value.FirstOrDefault();
                if (string.IsNullOrWhiteSpace(tokenString))
                {
                    throw new AuthenticationException("Authorization header cannot be empty");
                }

                // Validate JWT token
                var secretKey = WebConfigurationManager.AppSettings["JwtSecret"];
                UserJwtModel user;

                try
                {
                    user = JWT.JsonWebToken.DecodeToObject<UserJwtModel>(tokenString, secretKey);
                }
                catch (JWT.SignatureVerificationException)
                {
                    throw new AuthenticationException("Invalid token!");
                }

                if (user.ExpirationDate < DateTime.UtcNow)
                {
                    throw new AuthenticationException("Token expired! Please, login again");
                }

                // Validate roles

                // Add current user to base controller
                var controller = actionContext.ControllerContext.Controller as BaseController;
                controller.CurrentUser = user;
            }

            base.OnActionExecuting(actionContext);
        }

        private bool SkipValidation(HttpActionContext actionContext)
        {
            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                   || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }
    }
}