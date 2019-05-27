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
    public partial class SignUpPage : ContentPage
    {
        string apiUrl = @"http://192.168.42.151:5000/";

        public SignUpPage()
        {
            InitializeComponent();
        }

        private void SignInButton_Clicked(object sender, EventArgs e)
        {
            HttpResponseMessage response = null;

            RegisterViewModel model = new RegisterViewModel()
            {
                FirstName=UserName.Text,
                MiddleName=MiddleName.Text,
                LastName=LastName.Text,
                UserName=UserName.Text,
                Password=Password.Text
            };

            using (var httpClient = new HttpClient())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                response = httpClient.PostAsync(new Uri(apiUrl + "api/account/register"), stringContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    
                }
            }
        }
    }
}