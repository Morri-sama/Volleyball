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
    public class SignUpViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigator;

        private string _userName;
        private string _password;
        private string _firstName;
        private string _middleName;
        private string _lastName;

        public string UserName      { get => _userName;     set => Notify(ref _userName, value, "UserName"); }
        public string Password      { get => _password;     set => Notify(ref _password, value, "Password"); }
        public string FirstName     { get => _firstName;    set => Notify(ref _firstName, value, "FirstName"); }
        public string MiddleName    { get => _middleName;   set => Notify(ref _middleName, value, "MiddleName"); }
        public string LastName      { get => _lastName;     set => Notify(ref _lastName, value, "LastName"); }

        public ICommand SignUpCommand { get; protected set; } 
        public ICommand BackCommand   { get; protected set; }

        public SignUpViewModel(INavigationService navigator)
        {
            _navigator = navigator;

            SignUpCommand = new Command(SignUp);
            BackCommand = new Command(Back);
        }

        private void SignUp()
        {
            RegisterViewModel registerViewModel = new RegisterViewModel()
            {
                UserName=_userName,
                Password = _password,
                FirstName = _firstName,
                MiddleName = _middleName,
                LastName = _lastName
            };

            WebApiClient.Register(registerViewModel);
        }

        private void Back()
        {
            _navigator.NavigateBack();
        }
    }
}
