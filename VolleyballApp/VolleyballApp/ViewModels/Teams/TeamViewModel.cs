using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using VolleyballApp.Services.Navigation;
using Xamarin.Forms;

namespace VolleyballApp.ViewModels.Teams
{
    public class TeamViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigator;

        private int                 _id;
        private string              _name;
        private ICollection<Player> _players;

        public string Name { get => _name; set => Notify(ref _name, value, "Name"); }

        public ICommand SaveCommand { get; protected set; }

        public TeamViewModel(INavigationService navigator)
        {
            _navigator = navigator;

            SaveCommand = new Command(Save);
        }

        public TeamViewModel(INavigationService navigator, Team team)
        {
            _navigator = navigator;

            _id = team.Id;
            _name = team.Name;
            _players = team.Players;

            SaveCommand = new Command(Save);
        }

        private void Save()
        {

        }

    }
}
