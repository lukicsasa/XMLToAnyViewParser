using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using XMLToAnyViewParser.Common.Models;
using XMLToAnyViewParser.DesktopClient.Commands;
using XMLToAnyViewParser.DesktopClient.Helpers;
using XMLToAnyViewParser.Entities;
using XMLToAnyViewParser.Models.ViewModels;

namespace XMLToAnyViewParser.DesktopClient.ViewModels
{
    public class HomeClientViewModel : INotifyPropertyChanged
    {
        #region Data members

        private RestClient client;

        private int id;

        private string username;

        private string firstName;

        private string lastName;

        private string email;



        #region Commands

        private ICommand submitCommand;

        #endregion

        #endregion

        #region Constructors

        public HomeClientViewModel(User user)
        {
            this.client = new RestClient();

            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Email = user.Email;
            this.Username = user.Username;
            this.id = user.Id;
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
            UserModel user = new UserModel()
            {
                Username = this.Username,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                Id = this.id
            };

            var response = await client.PutMethodAsync(user, "user");

            if (response.Status == Models.ResponseStatus.Ok)
            {
                MessageBox.Show("Successfully updated!");
            }
        }

        #endregion
        #region Commands CanExecute

        private bool SubmitCommandCanExecute()
        {
            return !string.IsNullOrEmpty(FirstName) &&
                   !string.IsNullOrEmpty(LastName) &&
                   !string.IsNullOrEmpty(Username) &&
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
