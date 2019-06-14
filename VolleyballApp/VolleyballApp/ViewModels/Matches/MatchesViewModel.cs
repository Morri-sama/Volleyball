using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using VolleyballApp.Services.Navigation;

namespace VolleyballApp.ViewModels.Matches
{
    public class MatchesViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigator;

        public Team HomeTeam { get; set; }
        public Player HomeTeamPlayer1 { get; set; }
        public Player HomeTeamPlayer2 { get; set; }
        public Player HomeTeamPlayer3 { get; set; }
        public Player HomeTeamPlayer4 { get; set; }
        public Player HomeTeamPlayer5 { get; set; }
        public Player HomeTeamPlayer6 { get; set; }



        public Team AwayTeam { get; set; }
        public Player AwayTeamPlayer1 { get; set; }
        public Player AwayTeamPlayer2 { get; set; }
        public Player AwayTeamPlayer3 { get; set; }
        public Player AwayTeamPlayer4 { get; set; }
        public Player AwayTeamPlayer5 { get; set; }
        public Player AwayTeamPlayer6 { get; set; }

    }
}
