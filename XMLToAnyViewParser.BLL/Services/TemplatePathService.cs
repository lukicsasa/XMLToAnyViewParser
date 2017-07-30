using System;
using System.Web;
using XMLToAnyViewParser.BLL.Services.Interfaces;
using XMLToAnyViewParser.Models.Exceptions;

namespace XMLToAnyViewParser.BLL.Services
{
    public class TemplatePathService : ITemplatePathService
    {
        public string GetTemplatePath(string clientType)
        {
            var a = HttpContext.Current.Server.MapPath("~/Data/Templates/WebTemplate.xslt");

            switch (clientType)
            {
                case "web":
                    return HttpContext.Current.Server.MapPath("~/Data/Templates/WebTemplate.xslt");
                case "desktop":
                    return HttpContext.Current.Server.MapPath("~/Data/Templates/DesktopTemplate.xslt");
                case "mobile":
                    return HttpContext.Current.Server.MapPath("~/Data/Templates/MobileTemplate.xslt");
                default:
                    throw new NoneClientException("Client type is unsupported.");
            }
        }
    }
}