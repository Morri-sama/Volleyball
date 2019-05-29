using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using VolleyballApp.Helpers;
using VolleyballApp.Views.Players;
using Xamarin.Forms;

namespace VolleyballApp.ViewModels.Players
{
    public class PlayersViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int TeamId { get; private set; }

        public ObservableCollection<PlayerViewModel> Players { get; set; }
        public ICommand CreatePlayerCommand { get; protected set; }
        public ICommand AddPlayerCommand { get; protected set; }
        public ICommand SavePlayerCommand { get; protected set; }
        public ICommand DeletePlayerCommand { get; protected set; }
        public ICommand BackCommand { get; protected set; }

        public INavigation Navigation { get; set; }

        public PlayersViewModel(int teamId)
        {
            Players = new ObservableCollection<PlayerViewModel>(GetPlayerViewModels(teamId));
            CreatePlayerCommand = new Command(CreatePlayer);
            AddPlayerCommand = new Command(AddPlayer);
            BackCommand = new Command(Back);

            TeamId = teamId;
        }

        public List<PlayerViewModel> GetPlayerViewModels(int teamId)
        {
            List<PlayerViewModel> vms = new List<PlayerViewModel>();

            WebApiClient.GetPlayers(teamId)?.AsParallel().ForAll(player => vms.Add(new PlayerViewModel(player)));
            return vms;
        }

        private void CreatePlayer()
        {
            Navigation.PushAsync(new CreatePlayerPage(new PlayerViewModel() { PlayersViewModel = this }));
        }

        private void AddPlayer(object playerObject)
        {
            PlayerViewModel player = playerObject as PlayerViewModel;
            if (player != null)
            {
                player.Player.TeamId = TeamId;
                WebApiClient.AddPlayer(player.Player);
                Players.Add(player);
            }
            Back();
        }

        private void Back()
        {
            Navigation.PopAsync();
        }

    }
}
