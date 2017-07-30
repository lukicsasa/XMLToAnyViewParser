using System.Web;
using XMLToAnyViewParser.BLL.Services.Interfaces;
using XMLToAnyViewParser.Models.Exceptions;

namespace XMLToAnyViewParser.BLL.Services
{
    public class ViewPathService : IViewPathService
    {
        public string GetViewPath(string viewName)
        {
            
            switch (viewName)
            {
                case "login":
                    return HttpContext.Current.Server.MapPath("~/Data/Views/LoginView.xml");
                
                default:
                    throw new BadViewNameException("View name is unsupported.");
            }
        }
    }
}