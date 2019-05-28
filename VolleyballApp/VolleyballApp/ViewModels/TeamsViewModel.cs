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
using VolleyballApp.Views;
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
            Teams = new ObservableCollection<TeamViewModel>(GetTeamViewModels());
            CreateTeamCommand = new Command(CreateTeam);
            DeleteTeamCommand = new Command(DeleteTeam);
            BackCommand = new Command(Back);
        }

        public List<TeamViewModel> GetTeamViewModels()
        {
            HttpResponseMessage response = null;
            List<TeamViewModel> vms = null;
            using (var httpClient = new HttpClient())
            {
                response = httpClient.GetAsync(new Uri(Application.Current.Properties["apiUrl"] as string + "api/teams/")).Result;

                if (response.IsSuccessStatusCode)
                {
                    List<Team> teams =  JsonConvert.DeserializeObject<List<Team>>(response.Content.ReadAsStringAsync().Result);
                    vms = new List<TeamViewModel>();
                    foreach (var team in teams)
                    {
                        vms.Add(new TeamViewModel(team));
                    }
                    return vms;
                }
                else
                {
                    return null;
                }
            }
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

        public TeamViewModel SelectedTeam
        {
            get { return selectedTeam; }
            set
            {
                if (selectedTeam != value)
                {
                    TeamViewModel tempTeam = value;
                    selectedTeam = null;
                    OnPropertyChanged("SelectedFriend");
                    Navigation.PushAsync(new TeamPage(tempTeam));
                }
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
