﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLToAnyViewParser.BLL.Services.Interfaces
{
    public interface IViewPathService
    {
        string GetViewPath(string viewName);
    }
}