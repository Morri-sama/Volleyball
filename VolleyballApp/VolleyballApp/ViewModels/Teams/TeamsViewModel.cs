using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VolleyballApp.Helpers;
using VolleyballApp.Services.Navigation;
using VolleyballApp.Views;
using VolleyballApp.Views.Teams;
using Xamarin.Forms;

namespace VolleyballApp.ViewModels.Teams
{
    public class TeamsViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigator;

        public ObservableCollection<TeamViewModel> Teams { get; set; }

        public ICommand RefreshTeamsCommand { get; protected set; }
        public ICommand CreateTeamCommand { get; protected set; }

        public ICommand DeleteTeamCommand { get; protected set; }
        public ICommand BackCommand { get; protected set; }

        //TeamViewModel selectedTeam;

        public INavigation Navigation { get; set; }

        public TeamsViewModel(INavigationService navigator)
        {
            _navigator = navigator;

            Teams = new ObservableCollection<TeamViewModel>(GetTeamViewModels());
            RefreshTeamsCommand = new Command(RefreshTeams);
            CreateTeamCommand = new Command(CreateTeam);
            DeleteTeamCommand = new Command(DeleteTeam);
            BackCommand = new Command(Back);
        }

        public List<TeamViewModel> GetTeamViewModels()
        {
            List<TeamViewModel> vms = new List<TeamViewModel>();
            foreach (var team in WebApiClient.GetTeams())
            {
                vms.Add(new TeamViewModel(_navigator, team));
            }
            return vms;
        }

        private void RefreshTeams()
        {
            Teams = new ObservableCollection<TeamViewModel>(GetTeamViewModels());
        }


        private void CreateTeam()
        {
            //Navigation.PushAsync(new TeamPage(new TeamViewModel() { TeamsViewModel = this, Navigation = Navigation }));
        }

        private void DeleteTeam()
        {

        }

        private void Back()
        {
            Navigation.PopAsync();
        }

        //public TeamViewModel SelectedTeam
        //{
        //    get { return selectedTeam; }
        //    set
        //    {
        //        if (selectedTeam != value)
        //        {
        //            TeamViewModel tempTeam = value;
        //            tempTeam.Navigation = this.Navigation;
        //            selectedTeam = null;
        //            OnPropertyChanged("SelectedTeam");
        //            Navigation.PushAsync(new TeamPage(tempTeam));
        //        }
        //    }
        //}
    }
}
