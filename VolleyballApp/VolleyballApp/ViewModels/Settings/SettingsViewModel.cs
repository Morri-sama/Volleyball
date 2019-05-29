using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace VolleyballApp.ViewModels.Settings
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SaveSettingsCommand { get; protected set; }
        public ICommand BackCommand { get; protected set; }

        public INavigation Navigation { get; set; }

        public string ApiUrl { get; protected set; }

        public SettingsViewModel()
        {
            SaveSettingsCommand = new Command(SaveSettings);

            ApiUrl = Application.Current.Properties["apiUrl"] as string;
        }

        private void SaveSettings()
        {
            Application.Current.Properties["apiUrl"] = ApiUrl;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
