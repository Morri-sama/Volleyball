using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using ViewModels;
using VolleyballApp.Helpers;
using VolleyballApp.Services.Navigation;
using VolleyballApp.ViewModels.Settings;
using Xamarin.Forms;

namespace VolleyballApp.ViewModels.Account
{
    public class SignInViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigator;

        private string _userName;
        private string _password;
        private bool _result;

        public string UserName { get => _userName; set => Notify(ref _userName, value, "UserName"); }
        public string Password { get => _password; set => Notify(ref _password, value, "Password"); }
        public bool   Result   { get => _result;   set => Notify(ref _result, value, "Result"); }

        
        public ICommand SignInCommand   { get; protected set; }
        public ICommand SignUpCommand   { get; protected set; }
        public ICommand SettingsCommand { get; protected set; }

        public SignInViewModel(INavigationService navigator)
        {
            _navigator = navigator;
            SignInCommand = new Command(SignIn);
            SignUpCommand = new Command(SignUp);
            SettingsCommand = new Command(Settings);
        }

        private void SignIn()
        {
            LoginViewModel loginViewModel = new LoginViewModel()
            {
                UserName = _userName,
                Password = _password
            };

            if(WebApiClient.Login(loginViewModel))
            {
                _navigator.PresentAsNavigatableMainPage(new MainPageViewModel(_navigator));
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Ошибка", "Ошибка входа", "Похуй");
            }
        }

        private void SignUp()
        {
            _navigator.NavigateTo(new SignUpViewModel(_navigator));
        }

        private void Settings()
        {
            _navigator.NavigateTo(new SettingsViewModel(_navigator));
        }
    }
}