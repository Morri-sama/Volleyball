using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace VolleyballApp.ViewModels
{
    public class TeamViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        TeamsViewModel _teamsViewModel;

        public Team Team { get; private set; }

        public TeamViewModel()
        {
            Team = new Team();
        }

        public TeamViewModel(Team team)
        {
            Team = team;
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

        public List<Player> Players
        {
            get
            {
                return Team.Players;
            }
            set
            {
                if(Team.Players != value)
                {
                    Team.Players = value;
                    OnPropertyChanged("Players");
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
