using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolleyballApp.ViewModels;
using VolleyballApp.ViewModels.Account;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VolleyballApp.Views.Account
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {

        public SignInViewModel ViewModel { get; set; }
        public SignInPage(SignInViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            BindingContext = ViewModel;
        }
    }
}