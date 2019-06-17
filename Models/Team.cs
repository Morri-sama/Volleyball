using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Team : PropertyChangedBase
    {
        private int _id;
        private string _name;
        private ObservableCollection<Player> _players;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get => _id; set => Notify(ref _id, value, "Name"); }
        public string Name { get => _name; set => Notify(ref _name, value, "Name"); }

        public ObservableCollection<Player> Players { get => _players; set => Notify(ref _players, value, "Name"); }
    }
}
