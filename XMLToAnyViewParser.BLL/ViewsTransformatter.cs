using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using XMLToAnyViewParser.BLL.Interfaces;

namespace XMLToAnyViewParser.BLL
{
    public class ViewsTransformatter : IViewsTransformatter
    {
        public string Transform(string client, string viewName)
        {
            var clientPath = XmlToViewParser.Service.TemplateService.GetTemplatePath(client);
            var viewPath = XmlToViewParser.Service.ViewService.GetViewPath(viewName);

            StringWriter result = new StringWriter();
            XslCompiledTransform transformXML = new XslCompiledTransform();
            transformXML.Load(clientPath);
            XPathDocument xpathdocument = new XPathDocument(viewPath);
            XmlTextWriter writer = new XmlTextWriter(result);
            writer.Formatting = Formatting.Indented;
            transformXML.Transform(xpathdocument, null, writer, null);
            return result.ToString();
        }
    }
}
