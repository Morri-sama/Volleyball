using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        string apiUrl = @"http://192.168.1.33:5000/";

        public SignInPage()
        {
            InitializeComponent();
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        private async void SignInButton_Clicked(object sender, EventArgs e)
        {
            HttpResponseMessage response = null;

            LoginViewModel model = new LoginViewModel()
            {
                UserName = UserNameEntry.Text,
                Password = PasswordEntry.Text
            };

            using (var httpClient = new HttpClient())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                response = httpClient.PostAsync(new Uri(apiUrl + "api/account/login"), stringContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    StatusLabel.Text = await response.Content.ReadAsStringAsync();
                    Application.Current.Properties["JwtToken"] = await response.Content.ReadAsStringAsync();
                    await DisplayAlert("Успех", "Заходим, начальник", "Ok");
                    Application.Current.MainPage = new MenuPage();
                    await Navigation.PopToRootAsync(true);
                }
                else
                {
                    await DisplayAlert("Провал", "Хуёво, начальник", "Ok");
                }
            }
        }
    }
}