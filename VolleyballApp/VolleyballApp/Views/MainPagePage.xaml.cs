using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolleyballApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VolleyballApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPagePage : ContentPage
    {
        public MainPagePage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel()
            {
                Navigation = Navigation
            };
        }
    }
}