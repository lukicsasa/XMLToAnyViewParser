using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLToAnyViewParser.BLL.Interfaces
{
    public interface IViewsTransformatter
    {
        string Transform(string clientTemplatePath, string viewPath);
    }
}
