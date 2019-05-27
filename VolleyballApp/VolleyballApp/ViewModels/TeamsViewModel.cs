using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace VolleyballApp.ViewModels
{
    public class TeamsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<TeamViewModel> Teams { get; set; }

        public ICommand CreateTeamCommand { get; protected set; }
        public ICommand DeleteTeamCommand { get; protected set; }
        public ICommand BackCommand { get; protected set; }

        TeamViewModel selectedTeam;

        public INavigation Navigation { get; set; }

        public TeamsViewModel()
        {
            Teams = new ObservableCollection<TeamViewModel>();
            CreateTeamCommand = new Command(CreateTeam);
            DeleteTeamCommand = new Command(DeleteTeam);
            BackCommand = new Command(Back);
        }

        private void CreateTeam()
        {
            Navigation.PushAsync(new TeamPage(new TeamViewModel() { TeamsViewModel = this }));
        }

        private void DeleteTeam()
        {

        }

        private void Back()
        {

        }
    }
}
