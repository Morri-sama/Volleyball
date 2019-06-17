using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using VolleyballApp.Services.Navigation;
using VolleyballApp.ViewModels.Matches;
using Xamarin.Forms;

namespace VolleyballApp.ViewModels.Sets
{
    public class SetsViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigator;

        public MatchViewModel MatchViewModel { get; protected set; }
        public ICommand CreateSetCommand { get; set; }

        public SetsViewModel(INavigationService navigator, MatchViewModel matchViewModel)
        {
            MatchViewModel = matchViewModel;

            _navigator = navigator;
            CreateSetCommand = new Command(CreateSet);
        }

        private void CreateSet()
        {
            _navigator.NavigateTo(new SetViewModel(_navigator, this));
        }
    }
}
