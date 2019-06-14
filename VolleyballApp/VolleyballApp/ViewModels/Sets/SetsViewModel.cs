using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using VolleyballApp.Services.Navigation;
using Xamarin.Forms;

namespace VolleyballApp.ViewModels.Sets
{
    public class SetsViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigator;

        public ObservableCollection<ActionBase> Actions { get; set; }

        public ICommand CreateActionCommand { get; set; }

        public SetsViewModel(INavigationService navigator)
        {
            _navigator = navigator;
            CreateActionCommand = new Command(CreateAction);
        }

        private void CreateAction()
        {
            Actions = new ObservableCollection<ActionBase>();
        }
    }
}
