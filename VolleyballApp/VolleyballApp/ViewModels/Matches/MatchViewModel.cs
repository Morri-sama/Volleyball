﻿using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using VolleyballApp.Helpers;
using VolleyballApp.Services.Navigation;
using VolleyballApp.ViewModels.Sets;
using Xamarin.Forms;

namespace VolleyballApp.ViewModels.Matches
{
    public class MatchViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigator;

        public List<Team> Teams { get => WebApiClient.GetTeams(); } 

        public ICommand BeginCommand { get; protected set; }

        public ObservableCollection<Set> Sets { get; set; }

        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }

        public MatchViewModel(INavigationService navigator)
        {
            _navigator = navigator;

            BeginCommand = new Command(Begin);

            Sets = new ObservableCollection<Set>(); 
        }

        private void Begin()
        {
            _navigator.NavigateTo(new SetsViewModel(_navigator, this), "VolleyballApp.Views.Sets.SetsView");
        }
    }
}
