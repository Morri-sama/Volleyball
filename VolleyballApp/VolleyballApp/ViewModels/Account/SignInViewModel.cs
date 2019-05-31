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
    public class SignInViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private string _userName;
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                SetPropertyAndRaise(ref _userName, value, "UserName");
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                SetPropertyAndRaise(ref _password, value, "Password");
            }
        }

        private bool _result;
        public bool Result
        {
            get => _result;
            set => SetPropertyAndRaise(ref _result, value, "Result");
        }

        private readonly INavigationService _navigator;
        public ICommand SignInCommand;

        public SignInViewModel(INavigationService navigator)
        {
            _navigator = navigator;
            SignInCommand = new Command(SignIn);
        }

        private void SignIn()
        {
            LoginViewModel loginViewModel = new LoginViewModel()
            {
                UserName = _userName,
                Password = _password
            };

            _result = WebApiClient.Login(loginViewModel);
            
        }
    }
}