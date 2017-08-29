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
        private RestClient client;

        public LoginWindow()
        {
            InitializeComponent();

            this.DataContext = new LoginClientViewModel();

            this.client = new RestClient();
        }




        private async void LoadForm()
        {
            try
            {
                var response = await client.GetMethodAsync("parser/desktop");


                var element = (FrameworkElement)XamlReader.Parse(response.View);
                //element.BeginInit();
                //element.DataContext = new LoginClientViewModel();

                ////element.Measure(new Size())

                //element.EndInit();
                //element.UpdateLayout();

                this.gridBody.Children.Add(element);



                this.btn.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.LoadForm();
        }
    }
}
