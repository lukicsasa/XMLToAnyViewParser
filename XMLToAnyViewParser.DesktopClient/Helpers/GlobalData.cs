using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLToAnyViewParser.Entities;

namespace XMLToAnyViewParser.DesktopClient.Helpers
{
    public static class GlobalData
    {
        public static string Token { get; set; } = string.Empty;

        public static User User { get; set; }
    }
}
