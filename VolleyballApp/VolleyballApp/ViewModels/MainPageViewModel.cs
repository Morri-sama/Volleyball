using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using VolleyballApp.Helpers;
using VolleyballApp.ViewModels.Account;
using VolleyballApp.Views.Account;
using Xamarin.Forms;

namespace VolleyballApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public INavigation Navigation { get; set; }

        public MainPageViewModel()
        {
            if (WebApiClient.Validate())
            {

            }
            else
            {
                Navigation.PushAsync(new SignInPage(new SignInViewModel() { Navigation = this.Navigation}));
            }
        }
    }
}
