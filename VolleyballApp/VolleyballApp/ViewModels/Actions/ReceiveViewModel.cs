using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using VolleyballApp.Services.Navigation;
using VolleyballApp.ViewModels.Rallies;
using Xamarin.Forms;

namespace VolleyballApp.ViewModels.Actions
{
    public class ReceiveViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigator;

        public RallyViewModel RallyViewModel { get; private set; }

        public Receive Receive { get; protected set; }
        public Team Team { get; protected set; }

        public ICommand SaveCommand { get; protected set; }
        public ICommand SaveLoseCommand { get; protected set; }

        public ReceiveViewModel(INavigationService navigator, RallyViewModel rallyViewModel, Team team)
        {
            _navigator = navigator;
            RallyViewModel = rallyViewModel;

            Receive = new Receive();
            Receive.Team = team;
            Team = team;

            SaveCommand = new Command(Save);
            SaveLoseCommand = new Command(SaveLose);
        }

        private void Save()
        {
            Receive.Index = RallyViewModel.Actions.Count;
            RallyViewModel.Actions.Add(Receive);
            _navigator.PopModal();
        }

        private void SaveLose()
        {
            Receive.Result = "Негативный";
            Receive.Index = RallyViewModel.Actions.Count;
            RallyViewModel.Actions.Add(Receive);
            RallyViewModel.Closed = true;
            _navigator.PopModal();

            Application.Current.MainPage.DisplayAlert("Завершение", $"{RallyViewModel.WinnerTeam.Name} получает очко", "Ок");
        }
    }
}
