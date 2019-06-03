using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using VolleyballApp.Services.Navigation;
using Xamarin.Forms;

namespace VolleyballApp.ViewModels.Settings
{
    public class SettingsViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigator;

        private string _apiUrl;

        public string ApiUrl { get => _apiUrl; set => Notify(ref _apiUrl, value, "ApiUrl"); }

        public ICommand SaveSettingsCommand { get; protected set; }
        public ICommand BackCommand { get; protected set; }

        public SettingsViewModel(INavigationService navigator)
        {
            _navigator = navigator;
            _apiUrl = Application.Current.Properties.ContainsKey("ApiUrl") ? Application.Current.Properties["ApiUrl"] as string : string.Empty;

            SaveSettingsCommand = new Command(SaveSettings);
            BackCommand = new Command(Back);
        }

        private void SaveSettings()
        {
            Application.Current.Properties["ApiUrl"] = _apiUrl;
        }

        private void Back()
        {
            _navigator.NavigateBack();
        }
    }
}
