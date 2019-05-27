using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPlayerPage : ContentPage
    {
        string apiUrl = @"http://192.168.42.151:5000/";
        private Dictionary<int, string> PickerItems = new Dictionary<int, string>();
        public List<Position> Positions { get; set; }

        public AddPlayerPage()
        {
            HttpResponseMessage response = null;

            using (var httpClient = new HttpClient())
            {
                response = httpClient.GetAsync(new Uri(apiUrl + "api/positions/")).Result;

                if (response.IsSuccessStatusCode)
                {
                    List<Position> positions =JsonConvert.DeserializeObject<List<Position>>(response.Content.ReadAsStringAsync().Result);
                    Positions = positions;

                    foreach(var position in positions)
                    {
                        PickerItems.Add(position.Id, position.Name);
                    }
                }
                else
                {
                }
            }

            InitializeComponent();
        }

        public List<KeyValuePair<int, string>> PickerItemList
        {
            get => PickerItems.ToList();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}