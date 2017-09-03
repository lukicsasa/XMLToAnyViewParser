using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace XMLToAnyViewParser.DesktopClient.Helpers
{
    public class FormLoader
    {

        #region Data members

        private RestClient client;

        #endregion

        #region Consturctors

        public FormLoader()
        {
            this.client = new RestClient();
        }

        #endregion

        #region Public methods

        public async void LoadForm(string url, WrapPanel parentElement)
        {
            var response = await client.GetMethodAsync(url);
            var element = (UIElement)XamlReader.Parse(response.View);
            parentElement.Children.Add(element);
        }

        #endregion

    }

}
