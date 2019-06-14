using System;
using VolleyballApp.Helpers;
using VolleyballApp.Services.Navigation;
using VolleyballApp.ViewModels;
using VolleyballApp.ViewModels.Account;
using VolleyballApp.ViewModels.Teams;
using VolleyballApp.Views;
using VolleyballApp.Views.Account;
using VolleyballApp.Views.Settings;
using VolleyballApp.Views.Teams;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VolleyballApp
{
    public partial class App : Application, IHaveMainPage
    {
        private readonly INavigationService _navigator;

        public App()
        {
            InitializeComponent();

            MainPage = new SignInView();

            _navigator = new NavigationService(this, new ViewLocator());

            Application.Current.Properties["ApiUrl"] = "http://192.168.42.151:5000/";


            if (WebApiClient.Validate())
            {
                _navigator.PresentAsNavigatableMainPage(new MainPageViewModel(_navigator));
            }
            else
            {
                _navigator.PresentAsNavigatableMainPage(new SignInViewModel(_navigator));
            }

            //_navigator.PresentAsNavigatableMainPage(new TeamsViewModel(_navigator));

        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
