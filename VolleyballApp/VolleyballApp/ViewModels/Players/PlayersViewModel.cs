using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using VolleyballApp.Helpers;
using VolleyballApp.Services.Navigation;
using VolleyballApp.ViewModels.Teams;
using VolleyballApp.Views.Players;
using Xamarin.Forms;

namespace VolleyballApp.ViewModels.Players
{
    public class PlayersViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigator;

        public TeamViewModel TeamViewModel { get; }

        public ObservableCollection<Player> Players { get; set; }

        public ICommand CreatePlayerCommand { get; protected set; }
        public ICommand AddPlayerCommand { get; protected set; }
        public ICommand SavePlayerCommand { get; protected set; }
        public ICommand DeletePlayerCommand { get; protected set; }
        public ICommand BackCommand { get; protected set; }

        public PlayersViewModel(INavigationService navigator)
        {
            _navigator = navigator;
            Players = new ObservableCollection<Player>();

            AddPlayerCommand = new Command(AddPlayer);
            BackCommand = new Command(Back);
        }

        public PlayersViewModel(INavigationService navigator, TeamViewModel team) : this(navigator)
        {
            TeamViewModel = team;
        }

        private void AddPlayer()
        {
            var playerViewModel = new PlayerViewModel(_navigator, this);
            _navigator.OpenModal(playerViewModel, "VolleyballApp.Views.Players.CreatePlayerView");
        }

        private void Back()
        {
            _navigator.NavigateBack();
        }

        
    }
}
