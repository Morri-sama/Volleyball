using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using ViewModels;
using VolleyballApp.Helpers;
using VolleyballApp.Services.Navigation;
using Xamarin.Forms;

namespace VolleyballApp.ViewModels.Account
{
    public class SignInViewModel : ViewModelBase
    {
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
                    //OnPropertyChanged("UserName");
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
                    //OnPropertyChanged("Password");
                }
            }
        }

        public LoginViewModel LoginViewModel { get; set; }

        private readonly INavigationService _navigator;

        public ICommand SignInCommand;

        public SignInViewModel(INavigationService navigator)
        {
            _navigator = navigator;
            SignInCommand = new Command(SignIn);
        }

        private void SignIn()
        {
            WebApiClient.Login(LoginViewModel);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
