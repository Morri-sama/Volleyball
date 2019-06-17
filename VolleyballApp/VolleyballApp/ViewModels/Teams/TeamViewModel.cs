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

        public Team Team { get; protected set; }

        public ICommand SaveCommand { get; protected set; }
        public ICommand AddPlayersCommand { get; protected set; }

        public TeamViewModel(INavigationService navigator)
        {
            _navigator = navigator;

            SaveCommand = new Command(Save);
            AddPlayersCommand = new Command(AddPlayers);
        }

        public TeamViewModel(INavigationService navigator, Team team) : this(navigator)
        {
            Team = team;
        }

        private void Save()
        {
            WebApiClient.AddTeam(Team);

            Application.Current.MainPage.DisplayAlert("Успех", "Команда создана", "Ок");

            _navigator.NavigateBack();
        }

        private void AddPlayers()
        {
            _navigator.NavigateTo(new PlayersViewModel(_navigator, this));
        }

    }
}
