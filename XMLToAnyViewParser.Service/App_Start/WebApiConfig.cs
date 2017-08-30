using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using XMLToAnyViewParser.BLL.Converters;

namespace XMLToAnyViewParser.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var json = config.Formatters.JsonFormatter;

            // Solve reference loop problem
            json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            // Use camel case for json serialization
            json.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

            // Serialize enums as strings
            json.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());

            // Remove xml formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "GetMethodRoute",
                routeTemplate: "api/{controller}/{client}/{view}");
            config.Routes.MapHttpRoute(
                name: "GetLoginPageMethodRoute",
                routeTemplate: "api/{controller}/{client}");

            config.Routes.MapHttpRoute(
                name: "PostMethodRoute",
                routeTemplate: "api/{controller}");
        }
    }
}
