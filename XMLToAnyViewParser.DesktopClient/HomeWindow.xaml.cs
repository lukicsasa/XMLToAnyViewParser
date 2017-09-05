using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using XMLToAnyViewParser.DesktopClient.Helpers;
using XMLToAnyViewParser.DesktopClient.ViewModels;

namespace XMLToAnyViewParser.DesktopClient
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        private FormLoader formLoader;

        public HomeWindow()
        {
            InitializeComponent();

            this.formLoader = new FormLoader();
            this.DataContext = new HomeClientViewModel(GlobalData.User);
        }

        private void HomeWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            this.formLoader.LoadForm("parser/desktop/home", this.body);
        }

        
        protected override void OnClosed(EventArgs e)
        {
            GlobalData.Token = string.Empty;
            base.OnClosed(e);
        }
    }
}
