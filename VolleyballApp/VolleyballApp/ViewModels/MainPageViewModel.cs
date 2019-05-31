using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using VolleyballApp.Helpers;
using VolleyballApp.Services.Navigation;
using VolleyballApp.ViewModels.Account;
using VolleyballApp.Views.Account;
using Xamarin.Forms;

namespace VolleyballApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigator;

        public MainPageViewModel(INavigationService navigator)
        {
            _navigator = navigator;
        }
    }
}
