using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using VolleyballApp.Helpers;
using VolleyballApp.Services.Navigation;
using VolleyballApp.ViewModels.Players;
using Xamarin.Forms;

namespace VolleyballApp.ViewModels.Teams
{
    public class TeamViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigator;

        private int                 _id;
        private string              _name;

        public string Name { get => _name; set => Notify(ref _name, value, "Name"); }
        public PlayersViewModel Players { get; protected set; }

        public ICommand SaveCommand { get; protected set; }
        public ICommand AddPlayersCommand { get; protected set; }

        public TeamViewModel(INavigationService navigator)
        {
            _navigator = navigator;

            SaveCommand = new Command(Save);
            AddPlayersCommand = new Command(AddPlayers);
            Players = new PlayersViewModel(navigator, this);
        }

        public TeamViewModel(INavigationService navigator, Team team) : this(navigator)
        {
            _id = team.Id;
            _name = team.Name;
            Players = new PlayersViewModel(navigator, this);
        }

        private void Save()
        {

        }

        private void AddPlayers()
        {
            _navigator.NavigateTo(Players);
        }

    }
}
