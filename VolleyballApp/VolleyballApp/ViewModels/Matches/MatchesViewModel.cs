using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using VolleyballApp.Helpers;
using VolleyballApp.Services.Navigation;
using Xamarin.Forms;

namespace VolleyballApp.ViewModels.Matches
{
    public class MatchesViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigator;

        public ICommand CreateMatchCommand { get; protected set; }

        public MatchesViewModel(INavigationService navigator)
        {
            _navigator = navigator;

            CreateMatchCommand = new Command(CreateMatch);
        }

        private void CreateMatch()
        {
            _navigator.NavigateTo(new MatchViewModel(_navigator));
        }

    }
}
