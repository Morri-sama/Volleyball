using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using VolleyballApp.Services.Navigation;
using VolleyballApp.ViewModels.Rallies;
using Xamarin.Forms;

namespace VolleyballApp.ViewModels.Sets
{
    public class SetViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigator;

        public SetsViewModel SetsViewModel { get; set; }

        public ObservableCollection<Rally> Rallies { get; protected set; }

        public ICommand CreateRallyCommand { get; protected set; }

        public SetViewModel(INavigationService navigator, SetsViewModel setsViewModel)
        {
            _navigator = navigator;
            SetsViewModel = setsViewModel;

            Rallies = new ObservableCollection<Rally>();

            CreateRallyCommand = new Command(CreateRally);
        }

        private void CreateRally()
        {
            RallyViewModel rallyViewModel = new RallyViewModel(_navigator, this);
            _navigator.NavigateTo(rallyViewModel, "VolleyballApp.Views.Rallies.RallyView");
        }
    }
}
