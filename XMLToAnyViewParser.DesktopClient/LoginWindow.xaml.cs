using System;
using System.Windows;
using System.Windows.Markup;
using XMLToAnyViewParser.DesktopClient.Helpers;
using XMLToAnyViewParser.DesktopClient.ViewModels;

namespace XMLToAnyViewParser.DesktopClient
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        private FormLoader formLoader;

        public LoginWindow()
        {
            InitializeComponent();

            this.DataContext = new LoginClientViewModel();

            this.formLoader = new FormLoader();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.formLoader.LoadForm("parser/desktop", this.body);
        }
    }
}
