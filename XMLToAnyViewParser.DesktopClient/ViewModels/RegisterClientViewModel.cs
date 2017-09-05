using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using XMLToAnyViewParser.DesktopClient.Commands;
using XMLToAnyViewParser.DesktopClient.Helpers;
using XMLToAnyViewParser.Models.ViewModels;

namespace XMLToAnyViewParser.DesktopClient.ViewModels
{
    public class RegisterClientViewModel : INotifyPropertyChanged
    {
        #region Data members

        private RestClient client;

        private string username;

        private string password;

        private string firstName;

        private string lastName;

        private string email;



        #region Commands

        private ICommand submitCommand;

        #endregion

        #endregion

        #region Constructors

        public RegisterClientViewModel()
        {
            this.client = new RestClient();
        }

        #endregion

        #region Properties

        public string Username
        {
            get => username;
            set
            {
                username = value;
                RaisePropertyChange();
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                RaisePropertyChange();
            }
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                RaisePropertyChange();
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                RaisePropertyChange();
            }
        }

        public string Email
        {
            get => email;
            set
            {
                email = value;
                RaisePropertyChange();
            }
        }

        #endregion

        #region Commands

        public ICommand SubmitCommand
        {
            get
            {
                if(this.submitCommand == null)
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
            GeneralModel user = new RegisterViewModel
            {
                ViewModelType = "register",
                Username = this.Username,
                Password = this.Password,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email
            };

            var response = await client.PostMethodAsync(user, "register");

            if (response.Status == Models.ResponseStatus.Ok)
            {
                MessageBox.Show("Successfully registrated!");
            }
        }

        #endregion

        #region Commands CanExecute

        private bool SubmitCommandCanExecute()
        {
            return !string.IsNullOrEmpty(FirstName) &&
                   !string.IsNullOrEmpty(LastName) &&
                   !string.IsNullOrEmpty(Username) &&
                   !string.IsNullOrEmpty(Password) &&
                   !string.IsNullOrEmpty(Email);
        }

        #endregion

        #region Protected methods

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
