using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using VolleyballApp.Services.Navigation;
using VolleyballApp.ViewModels.Actions;
using VolleyballApp.ViewModels.Sets;
using Xamarin.Forms;

namespace VolleyballApp.ViewModels.Rallies
{
    public class RallyViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigator;
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public Team SelectedTeam { get; set; }
        public Team OppositeTeam { get; set; }
        public Team WinnerTeam { get; set; }
        public bool Closed { get; set; } = false;

        public ObservableCollection<ActionBase> Actions { get; protected set; }

        public ICommand CreateActionCommand { get; protected set; }
        public ICommand SelectHomeTeamCommand { get; protected set; }
        public ICommand SelectAwayTeamCommand { get; protected set; }

        public RallyViewModel(INavigationService navigator)
        {
            _navigator = navigator;

            Actions = new ObservableCollection<ActionBase>();

            CreateActionCommand = new Command(CreateAction, CreateActionCanExecute);
            SelectHomeTeamCommand = new Command(SelectHomeTeam);
            SelectAwayTeamCommand = new Command(SelectAwayTeam);
        }

        public RallyViewModel(INavigationService navigator, SetViewModel setViewModel) : this(navigator)
        {
            HomeTeam = setViewModel.MatchViewModel.HomeTeam;
            AwayTeam = setViewModel.MatchViewModel.AwayTeam;

            _navigator.OpenModal(this, "VolleyballApp.Views.Rallies.SelectTeamView");
        }

        private bool CreateActionCanExecute()
        {
            return !Closed;
        }

        private void SelectHomeTeam()
        {
            SelectedTeam = HomeTeam;
            OppositeTeam = AwayTeam;
            _navigator.PopModal();
        }

        private void SelectAwayTeam()
        {
            SelectedTeam = AwayTeam;
            OppositeTeam = HomeTeam;
            _navigator.PopModal();
        }

        private void CreateAction()
        {
            if (SelectedTeam == null)
            {
                _navigator.OpenModal(this, "VolleyballApp.Views.Rallies.SelectTeamView");
            }

            if (Actions.Count == 0)
            {
                _navigator.OpenModal(new ServeViewModel(_navigator, this, SelectedTeam), "VolleyballApp.Views.Actions.CreateServeView");

            }
            else if (Actions[Actions.Count-1] is Serve && Actions[Actions.Count-1].Result == "Ввёл")
            {
                Team team;

                if (Actions[Actions.Count-1].Team == SelectedTeam)
                {
                    team = OppositeTeam;
                }
                else
                {
                    team = SelectedTeam;
                }

                _navigator.OpenModal(new ReceiveViewModel(_navigator, this, team), "VolleyballApp.Views.Actions.CreateReceiveView");
            }
            else if (Actions[Actions.Count - 1].Result == "Выиграл")
            {
                WinnerTeam = Actions[Actions.Count - 1].Team;

                Team team;

                if (Actions[Actions.Count - 1].Team == SelectedTeam)
                {
                    team = OppositeTeam;
                }
                else
                {
                    team = SelectedTeam;
                }

                _navigator.OpenModal(new ReceiveViewModel(_navigator, this, team), "VolleyballApp.Views.Actions.CreateReceiveLoseView");


            }


        }
    }
}
