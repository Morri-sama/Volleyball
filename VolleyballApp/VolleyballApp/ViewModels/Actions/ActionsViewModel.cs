using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using VolleyballApp.Services.Navigation;
using Xamarin.Forms;

namespace VolleyballApp.ViewModels.Actions
{
    public class ActionsViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigator;

        public ObservableCollection<ActionBase> Actions { get; set; }

        public ICommand CreateActionCommand { get; protected set; }

        public ActionsViewModel(INavigationService navigator)
        {
            _navigator = navigator;

            Actions = new ObservableCollection<ActionBase>();

            //CreateActionCommand = new Command(CreateAction);
        }

        //private void CreateAction()
        //{
        //    if (!Actions.Any())
        //    {
        //        _navigator.OpenModal(this, "VolleyballApp.Views.Actions.CreateServeView");
        //    }
        //}

    }
}
