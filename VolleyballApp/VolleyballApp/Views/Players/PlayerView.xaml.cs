﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolleyballApp.ViewModels.Players;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VolleyballApp.Views.Players
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerView : ContentPage
    {
        public PlayerView()
        {
            InitializeComponent();
        }
    }
}