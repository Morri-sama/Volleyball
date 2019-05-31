using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using VolleyballApp.Helpers;
using VolleyballApp.Services.Navigation;
using VolleyballApp.ViewModels.Account;
using VolleyballApp.ViewModels.Teams;
using VolleyballApp.Views.Account;
using Xamarin.Forms;

namespace VolleyballApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigator;

        public ICommand TeamsCommand { get; set; }

        public MainPageViewModel(INavigationService navigator)
        {
            _navigator = navigator;

            TeamsCommand = new Command(Teams);
        }

        private void Teams()
        {
            _navigator.NavigateTo(new TeamsViewModel(_navigator));
        }
    }
}
