﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
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

        private ICommand registerCommand;

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

        public ICommand RegisterCommand
        {
            get
            {
                if(this.registerCommand == null)
                {
                    this.registerCommand = new Command(p => RegisterCommandExecute());
                }

                return this.registerCommand;
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
                var data = JsonConvert.DeserializeObject<UserTokenModel>(response.Data.ToString());
                GlobalData.Token = data.Token;
                GlobalData.User = data.User;
                new HomeWindow().ShowDialog();
            }

        }
        
        private void RegisterCommandExecute()
        {
            new RegisterWindow().ShowDialog();
        }

        #endregion

        #region Commands CanExecute

        private bool SubmitCommandCanExecute()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
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
