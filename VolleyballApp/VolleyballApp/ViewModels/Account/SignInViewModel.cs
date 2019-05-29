using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using ViewModels;
using VolleyballApp.Helpers;
using Xamarin.Forms;

namespace VolleyballApp.ViewModels.Account
{
    public class SignInViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string UserName
        {
            get
            {
                return LoginViewModel.UserName;
            }
            set
            {
                if (LoginViewModel.UserName != value)
                {
                    LoginViewModel.UserName = value;
                    OnPropertyChanged("UserName");
                }
            }
        }

        public string Password
        {
            get
            {
                return LoginViewModel.Password;
            }
            set
            {
                if (LoginViewModel.Password != value)
                {
                    LoginViewModel.Password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public LoginViewModel LoginViewModel { get; set; }

        public INavigation Navigation { get; set; }

        public ICommand SignInCommand;

        public SignInViewModel()
        {
            SignInCommand = new Command(SignIn);
        }

        private void SignIn()
        {
            WebApiClient.Login(LoginViewModel);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
