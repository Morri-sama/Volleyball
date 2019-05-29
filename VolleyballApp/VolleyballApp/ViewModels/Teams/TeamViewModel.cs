using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using VolleyballApp.Helpers;
using VolleyballApp.ViewModels.Players;
using VolleyballApp.Views.Players;
using Xamarin.Forms;

namespace VolleyballApp.ViewModels.Teams
{
    public class TeamViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        TeamsViewModel _teamsViewModel;

        public Team Team { get; private set; }
        public PlayersViewModel PlayersViewModel { get; set; }

        public ICommand DisplayPlayersCommand { get; protected set; }

        public INavigation Navigation { get; set; }

        public TeamViewModel()
        {
            Team = new Team();
            DisplayPlayersCommand = new Command(DisplayPlayers);
        }

        public TeamViewModel(Team team)
        {
            Team = team;
            PlayersViewModel = new PlayersViewModel(Team.Id) { Navigation=this.Navigation};
            DisplayPlayersCommand = new Command(DisplayPlayers);
        }



        public TeamsViewModel TeamsViewModel
        {
            get
            {
                return _teamsViewModel;
            }
            set
            {
                if (_teamsViewModel != value)
                {
                    _teamsViewModel = value;
                    OnPropertyChanged("TeamsViewModel");
                }
            }
        }

        private void DisplayPlayers()
        {
            Navigation.PushAsync(new PlayersPage(PlayersViewModel));
        }

        public List<PlayerViewModel> GetPlayerViewModels()
        {
            List<PlayerViewModel> vms = new List<PlayerViewModel>();
            foreach (var player in WebApiClient.GetPlayers(Team.Id))
            {
                vms.Add(new PlayerViewModel(player));
            }
            return vms;
        }

        public int Id
        {
            get
            {
                return Team.Id;
            }
            set
            {
                if (Team.Id != value)
                {
                    Team.Id = value;
                    OnPropertyChanged("Id");
                }
            }

        }

        public string Name
        {
            get
            {
                return Team.Name;
            }
            set
            {
                if(Team.Name != value)
                {
                    Team.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
