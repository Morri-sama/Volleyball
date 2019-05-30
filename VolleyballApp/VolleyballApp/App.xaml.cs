using System;
using VolleyballApp.Services.Navigation;
using VolleyballApp.Views;
using VolleyballApp.Views.Settings;
using VolleyballApp.Views.Teams;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VolleyballApp
{
    public partial class App : Application, IHaveMainPage
    {
        public App()
        {
            InitializeComponent();

            Application.Current.Properties["apiUrl"] = @"http://192.168.42.151:5000/";

            MainPage = new MainPagePage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
