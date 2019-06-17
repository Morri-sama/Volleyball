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

        public ObservableCollection<ActionBase> Actions { get; protected set; }

        public ICommand CreateActionCommand { get; protected set; }

        public RallyViewModel(INavigationService navigator)
        {
            _navigator = navigator;

            Actions = new ObservableCollection<ActionBase>();

            CreateActionCommand = new Command(CreateAction);
        }

        public RallyViewModel(INavigationService navigator, SetViewModel setViewModel) : this(navigator)
        {
            HomeTeam = setViewModel.SetsViewModel.MatchViewModel.HomeTeam;
            AwayTeam = setViewModel.SetsViewModel.MatchViewModel.AwayTeam;
        }

        private void CreateAction()
        {

            if(Actions.Count == 0)
            {
                //_navigator.OpenModal(new ServeViewModel(_navigator, this), "VolleyballApp.Views.Actions.CreateServeView");

            }
        }
    }
}
