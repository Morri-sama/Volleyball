using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTeamPage : ContentPage
    {
        public Team Team { get; set; }

        public AddTeamPage()
        {
            InitializeComponent();
        }

        private void AddPlayer_Clicked(object sender, EventArgs e)
        {

        }
    }
}