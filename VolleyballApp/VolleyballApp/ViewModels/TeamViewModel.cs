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

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
