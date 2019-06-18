using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Match : PropertyChangedBase, INotifyPropertyChanged
    {
        private int _id;
        private string _city;
        private DateTime _dateTime;
        private int? _homeTeamId;
        private Team _homeTeam;
        private int? _awayTeamId;
        private Team _awayTeam;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get => _id; set => Notify(ref _id, value, "Name"); }

        public string City { get => _city; set => Notify(ref _city, value, "City"); }
        public DateTime DateTime { get => _dateTime; set => Notify(ref _dateTime, value, "DateTime"); }

        [ForeignKey("HomeTeam")]
        public int? HomeTeamId { get => _homeTeamId; set => Notify(ref _homeTeamId, value, "HomeTeamId"); }
        public Team HomeTeam { get => _homeTeam; set => Notify(ref _homeTeam, value, "HomeTeam"); }

        [ForeignKey("AwayTeam")]
        public int? AwayTeamId { get => _awayTeamId; set => Notify(ref _awayTeamId, value, "AwayTeamId"); }
        public Team AwayTeam { get => _awayTeam; set => Notify(ref _awayTeam, value, "AwayTeam"); }

        public ObservableCollection<Set> Sets { get; set; }
    }
}
