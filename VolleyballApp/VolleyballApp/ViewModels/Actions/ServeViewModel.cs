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
    public class ServeViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigator;
        private readonly RallyViewModel _rallyViewModel;

        public ICommand SaveCommand { get; protected set; }

        public ServeViewModel(INavigationService navigator, RallyViewModel rallyViewModel)
        {
            _navigator = navigator;
            _rallyViewModel = rallyViewModel;

            SaveCommand = new Command(Save);
        }

        private void Save()
        {
            _rallyViewModel.Actions.Add(new Serve()
            {
                
            });
        }
    }
}
