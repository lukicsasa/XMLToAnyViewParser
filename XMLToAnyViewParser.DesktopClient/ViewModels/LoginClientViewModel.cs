using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XMLToAnyViewParser.DesktopClient.Commands;
using XMLToAnyViewParser.DesktopClient.Helpers;
using XMLToAnyViewParser.Models.ViewModels;

namespace XMLToAnyViewParser.DesktopClient.ViewModels
{
    public class LoginClientViewModel : INotifyPropertyChanged
    {
        #region Data members

        private RestClient client;

        private FormLoader formLoader;

        private string username;

        private string password;

        #region Commands

        private ICommand submitCommand;

        #endregion

        #endregion

        #region Constructors

        public LoginClientViewModel()
        {
            this.client = new RestClient();
            this.formLoader = new FormLoader();
        }

        #endregion

        #region Properties

        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                this.username = value;
                RaisePropertyChange();
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
                RaisePropertyChange();
            }
        }

        #endregion

        #region Commands

        public ICommand SubmitCommand
        {
            get
            {
                if (this.submitCommand == null)
                {
                    this.submitCommand = new Command(p => SubmitCommandExecute(), p => SubmitCommandCanExecute());
                }

                return this.submitCommand;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Commands Execute

        private async void SubmitCommandExecute()
        {
            GeneralModel user = new LoginViewModel
            {
                ViewModelType = "login",
                Username = this.Username,
                Password = this.Password
            };

            var response = await client.PostMethodAsync(user, "login");

            if(response.Status == Models.ResponseStatus.Ok)
            {
                new HomeWindow().ShowDialog();
            }

        }

        #endregion

        #region Commands CanExecute

        private bool SubmitCommandCanExecute()
        {
            return Username != string.Empty && Password != string.Empty;
        }

        #endregion

        #region Protected Methods

        protected void RaisePropertyChange([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        #endregion

    }
}
