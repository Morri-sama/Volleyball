using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using VolleyballApp.Services.Navigation;
using VolleyballApp.ViewModels.Matches;
using VolleyballApp.ViewModels.Rallies;
using Xamarin.Forms;

namespace VolleyballApp.ViewModels.Sets
{
    public class SetViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigator;

        public MatchViewModel MatchViewModel { get; private set; }

        public ICommand CreateRallyCommand { get; protected set; }

        public SetViewModel(INavigationService navigator)
        {
            _navigator = navigator;

            CreateRallyCommand = new Command(CreateRally);
        }

        public SetViewModel(INavigationService navigator, MatchViewModel matchViewModel) : this(navigator)
        {
            MatchViewModel = matchViewModel;
        }

        private void CreateRally()
        {
            RallyViewModel rallyViewModel = new RallyViewModel(_navigator, this);
            _navigator.NavigateTo(rallyViewModel, "VolleyballApp.Views.Rallies.RallyView");
        }
    }
}
