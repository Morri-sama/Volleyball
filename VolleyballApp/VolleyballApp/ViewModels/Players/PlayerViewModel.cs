using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using VolleyballApp.Helpers;

namespace VolleyballApp.ViewModels.Players
{
    public class PlayerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Player Player { get; private set; }
        PlayersViewModel _playersViewModel;

        public PlayerViewModel()
        {
            Player = new Player();
        }

        public PlayerViewModel(Player player)
        {
            Player = player;
            Player.Position = WebApiClient.GetPosition(Player.PositionId);
        }

        public PlayersViewModel PlayersViewModel
        {
            get
            {
                return _playersViewModel;
            }
            set
            {
                if (_playersViewModel != value)
                {
                    _playersViewModel = value;
                    OnPropertyChanged("PlayersViewModel");
                }
            }
        }

        public int Id
        {
            get
            {
                return Player.Id;
            }
            set
            {
                if (Player.Id != value)
                {
                    Player.Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string Name
        {
            get
            {
                return Player.Name;
            }
            set
            {
                if (Player.Name != value)
                {
                    Player.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public int SquadNumber
        {
            get
            {
                return Player.SquadNumber;
            }
            set
            {
                if (Player.SquadNumber != value)
                {
                    Player.SquadNumber = value;
                    OnPropertyChanged("SquadNumber");
                }
            }
        }

        public int PositionId
        {
            get
            {
                return Player.PositionId;
            }
            set
            {
                if (Player.PositionId != value)
                {
                    Player.PositionId = value;
                    OnPropertyChanged("PositionId");
                }
            }
        }

        public Position Position
        {
            get
            {
                return Player.Position;
            }
            set
            {
                if (Player.Position != Position)
                {
                    Player.Position = value;
                    OnPropertyChanged("Position");
                }
            }
        }

        public int TeamId
        {
            get
            {
                return Player.TeamId;
            }
            set
            {
                if (Player.TeamId != TeamId)
                {
                    Player.TeamId = value;
                    OnPropertyChanged("TeamId");
                }
            }
        }

        public Team Team
        {
            get
            {
                return Player.Team;
            }
            set
            {
                if (Player.Team != Team)
                {
                    Player.Team = value;
                    OnPropertyChanged("Team");
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
