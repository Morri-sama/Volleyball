using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using VolleyballApp.Helpers;
using VolleyballApp.Services.Navigation;

namespace VolleyballApp.ViewModels.Matches
{
    public class MatchesViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigator;

        public List<Team> Teams { get; protected set; }

        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }

        public MatchesViewModel(INavigationService navigator)
        {
            _navigator = navigator;

            Teams = WebApiClient.GetTeams();
        }



    }
}
