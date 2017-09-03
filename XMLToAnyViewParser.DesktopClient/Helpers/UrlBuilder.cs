using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLToAnyViewParser.DesktopClient.Helpers
{
    public static class UrlBuilder
    {
        private static readonly string URL = "https://localhost:44326/api/";

        public static Uri GetUrl(string url)
        {
            return new Uri(URL + url);
        }
    }
}

