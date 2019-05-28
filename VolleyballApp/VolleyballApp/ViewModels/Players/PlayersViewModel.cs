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

        public ObservableCollection<PlayerViewModel> Players { get; set; }
        public ICommand CreatePlayerCommand { get; protected set; }
        public ICommand SavePlayerCommand { get; protected set; }
        public ICommand DeletePlayerCommand { get; protected set; }

        public INavigation Navigation { get; set; }

        public PlayersViewModel(int teamId)
        {
            Players = new ObservableCollection<PlayerViewModel>(GetPlayerViewModels(teamId));
            CreatePlayerCommand = new Command(CreatePlayer);
        }

        public List<PlayerViewModel> GetPlayerViewModels(int teamId)
        {
            List<PlayerViewModel> vms = new List<PlayerViewModel>();

            WebApiClient.GetPlayers(teamId)?.AsParallel().ForAll(player => vms.Add(new PlayerViewModel(player)));
            //foreach (Player player in WebApiClient.GetPlayers(teamId))
            //{
            //    vms.Add(new PlayerViewModel(player));
            //}
            return vms;
        }

        private void CreatePlayer()
        {
            Navigation.PushAsync(new PlayerPage(new PlayerViewModel() { PlayersViewModel = this }));
        }

    }
}
