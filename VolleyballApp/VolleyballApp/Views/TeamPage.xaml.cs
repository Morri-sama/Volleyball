﻿using System;
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
    public partial class TeamPage : ContentPage
    {
        public TeamViewModel ViewModel { get; private set; }
        public TeamPage(TeamViewModel vm)
        {
            InitializeComponent();

            ViewModel = vm;
            this.BindingContext = ViewModel;
        }
    }
}