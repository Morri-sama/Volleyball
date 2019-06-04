using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VolleyballApp.Helpers;
using VolleyballApp.Services.Navigation;
using Xamarin.Forms;

namespace VolleyballApp.ViewModels.Players
{
    public class PlayerViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigator;
        private readonly PlayersViewModel _playersViewModel;

        private string _name;
        private int _positionId;
        private Position _position;
        private int _squadNumber;

        public string Name { get => _name; set => Notify(ref _name, value, "Name"); }
        public int SquadNumber { get => _squadNumber; set => Notify(ref _squadNumber, value, "SquadNumber"); }
        public Position Position { get => _position; set { Notify(ref _position, value, "Position"); _positionId = value.Id; } }
        public List<Position> Positions { get; } = WebApiClient.GetPositions();

        public Player Player { get; private set; }

        public ICommand AddPlayerCommand { get; protected set; }
        public ICommand CancelCommand { get; protected set; }

        public PlayerViewModel(INavigationService navigator)
        {
            _navigator = navigator;

            AddPlayerCommand = new Command(AddPlayer);
            CancelCommand = new Command(Cancel);
        }

        public PlayerViewModel(INavigationService navigator, PlayersViewModel playersViewModel) : this(navigator)
        {
            _playersViewModel = playersViewModel;
        }

        private void AddPlayer()
        {
            Player = new Player()
            {
                Name = _name,
                PositionId = _positionId,
                SquadNumber = _squadNumber
            };

            _playersViewModel.Players.Add(Player);
            _navigator.PopModal();
        }

        private void Cancel()
        {
            _navigator.PopModal();
        }
    }
}
